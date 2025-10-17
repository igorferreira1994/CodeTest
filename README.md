# CodeTest API – CNAB File Processor

This ASP.NET Core API processes CNAB files following the Febraban layout. It supports file uploads, data validation, storage in SQL Server, and querying store balances. Swagger UI is included for API documentation, and a Razor page is available for uploading files via a web form.

## 🚀 Features

- Upload CNAB files via web form or local file path
- Validates line length and field formatting (80 characters per line)
- Parses and stores transactions in SQL Server
- Calculates and returns store balances
- Swagger UI for testing endpoints
- Razor view for user-friendly file upload

## 🧰 Technologies

- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- Swagger UI
- Razor Pages (MVC Views)

## 🧪 API Endpoints

| Method | Endpoint               | Description                        |
|--------|------------------------|------------------------------------|
| POST   | `/cnab/upload`         | Upload CNAB file via form          |
| POST   | `/cnab/process-local`  | Process CNAB file from local path  |
| GET    | `/cnab/stores`         | Get store balances                 |
| GET    | `/upload-cnab`         | Razor page for file upload         |

## 🌐 How to Access

- **Swagger UI**: (http://localhost:5000/swagger)
- **Upload Form (Razor Page)**: (http://localhost:5000/upload-cnab)

> You can manually open the upload form in your browser by visiting `/upload-cnab`.

## 🐳 Docker Setup

Use the `docker-compose.yml` below to run the API and SQL Server locally.

## 🛠️ Running Locally

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run migrations if needed
4. Start the project via Visual Studio or CLI

## 🐳 `docker-compose.yml`

```yaml
version: '3.8'

services:
  api:
    build:
      context: .
      dockerfile: Api/Dockerfile
    ports:
      - "5000:80"
    depends_on:
      - db
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Server=db;Database=CodeTestDb;User=sa;Password=Your_password123;

  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: sqlserver
    ports:
      - "1433:1433"
    environment:
      SA_PASSWORD: "Your_password123"
      ACCEPT_EULA: "Y"
    volumes:
      - sqlvolume:/var/opt/mssql

volumes:
  sqlvolume:
