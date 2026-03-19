VertxTest - Transaction API
API desenvolvida em .NET 8 seguindo princípios de Clean Architecture, SOLID e Clean Code, 
com o objetivo de gerenciar transações financeiras e calcular o saldo diário.

Arquitetura
O projeto foi estruturado utilizando Clean Architecture, separando responsabilidades em camadas independentes.

src
 ├── API
 ├── Application
 ├── Domain
 └── Infra
 
Responsabilidades das camadas

API
Exposição da API REST, Controllers, Configuração de DI, Middlewares

Application
Casos de uso da aplicação, Regras de aplicação, Orquestração entre domínio e infra

Domain
Entidades de domínio, Regras de negócio, Interfaces de repositório

Infra
Implementações técnicas, Repositórios, Persistência de dados

Princípios Aplicados
SOLID, Single Responsibility Principle, Open/Closed Principle

Dependency Inversion Principle
Clean Code, Baixo acoplamento, Alta coesão, Código legível

Separação de responsabilidades
Fluxo da Aplicação, cliente envia uma requisição para a API, Controller chama um UseCase, UseCase executa a lógica da aplicação, UseCase utiliza um Repository Interface, Infrastructure fornece a implementação do Repository

Controller
    ↓
UseCase
    ↓
Repository Interface
    ↓
Infrastructure Implementation
Endpoints
Criar transação

POST
/transactions

Body:
{
  "amount": 100,
  "type": "Credit"
}

Tipos possíveis:
Credit
Debit
Obter saldo diário

GET
/balance/{date}

Exemplo:
/balance/2026-03-19

Retorno esperado:

{
  "balance": 150
}

Como Executar
Requisitos
.NET 8 SDK
Visual Studio 2022 ou superior

Clonar repositório
git clone <repository-url>
Restaurar dependências
dotnet restore
Executar aplicação
dotnet run --project src/VertxTest.API

ou executar pelo Visual Studio (F5).

Swagger
Após executar a aplicação, acessar:

https://localhost:<port>/swagger
Melhorias Futuras

Persistência em banco de dados
Testes de integração
Mensageria para comunicação entre serviços
Implementação de cache
Observabilidade e logs estruturados

Autor
Desenvolvido como parte de um desafio técnico utilizando boas práticas de arquitetura de software.

Arquitetura da Solução
A solução segue o padrão Clean Architecture, separando responsabilidades em camadas bem definidas.

flowchart LR

Client["Client / Swagger"]
API["API"]
APP["Application"]
DOMAIN["Domain"]
INFRA["Infra"]

Client --> API
API --> APP
APP --> DOMAIN
APP --> INFRA
INFRA --> DOMAIN

Fluxo de Criação de Transação
sequenceDiagram

participant Client
participant Controller
participant UseCase
participant Repository
participant Storage

Client->>Controller: POST /transactions
Controller->>UseCase: Execute(amount, type)
UseCase->>Repository: AddAsync(transaction)
Repository->>Storage: Persist transaction
Storage-->>Repository: OK
Repository-->>UseCase: OK
UseCase-->>Controller: Success
Controller-->>Client: HTTP 201

Estrutura do Projeto
VertxTest
│
├── VertxTest.sln
│
├── src
│   ├── API
│   │   ├── Controllers
│   │   ├── Program.cs
│   │   └── appsettings.json
│   │
│   ├── Application
│   │   └── UseCases
│   │
│   ├── Domain
│   │   ├── Entities
│   │   ├── Enums
│   │   └── Repositories
│   │
│   └── Infrastructure
│       └── Repositories
│
└── README.md

Decisões Arquiteturais
- Utilização de Clean Architecture para separação de responsabilidades
- Aplicação de princípios SOLID
- Repositórios definidos como interfaces no domínio
- Implementações técnicas isoladas na camada Infrastructure
- Casos de uso centralizados na camada Application

Testes
- O projeto possui testes unitários utilizando xUnit e Moq, garantindo o correto funcionamento das regras de negócio da aplicação.
- Os testes cobrem os principais casos de uso:
- Criação de transações
- Cálculo de saldo diário

Para executar os testes:
dotnet test

Resiliência e Tratamento de Erros
A API implementa um middleware global de tratamento de exceções, responsável por capturar erros não tratados durante o processamento das requisições.

Essa abordagem garante:
- Respostas padronizadas para erros da aplicação
- Evita exposição de detalhes internos do sistema
- Centraliza o tratamento de exceções em um único ponto

Exemplo de resposta em caso de erro:

{
  "message": "Internal server error"
}

Como a aplicação não depende de serviços externos, estratégias adicionais como Retry, Circuit Breaker ou Fallback não foram necessárias neste contexto.