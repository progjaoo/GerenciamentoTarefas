# 📌 Gerenciamento de Tarefas - Backend (.NET 8 API)

Este é o backend de uma aplicação de gerenciamento de tarefas, desenvolvido em **ASP.NET Core 8** utilizando **CQRS com MediatR**, **FluentValidation**, e **EF Core com SQL Server**. A API fornece endpoints para criar, listar, editar e deletar tarefas, finalizar tarefas.

---

## ✅ Tecnologias Utilizadas

- ASP.NET Core 8
- MediatR para usar o (CQRS) para separação das responsabilidades
- Entity Framework Core
- SQL Server
- FluentValidation
- Swagger (OpenAPI)

---

## 🧱 Estrutura do Projeto

- `Controllers/` - Endpoints da API
- `Application/` - Commands, Queries e Handlers
- `Domain/` - Entidades e interfaces
- `Infrastructure/` - Repositórios e DbContext

---

## ⚙️ Como Rodar o Projeto Localmente
- Na classe program.cs troque a linha onde está policy.WithOrigins("seu_localhost_do_front")
- Nesse repositório está o script do banco script_bd_ToDoList, rode-o em seu SSMS ou qualquer gerenciador de banco de dados

### 1. Clone o repositório

```bash
git clone https://github.com/progjaoo/GerenciamentoTarefas.git
