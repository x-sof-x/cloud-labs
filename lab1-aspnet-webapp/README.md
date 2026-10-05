# ☁️ ASP.NET Core Web App Deployment on Microsoft Azure
![.NET](https://img.shields.io/badge/.NET-8.0%2F9.0-512BD4?logo=dotnet&logoColor=white)
![Azure](https://img.shields.io/badge/Microsoft%20Azure-PaaS-0078D4?logo=microsoftazure&logoColor=white)
![SQL Database](https://img.shields.io/badge/Azure%20SQL-Serverless-CC292B?logo=microsoftsqlserver&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green.svg)

A production-ready demonstration of building and deploying an **ASP.NET Core Web Application** to **Microsoft Azure** cloud infrastructure using the **Platform as a Service (PaaS)** model, integrated with **Azure SQL Database** and **ASP.NET Core Identity**.

---

## 📌 Architecture & Tech Stack

* **Framework:** ASP.NET Core 8.0 / 9.0 (C#)
* **Authentication:** ASP.NET Core Identity (EF Core Migrations)
* **Cloud Hosting:** Azure App Service (F1 Free Tier / Windows)
* **Database:** Azure SQL Database (General Purpose Serverless / Auto-pause)
* **Region:** Poland Central
* **ORM:** Entity Framework Core (Code-First)
* **Development & Deployment:** Visual Studio Community / Publish Profile

---

## 🚀 Key Implementation Steps

### 1. Local Development & Identity Setup
* Initialized ASP.NET Core Web App with `Individual Accounts` authentication.
* Configured `ApplicationDbContext` and Entity Framework Core migrations (`CreateIdentitySchema`).
* Tested account registration, password hashing, and role validation locally against SQL Server LocalDB.

### 2. Cloud Infrastructure Provisioning (Azure Portal)
* **Azure SQL Server & Database:** Provisioned logical server and serverless database in the `Poland Central` region under Azure for Students. Configured serverless auto-pause to eliminate unnecessary resource consumption.
* **Firewall & Security:**
  * Added developer client IP rules to enable remote administrative access via Azure Query Editor and SQL Server Management Studio (SSMS).
  * Enabled `Allow Azure services and resources to access this server` rule for App Service interconnection.

### 3. Application Configuration & CI/CD Deployment
* Migrated connection strings from local environment to Azure SQL connection strings using ADO.NET / EF Core format in `appsettings.json`.
* Deployed application directly to **Azure App Service** using Visual Studio Publish wizard.
* Executed EF Core database migrations directly on the remote Azure SQL instance.

---

## 📸 Deployment Validation & Screenshots

### 🌐 Live Application on Azure App Service
The application was successfully deployed and verified under Azure App Service:
> *Deployed URL:* `https://myazureapp-sofia-abb3bhg5czhjb5hx.polandcentral-01.azurewebsites.net` *(active during evaluation period)*

<img width="1915" height="965" alt="Screenshot 2026-09-14 085610" src="https://github.com/user-attachments/assets/5c01c9d4-7f97-4cdc-870c-d378ebc13b28" />


---

### 🛡️ Azure SQL Database Networking & Firewall
Network configuration allowing specific developer IPs and internal Azure App Service endpoints:


<img width="1826" height="816" alt="Screenshot 2026-09-14 092622" src="https://github.com/user-attachments/assets/cb10839e-1718-4331-abfe-70f9daee0c56" />


---

### 🗄️ Database Verification (Query Editor)
Verification of authenticated records inside the `AspNetUsers` table via Azure SQL Query Editor:

```sql
SELECT Id, UserName, Email, EmailConfirmed 
FROM AspNetUsers;
```

<img width="1895" height="760" alt="Screenshot 2026-09-14 085943" src="https://github.com/user-attachments/assets/816a11a1-00ea-48f9-a7f9-d04557bd6908" />

## 💡 Key Engineering Takeaways

* **PaaS vs IaaS Benefits:** Utilizing Azure App Service and Serverless SQL eliminates the overhead of VM patching, OS maintenance, and manual network provisioning.
* **Cost Efficiency:** Automated database pause intervals guarantee minimal Azure for Students credit consumption during idle periods.
* **Zero-Downtime Data Migrations:** Entity Framework Core migrations automatically align production schemas without manual SQL schema scripts.

## ⚙️ Local Setup Instructions

1. Clone the repository:

```bash
git clone [https://github.com/x-sof-x/azure-aspnet-webapp.git](https://github.com/x-sof-x/azure-aspnet-webapp.git)
```

2. Update the connection string in `appsettings.Development.json` for your local SQL Server instance.

3. Apply migrations and run the application:

```bash
dotnet ef database update
dotnet run
```

## 🔐 Security & Configuration

Sensitive connection strings and credentials are excluded from source control using `.gitignore` and `appsettings.Development.json`. For production deployment, secrets and connection strings are injected via **Azure App Service Environment Variables (Configuration -> Connection strings)**:

* `ConnectionStrings__DefaultConnection`: Azure SQL Server connection string with encrypted transport (`Encrypt=True;TrustServerCertificate=False;`).
  
## 🛠️ Database Management (EF Core CLI)

To manage database schema changes locally or apply them to the remote database manually:

```bash
# Add a new migration
dotnet ef migrations add <MigrationName>

# Update remote database directly
dotnet ef database update --connection "<Your-Azure-SQL-Connection-String>"
```
## 👩‍💻 Author

Developed by **Sofia Kononova**  
* GitHub: [@x-sof-x](https://github.com/x-sof-x)
