# 🛍️ E-Commerce Microservices Architecture (.NET 6 + RabbitMQ + JWT)

Este projeto simula uma plataforma de e-commerce com arquitetura de microserviços, desenvolvida em .NET 6. Ele é composto por três serviços principais:

- **InventoryService**: Gerencia o cadastro e controle de estoque de produtos.
- **SalesService**: Gerencia pedidos de venda e notifica o estoque.
- **ApiGateway**: Centraliza o acesso via Ocelot e roteia as requisições para os microserviços corretos.

---

## 🧱 Arquitetura

```plaintex[Client] → [API Gateway] → [InventoryService]
                          → [SalesService]
                          ↔ [RabbitMQ]

Comunicação entre microserviços via RabbitMQ (assíncrona)

Autenticação via JWT

Banco de dados em memória (pode ser substituído por SQL Server)

Docker para orquestração

orquestração

🚀 Como Executar
1. Clone o repositório

git clone https://github.com/seu-usuario/ecommerce-microservices.git
cd ecommerce-microservices

2. Execute com Docker

docker-compose up --build


3. Acesse os serviços:

API Gateway: http://localhost:5000

RabbitMQ Dashboard: http://localhost:15672 (user/pass: guest)

🧪 Testes
Testes unitários com xUnit podem ser adicionados em InventoryService.Tests e SalesService.Tests.


🔐 Autenticação
JWT fictício gerado com chave "super-secret-key"

Adicione o token no header: Authorization: Bearer <token>

Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...


