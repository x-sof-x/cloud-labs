namespace labCloud_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnAddPhone = new Button();
            btnUploadPhoto = new Button();
            txtLastName = new TextBox();
            label1 = new Label();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtAddress = new TextBox();
            txtPhoneInput = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            listPhones = new ListBox();
            listContacts = new ListBox();
            label6 = new Label();
            label7 = new Label();
            picPhoto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(39, 567);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(204, 567);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Оновити";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(374, 567);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(523, 567);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(180, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Оновити список";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddPhone
            // 
            btnAddPhone.Location = new Point(374, 446);
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(165, 29);
            btnAddPhone.TabIndex = 4;
            btnAddPhone.Text = "Додати номер";
            btnAddPhone.UseVisualStyleBackColor = true;
            btnAddPhone.Click += btnAddPhone_Click;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.Location = new Point(639, 246);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(184, 29);
            btnUploadPhoto.TabIndex = 5;
            btnUploadPhoto.Text = "Завантажити фото";
            btnUploadPhoto.UseVisualStyleBackColor = true;
            btnUploadPhoto.Click += btnUploadPhoto_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(148, 113);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 116);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 7;
            label1.Text = "Прізвище:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(148, 178);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 8;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(148, 252);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(125, 27);
            txtMiddleName.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(148, 327);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 10;
            // 
            // txtPhoneInput
            // 
            txtPhoneInput.Location = new Point(148, 399);
            txtPhoneInput.Name = "txtPhoneInput";
            txtPhoneInput.Size = new Size(125, 27);
            txtPhoneInput.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 185);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 12;
            label2.Text = "Ім'я:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 255);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 13;
            label3.Text = "По батькові:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 334);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 14;
            label4.Text = "Адреса:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 406);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 15;
            label5.Text = "Телефон:";
            // 
            // listPhones
            // 
            listPhones.FormattingEnabled = true;
            listPhones.Location = new Point(186, 446);
            listPhones.Name = "listPhones";
            listPhones.Size = new Size(164, 84);
            listPhones.TabIndex = 16;
            // 
            // listContacts
            // 
            listContacts.FormattingEnabled = true;
            listContacts.Location = new Point(752, 406);
            listContacts.Name = "listContacts";
            listContacts.Size = new Size(366, 124);
            listContacts.TabIndex = 17;
            listContacts.Click += listContacts_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 467);
            label6.Name = "label6";
            label6.Size = new Size(141, 20);
            label6.TabIndex = 18;
            label6.Text = "Телефони контакту";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(639, 418);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 19;
            label7.Text = "Контакти";
            // 
            // picPhoto
            // 
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Location = new Point(639, 113);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(227, 111);
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPhoto.TabIndex = 20;
            picPhoto.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 632);
            Controls.Add(picPhoto);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(listContacts);
            Controls.Add(listPhones);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPhoneInput);
            Controls.Add(txtAddress);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(btnUploadPhoto);
            Controls.Add(btnAddPhone);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnAddPhone;
        private Button btnUploadPhoto;
        private TextBox txtLastName;
        private Label label1;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtAddress;
        private TextBox txtPhoneInput;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox listPhones;
        private ListBox listContacts;
        private Label label6;
        private Label label7;
        private PictureBox picPhoto;
    }
}
