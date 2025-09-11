# 🎮 Gaming Platform Microservices

![.NET](https://img.shields.io/badge/.NET-Core%208-blue)
![Architecture](https://img.shields.io/badge/Architecture-Hexagonal-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)

## Overview

This solution contains backend microservices for a gaming platform, implemented in .NET 8 following hexagonal architecture. Each service is structured into Domain, Application, Infrastructure, and API layers.

---

## 🛠 Microservices

| Service | Responsibility |
|---|---|
| `UserService` | User registration and profiles. Publishes domain events. |
| `PaymentService` | Wallets and payments. Consumes user events. |
| `GameService` | Placeholder (catalog/config to come). |
| `BetService` | Placeholder (bets/results to come). |

---

## 🏗 Architecture Highlights

- **Hexagonal architecture** ensures separation of concerns.  
- **DTOs & Application Services** provide clean API boundaries.  
- **Repositories & EF Core DbContext** handle persistence.  
- **Dependency Injection** for all services and infrastructure.  
- **MediatR** for commands/requests in the Application layer.
- **Shared contracts** project for cross-service event types.
- **Kafka-based messaging** between services (e.g., `UserService` → `PaymentService` via `user-created` topic).
- **Hosted background services** for Kafka consumers in API layer.
- **Configuration-driven** messaging (`Kafka:BootstrapServers`, topics).
- Designed for **scalability**, **testability**, and **multi-brand support**.

---

## 🚀 Getting Started

1) Configure connection strings in each API’s `appsettings.Development.json`.

2) Start Kafka (see next section), then run migrations for services with databases.

Generic command:

```bash
dotnet ef database update --project [Service].Infrastructure --startup-project [Service].Api --context [ContextName]
```

Examples:

```bash
# UserService
dotnet ef database update --project UserService.Infrastructure --startup-project UserService.Api --context UserDbContext

# PaymentService (two DbContexts share the same connection)
dotnet ef database update --project PaymentService.Infrastructure --startup-project PaymentService.Api --context PaymentDbContext
dotnet ef database update --project PaymentService.Infrastructure --startup-project PaymentService.Api --context WalletDbContext
```

3) Run the APIs (separate terminals):

```bash
# From repo root
dotnet run --project UserService.Api
dotnet run --project PaymentService.Api
```

---

## 📡 Messaging with Kafka

This solution uses Kafka to communicate between `UserService` and `PaymentService`.

- Topic: `user-created`
- Producer: `UserService` publishes `UserCreatedEvent`
- Consumer: `PaymentService` hosted service subscribes with group `payment-service-group`
- Bootstrap servers key: `Kafka:BootstrapServers`

### Start Kafka via Docker

A minimal Kafka/Zookeeper stack is provided.

```bash
# From repo root (PowerShell)
docker compose -f docker-compose.kafka.yml up -d
```

The broker is exposed at `localhost:9092`.

Optionally, create the topic explicitly (Kafka may auto-create it depending on broker settings):

```bash
# Determine the Kafka container name first (e.g., gamingplatform-kafka-1)
docker ps
# Then create the topic
docker exec -it <kafka_container_name> kafka-topics \
  --bootstrap-server localhost:9092 \
  --create --topic user-created --partitions 1 --replication-factor 1
```

### Configuration

Set Kafka bootstrap servers in each API (already in the development settings):

```json
{
  "Kafka": {
    "BootstrapServers": "localhost:9092"
  }
}
```

- `UserService.Application` registers a Kafka producer (`IEventPublisher`) using `Kafka:BootstrapServers`.
- `PaymentService.Api` registers `UserCreatedConsumerHostedService` and reads `Kafka:BootstrapServers`.

---

## 🔄 Event Flow (User → Payment)

- `POST /api/user/register` (UserService) registers a user
- After success, `UserService` publishes `UserCreatedEvent` to topic `user-created`
- `PaymentService` consumes the event and issues a `CreateWalletCommand` for the new user

Key components:
- `Shared.Contracts/Events/UserCreatedEvent`
- `UserService.Application.Services.KafkaEventPublisher`
- `PaymentService.Api.HostedServices.UserCreatedConsumerHostedService`

---

## 📚 Useful Endpoints

- `UserService.Api`
  - `POST /api/user/register`
  - `GET /api/user/get-users`
  - `GET /api/user/get-user-by-id/{id}`
- `PaymentService.Api`
  - Swagger UI available in Development

---

## 🧰 Troubleshooting

- Cannot connect to broker: ensure Docker stack is running and port `9092` is free.
- Consumer not receiving messages:
  - Confirm topic `user-created` exists
  - Verify both services point to the same `Kafka:BootstrapServers`
  - Use a fresh consumer `GroupId` and `AutoOffsetReset: Earliest` during local testing
- Local dev is PLAINTEXT; ensure the advertised listener matches `PLAINTEXT://localhost:9092` (provided in compose file).

---

## 🗺 Roadmap

- Implement `GameService` and `BetService` domain/application layers
- Add integration tests for event publishing/consumption
- Add observability (structured logs, health checks)
