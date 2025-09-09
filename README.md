# 🎮 Gaming Platform Microservices

![.NET](https://img.shields.io/badge/.NET-Core%208-blue)
![Architecture](https://img.shields.io/badge/Architecture-Hexagonal-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)

## Overview

This solution contains multiple backend **microservices** for a gaming platform, implemented in **.NET Core 8** following **hexagonal architecture** principles. Each microservice has layers for **Domain**, **Application**, **Infrastructure**, and **API**.

---

## 🛠 Microservices

| Service          | Responsibility |
|-----------------|----------------|
| **UserService**   | User registration, authentication, and profiles |
| **PaymentService**| Payments, transactions, multi-provider integration |
| **GameService**   | Game catalog, configuration, and management |
| **BetService**    | Bets, results, and real-time game interactions |

---

## 🏗 Architecture Highlights

- **Hexagonal architecture** ensures separation of concerns.  
- **DTOs & Application Services** provide clean API boundaries.  
- **Repositories & EF Core DbContext** handle persistence.  
- **Dependency Injection** for all services and infrastructure.  
- Designed for **scalability**, **testability**, and **multi-brand support**.

---

## 🚀 Getting Started

1. Configure connection strings in each service’s `appsettings.json`.  
2. Apply EF Core migrations:

```bash
dotnet ef database update --project [Service].Infrastructure
