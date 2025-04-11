CREATE DATABASE GerenciamentoTarefas

USE GerenciamentoTarefas

CREATE TABLE Tarefas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(300) NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataConclusao DATETIME NULL,
    Status INT NOT NULL
);
