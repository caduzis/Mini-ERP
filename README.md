# Mini-ERP
Um sistema de backend (API RESTful) desenvolvido para gerenciar operações básicas de um Mini-ERP, como o registro de clientes, produtos e o processamento de vendas complexas.

O foco deste projeto é a aplicação de boas práticas de engenharia de software, separação de responsabilidades e manipulação eficiente de dados relacionais.

### 🛠️ Tecnologias Utilizadas
C# / .NET - Framework principal

ASP.NET Core Web API - Construção dos endpoints REST

Entity Framework Core (EF Core) - ORM para manipulação do banco de dados

SQLite - Banco de dados relacional leve

Swagger (OpenAPI) - Interface interativa para documentação e testes da API

xUnit & Moq - Testes de unidade e simulação de dependências

### ✨ Principais Funcionalidades e Arquitetura
Arquitetura em Camadas (N-Tier): Divisão rigorosa entre Controllers (Apresentação), Services (Regras de Negócio) e Repositories (Acesso a Dados).

Injeção de Dependência: Desacoplamento de classes utilizando o contêiner nativo do .NET.

Graph Insertion (Inserção em Cascata): Capacidade de salvar uma Venda e seus respectivos Itens de uma só vez em uma única transação no banco de dados.

Eager Loading: Consultas otimizadas utilizando .Include() para retornar dados aninhados (Vendas + Itens) de forma eficiente nos endpoints GET.

Data Seeding: População automática de dados iniciais (clientes e produtos) ao criar o banco de dados.

## 🚧 Próximos Passos
[ ] Melhorar o tratamento global de erros e exceções.

[ ] Implementar sistema de Autenticação e Autorização.
