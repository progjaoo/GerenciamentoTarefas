# 📌 Gerenciamento de Tarefas - Backend (.NET 8 API)

Este é o backend de uma aplicação de gerenciamento de tarefas, desenvolvido em **ASP.NET Core 8** utilizando **CQRS com MediatR**, **FluentValidation**, e **EF Core com SQL Server**. A API fornece endpoints para criar, listar, editar e deletar tarefas, finalizar tarefas.

---

## ✅ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core para persistência de dados no SQL Server
- Repository Patterns (Padrão Repositório)
- CQRS para separação das responsabilidades do Sistema aplicando o Design Pattern Mediator
- Validação de API (fluentValidation)
- Middlewares de validação

---

## 🧱 Estrutura do Projeto

- `API/` - Endpoints da API
- `Application/` - Commands, Queries e Handlers
- `Domain/` - Entidades e interfaces
- `Infrastructure/` - Repositórios e DbContext

---

## ⚙️ Como Rodar o Projeto Localmente
- Nesse repositório está o script do banco script_bd_ToDoList, rode-o em seu SSMS ou qualquer gerenciador de banco de dados

### 1. Clone o repositório

```bash
git clone https://github.com/progjaoo/GerenciamentoTarefas.git
```
# 📝 To-Do List - Frontend React

Este é o projeto **Frontend** de uma aplicação de gerenciamento de tarefas (To-Do List), desenvolvido com **React + Vite**. Ele consome uma **API ASP.NET Core** para realizar operações de criação, edição, exclusão e finalização de tarefas.

---

## 🚀 Funcionalidades

- ✅ Criar tarefas com título e descrição
- 📝 Editar tarefas existentes
- 📌 Filtrar tarefas por status: Pendente, Em Progresso e Concluída
- 📅 Definir data de conclusão
- 🗑️ Excluir tarefas com confirmação
- ✔️ Marcar tarefas como concluídas com alerta de sucesso

---

## 🛠 Tecnologias Utilizadas

- [React](https://reactjs.org/)
- [Vite](https://vitejs.dev/)
- [JavaScript](https://developer.mozilla.org/pt-BR/docs/Web/JavaScript)
- [Axios](https://axios-http.com/) para consumo da API
- [CSS Modules](https://github.com/css-modules/css-modules) para estilização

---

## ⚙️ Como rodar o projeto localmente

### Pré-requisitos

- Node.js instalado (versão recomendada: 18+)
- Git instalado
- npm install
- npm run dev

src/
├── App.jsx              # Componente principal
├── App.css              # Estilizações globais
├── services/
│   └── tarefaService.js # Funções para consumo da API

- Conforme está na estrutura entre e troque pro ENDPOINT LOCAL que estiver rodando o back-end:
  - src/services/tarefaService.js > const API_URL = 'https://localhost:44300/api/tarefa'

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio



