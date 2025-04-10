CREATE DATABASE GerenciamentoTarefas

CREATE TABLE Tarefas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Descricao NVARCHAR(MAX) NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataConclusao DATETIME NULL,
    Status INT NOT NULL
);
