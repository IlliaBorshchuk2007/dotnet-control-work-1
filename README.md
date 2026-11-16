# Control Work — Hotel Rooms API

Контрольна робота з ASP.NET Core у предметній області «Готель». Основна сутність —
`Room`, унікальне поле — номер кімнати.

## Реалізовано

- Clean Architecture: `Domain`, `Application`, `Infrastructure`, `Api`.
- Strongly typed `RoomId`, приватний конструктор, фабричний метод `Room.New`.
- CQRS через MediatR, `Either`/`Option` через LanguageExt.
- FluentValidation та єдиний validation pipeline.
- PostgreSQL + EF Core, окреме налаштування сутності й автоматичні міграції.
- REST API для перегляду, створення та оновлення кімнат.
- Swagger, CORS і правильні HTTP-коди `201`, `400`, `404`, `409`, `500`.

## Запуск

Потрібні .NET 10 SDK і запущений Docker Desktop.

```powershell
docker run --name hotel-postgres -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=hotel_db -d postgres:16-alpine
dotnet run --project src/Api
```

Swagger відкривається за адресою застосунку з додаванням `/swagger`.

## API

- `GET /rooms`
- `GET /rooms/{id}`
- `POST /rooms`
- `PUT /rooms/{id}`

Приклади запитів є у `src/Api/Api.http`.
