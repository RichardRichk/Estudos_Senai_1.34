--COMANDO PARA CRIAR BD
CREATE DATABASE Ex_1_1CR  

--COMANDO PARA USAR DB
USE Ex_1_1CR

--COMANDO PARA CRIAR AS TABELAS
CREATE TABLE PESSOAS
(
	IdPessoa INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	CNH VARCHAR(11) NOT NULL                                                                                                                                                                                                                                                                                                                                       
)

CREATE TABLE Email
(
	IdEmail INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoas(IdPessoa),
	Endereco VARCHAR(50) NOT NULL
)

CREATE TABLE Telefone
(
	IdTelefone INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoas(IdPessoa),
	Numero VARCHAR(30) NOT NULL
)