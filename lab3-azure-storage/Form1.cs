using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using labCloud_3.Models;
using labCloud_3.Services;

namespace labCloud_3
{
    public partial class Form1 : Form
    {
        // Рядок підключення з Azure Portal -> Access Keys -> Connection string
        private static readonly string AzureConnectionString =
     Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION") ?? "";
        private const string TableName = "contacts";
        private const string ContainerName = "contactphotos";

        private readonly ContactTableService _tableService;
        private readonly ContactPhotoService _photoService;

        private string _selectedPhotoPath = string.Empty;
        private ContactEntity? _selectedContact = null;

        public Form1()
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(AzureConnectionString))
            {
                MessageBox.Show("Не задано змінну середовища AZURE_STORAGE_CONNECTION. Дивись README.");
                Environment.Exit(1);
            }

            _tableService = new ContactTableService(AzureConnectionString, TableName);
            _photoService = new ContactPhotoService(AzureConnectionString, ContainerName);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await RefreshContactListAsync();
        }

        private async Task RefreshContactListAsync()
        {
            try
            {
                var contacts = await _tableService.GetAllContactsAsync();
                listContacts.DataSource = null;
                listContacts.DataSource = contacts;
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Зображення|*.jpg;*.jpeg;*.png;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _selectedPhotoPath = dialog.FileName;
                picPhoto.ImageLocation = _selectedPhotoPath;
            }
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhoneInput.Text))
            {
                listPhones.Items.Add(txtPhoneInput.Text.Trim());
                txtPhoneInput.Clear();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Прізвище та ім'я є обов'язковими.");
                return;
            }

            try
            {
                string contactId = Guid.NewGuid().ToString();
                string photoUrl = string.Empty;

                if (!string.IsNullOrEmpty(_selectedPhotoPath) && File.Exists(_selectedPhotoPath))
                {
                    photoUrl = await _photoService.UploadPhotoAsync(contactId, _selectedPhotoPath);
                }

                var phones = listPhones.Items.Cast<string>().ToList();
                var contact = new ContactEntity
                {
                    PartitionKey = txtLastName.Text.Trim(),
                    RowKey = contactId,
                    LastName = txtLastName.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    PhonesCsv = string.Join(";", phones),
                    PhotoUrl = photoUrl
                };

                await _tableService.AddContactAsync(contact);
                MessageBox.Show("Контакт додано!");
                await RefreshContactListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedContact == null)
            {
                MessageBox.Show("Оберіть контакт для оновлення.");
                return;
            }

            try
            {
                string photoUrl = _selectedContact.PhotoUrl;
                if (!string.IsNullOrEmpty(_selectedPhotoPath) && File.Exists(_selectedPhotoPath))
                {
                    await _photoService.DeletePhotoAsync(_selectedContact.RowKey);
                    photoUrl = await _photoService.UploadPhotoAsync(_selectedContact.RowKey, _selectedPhotoPath);
                }

                var phones = listPhones.Items.Cast<string>().ToList();
                _selectedContact.FirstName = txtFirstName.Text.Trim();
                _selectedContact.MiddleName = txtMiddleName.Text.Trim();
                _selectedContact.Address = txtAddress.Text.Trim();
                _selectedContact.PhonesCsv = string.Join(";", phones);
                _selectedContact.PhotoUrl = photoUrl;

                await _tableService.UpdateContactAsync(_selectedContact);
                MessageBox.Show("Контакт оновлено!");
                await RefreshContactListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (listContacts.SelectedItem is not ContactEntity selected)
            {
                MessageBox.Show("Оберіть контакт зі списку.");
                return;
            }

            try
            {
                // Узгоджене видалення: спочатку Blob, потім запис у таблиці
                await _photoService.DeletePhotoAsync(selected.RowKey);
                await _tableService.DeleteContactAsync(selected.PartitionKey, selected.RowKey);

                MessageBox.Show("Контакт видалено!");
                await RefreshContactListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshContactListAsync();
        }

        private void listContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listContacts.SelectedItem is ContactEntity contact)
            {
                _selectedContact = contact;
                txtLastName.Text = contact.LastName;
                txtFirstName.Text = contact.FirstName;
                txtMiddleName.Text = contact.MiddleName;
                txtAddress.Text = contact.Address;

                listPhones.Items.Clear();
                if (!string.IsNullOrEmpty(contact.PhonesCsv))
                {
                    foreach (var phone in contact.PhonesCsv.Split(';'))
                    {
                        listPhones.Items.Add(phone);
                    }
                }

                picPhoto.ImageLocation = !string.IsNullOrEmpty(contact.PhotoUrl) ? contact.PhotoUrl : null;
                _selectedPhotoPath = string.Empty;
            }
        }

        private void ClearForm()
        {
            _selectedContact = null;
            _selectedPhotoPath = string.Empty;
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtAddress.Clear();
            txtPhoneInput.Clear();
            listPhones.Items.Clear();
            picPhoto.ImageLocation = null;
            picPhoto.Image = null;
        }
    }
}