
CREATE DATABASE Financeiro;

CREATE TABLE Financeiro.dbo.categorias(
    id int IDENTITY(1,1) PRIMARY KEY,
    nome nvarchar(50),
);

CREATE TABLE Financeiro.dbo.contas(
    id int IDENTITY(1,1) PRIMARY KEY,
    descricao nvarchar(100) NULL,
    tipo CHAR NULL,
    valor Numeric NULL,
    data_nascimento datetime NULL,
    categoria_id int NULL,
    CONSTRAINT FK_Categoria_Contas FOREIGN KEY (categoria_id) REFERENCES Financeiro.dbo.categorias(id)
);

insert into Financeiro.dbo.contas(descricao, tipo, valor, data_vencimento, categoria_id) 
values ('Escola', 'R', 3333.00, '01-04-2020', 1);

Alter table contas alter column valor decimal;

EXEC sp_rename 'contas.data_nascimento', 'data_vencimento'; 

delete from Financeiro..contas where id = 1;

insert into Financeiro.dbo.categorias(nome) values ('Categoria A');
insert into Financeiro.dbo.categorias(nome) values ('Categoria B');
insert into Financeiro.dbo.categorias(nome) values ('Categoria C');
insert into Financeiro.dbo.categorias(nome) values ('Categoria D');
insert into Financeiro.dbo.categorias(nome) values ('Categoria E');
