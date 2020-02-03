CREATE DATABASE CSharpDotNet;

CREATE TABLE CSharpDotNet.dbo.clientes(
    id int IDENTITY(1,1) PRIMARY KEY,
    nome nvarchar(50),
    email nvarchar(100),
);

-- drop TABLE CSharpDotNet.dbo.clientes;

insert into CSharpDotNet.dbo.clientes(nome, email) values ('Cleber', 'oclebersantos@gmail.com');
insert into CSharpDotNet.dbo.clientes(nome, email) values ('Fulano da Silva', 'fulano@gmail.com');
insert into CSharpDotNet.dbo.clientes(nome, email) values ('Benedito Oliveira', 'benedito@gmail.com');
insert into CSharpDotNet.dbo.clientes(nome, email) values ('Beltrano da Costa', 'beltrano@gmail.com');