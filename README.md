📦 E-Commerce Microservices (.NET 6 + RabbitMQ + JWT)

Este projeto simula uma plataforma de e-commerce com arquitetura de microserviços, desenvolvida em .NET 6. Ele é composto por três serviços principais:

🧊 InventoryService: Gerencia o cadastro e controle de estoque de produtos.

🛒 SalesService: Gerencia pedidos de venda e notifica o estoque.

🌐 ApiGateway: Centraliza o acesso via Ocelot e roteia as requisições para os microserviços corretos.

🧱 Arquitetura


[Client] → [API Gateway] → [InventoryService] → [SalesService] ↔ [RabbitMQ] 

Comunicação assíncrona entre microserviços via RabbitMQ

Autenticação via JWT

Banco de dados em memória (pode ser substituído por SQL Server)

Docker para orquestração

🚀 Como Executar

1. Clone o repositório


git clone
 https://github.com/seu-usuario/ecommerce-microservices.git cd ecommerce-microservices 


2. Execute com Docker


docker-compose up --build 


3. Acesse os serviços

API Gateway: http://localhost:5000

RabbitMQ Dashboard: http://localhost:15672 (Usuário: guest, Senha: guest)


🔐 Autenticação JWT

Este projeto usa autenticação via JWT com uma chave fictícia "super-secret-key".


⚠️ O token é gerado manualmente ou pode ser simulado. Para produção, recomenda-se implementar um serviço de autenticação real.

Para testar os endpoints protegidos, adicione o token no header:

Authorization: Bearer <seu-token-jwt>


📦 Endpoints

InventoryService

POST /products → Cadastrar produto

GET /products → Listar produtos

PUT /products/{id}/decrease → Reduzir estoque

SalesService
POST /orders → Criar pedido (valida estoque)

GET /orders → Listar pedidos


🧪 Testes

Você pode adicionar testes unitários com xUnit em projetos separados:

InventoryService.Tests

SalesService.Tests


📈 Monitoramento


Logs são exibidos no console usando o sistema padrão de logging do .NET. Para produção, recomenda-se usar:

Serilog

Seq

Application Insights


🧩 Escalabilidade


A arquitetura permite adicionar novos microserviços facilmente, como:

Serviço de pagamento

Serviço de envio

Serviço de recomendação

Basta criar o novo serviço e adicionar uma rota no ocelot.json.


🛠️ Tecnologias Utilizadas

Tecnologia	:

.NET 6	

Finalidade: 

Framework principal para APIs

Tecnologia	:

C#
Finalidade:

Linguagem de programação

Tecnologia:

Entity Framework

Finalidade:

ORM para persistência de dados

Tecnologia:

RabbitMQ	

Finalidade:

Comunicação assíncrona entre microserviços

Tecnologia:

JWT

Finalidade:

Autenticação segura

Tecnologia:

Ocelot	

Finalidade:

API Gateway para roteamento

Tecnologia:

Docker	

Finalidade:

Containerização e orquestração

Tecnologia:

xUnit	

Finalidade:

Testes unitários

Tecnologia:

Serilog	

Finalidade:

Monitoramento e logs

🤝 Contribuições
Pull requests são bem-vindos! Para grandes mudanças, abra uma issue primeiro para discutir o que você gostaria de alterar.



📄 Licença
Este projeto é livre para uso educacional e comercial. Sinta-se à vontade para modificar e expandir.


