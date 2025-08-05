# eCommerce Microservices

A microservices-based eCommerce platform built with .NET 9.

## Architecture

This solution follows a clean architecture pattern with:

- **Core Layer**: Contains business logic, entities, and interfaces
- **Infrastructure Layer**: Implements repositories and external services
- **API Layer**: Exposes RESTful endpoints and handles HTTP requests

## Authentication

The platform uses JWT (JSON Web Token) authentication:

- The Auth microservice handles user registration and login
- JWT tokens are issued to authenticated users
- Other microservices validate these tokens without direct dependency on the Auth service

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server (or your database of choice)

### Configuration

In each microservice's `appsettings.json`, ensure the JWT settings are identical:
