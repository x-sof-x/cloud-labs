# Лабораторна робота 3: Телефонна книга на Azure Storage

Windows Forms застосунок (C#, .NET), який зберігає контакти в хмарі Microsoft Azure:

- **Azure Table Storage**: текстові дані контакту (прізвище, ім'я, по батькові, адреса, телефони, посилання на фото);
- **Azure Blob Storage**: файли фотографій.

## Можливості

- додавання, редагування й видалення контактів;
- кілька телефонів в одного контакту;
- завантаження фото контакту й показ його у формі;
- узгоджене видалення: спочатку фото з Blob, потім запис із таблиці;
- оновлення списку з хмари кнопкою «Оновити».

## Скріншоти

### Головна форма

![Головна форма застосунку](screenshots/form.png)

### Таблиця `contacts` в Azure Table Storage

![Таблиця contacts](screenshots/table.png)

### Контейнер `contactphotos` в Azure Blob Storage

![Контейнер contactphotos](screenshots/blob.png)

## Як це влаштовано

| Частина | Де лежить | Що робить |
|---|---|---|
| Інтерфейс | `Form1.cs`, `Form1.Designer.cs` | поля, кнопки, обробники подій |
| Робота з таблицею | `Services/ContactTableService.cs` | додати, прочитати, оновити, видалити запис |
| Робота з Blob | `Services/ContactPhotoService.cs` | завантажити й видалити фото |
| Модель даних | `Models/ContactEntity.cs` | сутність контакту для Table Storage |

Зв'язок між службами: GUID контакту є і `RowKey` запису в таблиці, і початком імені файлу в Blob. Крім того, URL фото зберігається в полі `PhotoUrl`. `PartitionKey` це прізвище контакту.

### Видалення контакту

1. Видаляється фото з Blob Storage за GUID контакту.
2. Видаляється запис із Table Storage за парою `PartitionKey` + `RowKey`.

Таким чином у таблиці не лишається запису, що вказує на неіснуюче фото.

## NuGet-пакети

- `Azure.Data.Tables`: клас `TableClient`, інтерфейс `ITableEntity`
- `Azure.Storage.Blobs`: класи `BlobServiceClient`, `BlobContainerClient`, `BlobClient`

## Вимоги

- Windows, Visual Studio 2022 з робочим навантаженням «.NET desktop development»
- Обліковий запис Azure (підійде безкоштовний або Azure for Students) і Storage account

## Налаштування Azure

1. В Azure Portal створи **Storage account** (Standard, будь-який регіон).
2. Відкрий **Security + networking → Access keys** і скопіюй **Connection string** для key1.
3. Таблиця `contacts` і контейнер `contactphotos` створюються програмою автоматично при першому запуску.
4. Щоб фото відображалися у формі, контейнер має бути доступним для читання:
   - у Storage account → **Configuration** увімкни **Allow Blob anonymous access**;
   - відкрий контейнер `contactphotos` → **Change access level** → **Blob (anonymous read access for blobs only)**.

## Рядок підключення

Рядок підключення містить ключ доступу, тому **його не зберігають у коді та не додають у репозиторій**. Програма читає його зі змінної середовища `AZURE_STORAGE_CONNECTION`.

У PowerShell виконай (підстав свій рядок між лапки):

```powershell
setx AZURE_STORAGE_CONNECTION "DefaultEndpointsProtocol=https;AccountName=...;AccountKey=...;EndpointSuffix=core.windows.net"
```

Після цього **повністю закрий і знову відкрий Visual Studio**, інакше вона не побачить нову змінну.
Якщо змінну не задано, програма покаже повідомлення і завершиться.

## Запуск

1. Клонуй репозиторій:
   ```bash
   git clone https://github.com/x-sof-x/azure-aspnet-webapp.git
   ```
2. Відкрий файл рішення `lab3-azure-storage/labCloud№3.sln` у Visual Studio.
3. Задай змінну `AZURE_STORAGE_CONNECTION` (див. вище).
4. Натисни **F5**. NuGet-пакети відновляться автоматично.
5. Заповни прізвище й ім'я, за бажання додай телефони та фото й натисни «Додати».

## Перевірка результату

Дані можна подивитися в **Azure Storage Explorer** або в Azure Portal → Storage browser: у таблиці `contacts` будуть записи, а в контейнері `contactphotos` будуть файли фото.

## Обмеження

- Прізвище є `PartitionKey`, тому його не можна змінити після створення контакту.
- Телефони зберігаються одним рядком через `;`, тож цей символ не можна використовувати в номері.
- Між Table Storage і Blob Storage немає транзакцій: узгодженість забезпечує сам застосунок порядком операцій.

## Після здачі

Щоб не платити й не лишати відкритих ключів, видали resource group із ресурсами в Azure Portal.

## Автор

Sofia Kononova, GitHub: [@x-sof-x](https://github.com/x-sof-x)