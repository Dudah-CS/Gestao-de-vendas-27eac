CREATE DATABASE BDGESTAOVENDAS
GO
USE BDGESTAOVENDAS
GO
CREATE TABLE Categoria (
	CodCategoria	INT IDENTITY CONSTRAINT PKCategoria PRIMARY KEY,
	NomeCategoria	VARCHAR(100) NOT NULL
)
GO
CREATE TABLE Produto (
	CodProduto		INT IDENTITY CONSTRAINT PKProduto PRIMARY KEY,
	NomeProduto		VARCHAR(100) NOT NULL,
	DataValidade	DATE,
	Preco			MONEY NOT NULL,
	Quantidade		INT NOT NULL,
	Unidade			CHAR(2),
	CodCategoria	INT CONSTRAINT FKCategoria FOREIGN KEY REFERENCES Categoria (CodCategoria)	
)
GO
CREATE TABLE Cliente (
	CodCliente		INT IDENTITY CONSTRAINT PKCliente PRIMARY KEY,
	Nome			VARCHAR(100) NOT NULL,
	CPF				CHAR(11) NOT NULL CONSTRAINT UQCpf UNIQUE,
	Email			VARCHAR(100) NOT NULL CONSTRAINT UQEmail UNIQUE
)
GO
CREATE TABLE Usuario (
	CodUsuario 	INT IDENTITY CONSTRAINT PKUsuario PRIMARY KEY,
	Nome 		VARCHAR(50) NOT NULL,
	NomeUsuario VARCHAR(30) NOT NULL CONSTRAINT UQUsuario UNIQUE,
	Senha    	VARCHAR(40) NOT NULL
)
GO
CREATE TABLE Venda (
	CodVenda	INT IDENTITY CONSTRAINT PKVenda PRIMARY KEY,
	DataVenda	DATETIME NOT NULL,
	FormaPagto	VARCHAR(50) NOT NULL,
	CodCliente	INT CONSTRAINT FKCliente FOREIGN KEY REFERENCES Cliente (CodCliente),
	CodUsuario	INT CONSTRAINT FKUsuario FOREIGN KEY REFERENCES Usuario (CodUsuario)
)
GO
CREATE TABLE Itens (
	CodItem		INT IDENTITY CONSTRAINT PKItens PRIMARY KEY,
	CodProduto	INT CONSTRAINT FKProduto FOREIGN KEY REFERENCES Produto (CodProduto) NOT NULL,
	CodVenda	INT CONSTRAINT FKVenda FOREIGN KEY REFERENCES Venda (CodVenda) NOT NULL,
	Quantidade	INT NOT NULL,
	Preco		MONEY NOT NULL
)
GO

--Cadastro de Usuários
INSERT INTO Usuario VALUES ('Conta de Administrador','admin','admin')
GO

-- PROCEDIMENTO PARA CADASTRAR CLIENTE
create procedure spCadastrarCliente
@Nome varchar (50),
@CPF char (11),
@Email varchar (50)
as
INSERT INTO Cliente VALUES (@Nome, @CPF, @Email)
go

-- PROCEDIMENTO PARA ATUALIZAR CLIENTE 
create procedure spAtualizarCliente
@codCliente int,
@Nome varchar (50),
@CPF char (11),
@Email varchar (50)
as
UPDATE Cliente SET
Nome    = @Nome,
CPF     = @CPF,
Email   = @Email
WHERE CodCliente = @CodCliente
go

-- TRIGGER
-- GATILHO PARA BAIXAR O ESTOQUE
create trigger tgBaixarEstoque
on Itens     -- ONDE  
for insert 
as 
begin
	declare @CodProduto int,
	@Quantidade int
	select @CodProduto = CodProduto, @Quantidade = Quantidade
	From inserted
	update Produto set Quantidade = Quantidade - @Quantidade
	where CodProduto = @CodProduto
end 
go

-- PROCEDIMENTO CADASTRAR PRODUTOS --
create procedure spCadastraProduto
@NomeProduto VARCHAR(100),
@DataValidade date,
@Preco money,
@Quantidade int,
@Unidade char(2),
@CodCategoria int
as
INSERT INTO Produto ( NomeProduto, DataValidade,Preco,Quantidade,
Unidade, CodCategoria) VALUES (@NomeProduto,@DataValidade,@Preco,@Quantidade,@Unidade,@CodCategoria)
go 

-- PROCEDIMENTO ATUALIZAR PRODUTOS
create procedure spAtualizaProduto
@CodProduto int,
@NomeProduto VARCHAR(100),
@DataValidade date,
@Preco money,
@Quantidade int,
@Unidade char(2),
@CodCategoria int
as
UPDATE Produto SET NomeProduto = @NomeProduto,
DataValidade = @DataValidade, Preco = @Preco, Quantidade = @Quantidade,
Unidade = @Unidade, CodCategoria = @CodCategoria 
WHERE CodProduto = @CodProduto
go

-- PROCEDIMENTO EXCLUIR PRODUTOS
create procedure spDeletaProduto
@CodProduto int
as
DELETE FROM Produto WHERE CodProduto = @CodProduto
go

-- PROCEDIMENTO CONSULTAR 
create procedure spConsultar
as
set nocount on
SELECT CodProduto AS Código, NomeProduto AS Produto, 
DataValidade as Validade, Preco as Preço, Quantidade, Unidade, NomeCategoria AS Categoria
FROM Produto JOIN Categoria ON Categoria.CodCategoria = Produto.CodCategoria ORDER BY NomeProduto
go

-- PROCEDIMENTO VIZUALIZAR PRODUTOS BARATOS 
create procedure spBaratos
as
SELECT TOP 5 * FROM PRODUTO ORDER BY Preco DESC
go

-- PROCEDIMENTO FILTRAR POR NOME PRODUTO --
create procedure spFiltroNome
@NomeProduto VARCHAR(100)
as
SELECT CodProduto AS Código, NomeProduto AS Produto, 
DataValidade as Validade, Preco as Preço, Quantidade, Unidade, NomeCategoria AS Categoria
FROM Produto JOIN Categoria ON Categoria.CodCategoria = Produto.CodCategoria 
WHERE NomeProduto LIKE @NomeProduto ORDER BY NomeProduto
go

-- PROCEDIMENTO RETORNA O CODIGO DO PRODUTO--
create procedure spRetornar
@CodProduto int
as
SELECT * FROM Produto where CodProduto = @CodProduto 
go


-- TRIGGER PARA AUMENTAR O PREÇO EM 10%
create trigger tgAumantarPreco
on Produto    -- ONDE  
for insert 
as 
begin
	declare @CodProduto int,
	@Preco int
	select @CodProduto = CodProduto, @Preco = Preco
	From inserted
	update Produto set Preco = (Preco * 0.10) + Preco
	where CodProduto = @CodProduto
end 
go

-- VISUALIZAR AS TABELAS 


-- SELECT * FROM Cliente

-- SELECT * FROM Produto

-- SELECT * FROM Categoria

-- SELECT * FROM Itens

-- SELECT * FROM Usuario

-- SELECT * FROM Venda



