# News Telegram Bot

This repository contains a News Telegram Bot application with a C# backend and MSSQL as DB.


## Getting Started

### Docker-compose way to test application

1. In NewsTelegramBot create file appsettings.json and type simillar data:
{
    "Database": {
      "ConnectionString": "Server=localhost,1433;Database=ProjectA;User Id=SA;Password=Password@1;TrustServerCertificate=True"
    },
    "Telegram": {
      "BotToken": "YOUR-BOT-TOKEN"
    }
}

2. Navigate to directory which contains docker-compose.yaml and Dockerfile.

3. Type command to build image:
    docker-compose build

4. Type command to run docker-compose:
    docker-compose up

5. Add migration and update database OR just update database by existed migration in repo:
    dotnet ef migrations add MigrationName -p Infrastructure -s NewsTelegramBot
    dotnet ef database update -p Infrastructure -s NewsTelegramBot

6. After those steps you can check your application.

