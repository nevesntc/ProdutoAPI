# ProdutoAPI — CRUD de Produtos com ASP.NET Core + SQL Server

API REST desenvolvida em **ASP.NET Core** para cadastro e gerenciamento de produtos, utilizando arquitetura em camadas, Entity Framework Core e SQL Server.

O projeto foi criado com o objetivo de praticar conceitos usados em aplicações web corporativas, como Controllers, Services, Repositories, DTOs, Models/Entities, Entity Framework, SQL Server e endpoints REST.

---

## Tecnologias utilizadas

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger
* Injeção de Dependência
* RESTful APIs

---

## Funcionalidades

A API permite:

* Listar produtos
* Buscar produto por ID
* Cadastrar produto
* Atualizar produto
* Remover/desativar produto
* Persistir dados no SQL Server

---

## Estrutura do projeto

```text
ProdutoAPI/
│
├── Controllers/
│   └── ProdutosController.cs
│
├── DTOs/
│   ├── CreateProdutoRequestDTO.cs
│   ├── UpdateProdutoRequestDTO.cs
│   └── ProdutoResponseDTO.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Models/
│   └── Produto.cs
│
├── Repositories/
│   ├── IProdutoRepository.cs
│   └── ProdutoRepository.cs
│
├── Services/
│   ├── IProdutoService.cs
│   └── ProdutoService.cs
│
├── Program.cs
├── appsettings.json
└── ProdutoAPI.csproj
```

---

## Arquitetura

O projeto segue uma separação simples em camadas:

```text
Controller → Service → Repository → Entity Framework → SQL Server
```

### Controller

Responsável por receber as requisições HTTP e devolver respostas como:

* `200 OK`
* `201 Created`
* `204 No Content`
* `400 Bad Request`
* `404 Not Found`

### Service

Responsável por concentrar o fluxo da aplicação e regras de negócio.

### Repository

Responsável por isolar o acesso aos dados.

### Model/Entity

Representa o objeto principal do domínio da aplicação.

### DTOs

Responsáveis por controlar os dados que entram e saem da API.

---

## Entidade Produto

A entidade principal do sistema é `Produto`.

Campos principais:

```text
Id
Nome
Descricao
Preco
QuantidadeEstoque
Ativo
DataCadastro
```

A entidade também possui métodos para atualizar dados e desativar o produto.

---

## Endpoints da API

| Método | Rota                 | Descrição                      |
| ------ | -------------------- | ------------------------------ |
| GET    | `/api/produtos`      | Lista todos os produtos ativos |
| GET    | `/api/produtos/{id}` | Busca um produto por ID        |
| POST   | `/api/produtos`      | Cadastra um novo produto       |
| PUT    | `/api/produtos/{id}` | Atualiza um produto existente  |
| DELETE | `/api/produtos/{id}` | Remove/desativa um produto     |

---

## Exemplos de requisição

### Criar produto

```http
POST /api/produtos
```

Body:

```json
{
  "nome": "Notebook",
  "descricao": "Notebook para desenvolvimento",
  "preco": 3500,
  "quantidadeEstoque": 10
}
```

Resposta esperada:

```http
201 Created
```

---

### Listar produtos

```http
GET /api/produtos
```

Resposta esperada:

```http
200 OK
```

---

### Buscar produto por ID

```http
GET /api/produtos/1
```

Resposta esperada:

```http
200 OK
```

Caso o produto não exista:

```http
404 Not Found
```

---

### Atualizar produto

```http
PUT /api/produtos/1
```

Body:

```json
{
  "nome": "Notebook Dell",
  "descricao": "Notebook atualizado",
  "preco": 4200,
  "quantidadeEstoque": 5
}
```

Resposta esperada:

```http
204 No Content
```

---

### Remover/desativar produto

```http
DELETE /api/produtos/1
```

Resposta esperada:

```http
204 No Content
```

---

## Configuração do banco de dados

A conexão com o SQL Server fica no arquivo `appsettings.json`.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ProdutoDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Caso utilize SQL Server Express:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ProdutoDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

## Como rodar o projeto

### 1. Clonar o repositório

```bash
git clone <url-do-repositorio>
```

### 2. Entrar na pasta do projeto

```bash
cd ProdutoAPI
```

### 3. Restaurar dependências

```bash
dotnet restore
```

### 4. Aplicar migrations no banco

```bash
dotnet ef database update
```

### 5. Rodar a API

```bash
dotnet run
```

### 6. Acessar o Swagger

Após rodar o projeto, acesse a URL exibida no terminal.

Exemplo:

```text
https://localhost:7230/swagger
```

---

## Comandos úteis do Entity Framework

Criar uma migration:

```bash
dotnet ef migrations add NomeDaMigration
```

Aplicar migrations no banco:

```bash
dotnet ef database update
```

Remover última migration ainda não aplicada:

```bash
dotnet ef migrations remove
```

---

## Conceitos praticados

Neste projeto foram praticados os seguintes conceitos:

* Criação de API REST com ASP.NET Core
* Separação em camadas
* Controllers
* Services
* Repositories
* DTOs de entrada e saída
* Models/Entities
* Entity Framework Core
* DbContext
* Migrations
* SQL Server
* Injeção de Dependência
* Swagger para testes
* Status HTTP

---

## Fluxo da aplicação

Fluxo básico de criação de um produto:

```text
Cliente envia JSON
↓
Controller recebe a requisição
↓
Service aplica o fluxo/regra de negócio
↓
Repository salva usando Entity Framework
↓
SQL Server persiste os dados
↓
API retorna um Response DTO
```

---

## Objetivo de estudo

Este projeto foi desenvolvido como prática para consolidar conhecimentos em desenvolvimento backend com **C# e ASP.NET Core**, simulando uma estrutura comum em aplicações corporativas.

A proposta foi entender como uma aplicação Web API se organiza internamente, desde a entrada da requisição até a persistência no banco de dados.
