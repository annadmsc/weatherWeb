# 🌦 Weather API Gateway

Este projeto é um **API Gateway** desenvolvido em **ASP.NET Core**, responsável por consumir uma API externa de clima, aplicar **autenticação via API Key**, e disponibilizar os dados para um **frontend em React + Vite**.

O objetivo do projeto é demonstrar **integração backend/frontend**, **boas práticas de configuração**, **uso de middleware** e **segurança básica de APIs**.

---

## Arquitetura

### Backend

- ASP.NET Core Web API
- Middleware para validação de API Key
- Consumo de API externa de clima
- Swagger para documentação
- Configuração via variáveis de ambiente

### Frontend

- React + Vite
- Consumo da API Gateway
- Uso de variáveis de ambiente
- Interface simples para busca de clima por cidade

---

## 📁 Estrutura do Projeto

```text
.
├── WeatherApiGateway
│   ├── Controllers
│   ├── Services
│   ├── Middleware
│   ├── DTO
│   ├── Program.cs
│   ├── appsettings.json
│   └── .env.example
│
├── frontend
│   ├── src
│   ├── public
│   ├── App.jsx
│   └── .env.example
│
└── README.md
```

## Autenticaçaõ

Todas as requisições para a API exigem o header:

```code
X-API-Key: sua_api_key
```

_A validação é feita por um middleware customizado no backend._

## Como rodar o projeto?

### Backend

```
cd WeatherApiGateway
cp .env.example .env
dotnet restore
dotnet run

```

A API ficará disponível em:

http://localhost:5075

Swagger:

http://localhost:5075/swagger

### FrontEnd

```
cd weather-frontend
cp .env.example .env
npm install
npm run dev
```

A aplicação estará disponível em:

http://localhost:5173

## 📌 Funcionalidades

🔎 Busca de clima por cidade

🔐 Autenticação via API Key

🔄 API Gateway para serviço externo

🧩 Integração frontend e backend

📄 Documentação com Swagger

## Tecnologias Utilizadas

ASP.NET Core

C#

React

Vite

Swagger / OpenAPI

Fetch API

Variáveis de ambiente (.env)

---

Ana Damasceno Jan/2026

Para contato:
aclaradamas@gmail.com
tiktok:@dmsc365
