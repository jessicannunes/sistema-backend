-- Create data base
CREATE DATABASE progamacao_do_zero;

-- USE - active the data base on MYSQL
USE programacao_do_zero;

-- create table the user
CREATE TABLE usuario(
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150)NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY(id)

);

-- create table adress
CREATE TABLE endereco(
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estador VARCHAR(2) NOT NULL,
    PRIMARY KEY(id)
);

-- altering adress table
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- conection tables throw primary key with foreign key
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--# Manipulation Datas
-- 1. user 1 inserting datas user
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha ) 
VALUES('Renato','(11)2323-7069',
'renato@gmail.com',
'marculino','12345')

--2. user 2
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha ) 
VALUES('Camila','Camargo','(31)2122-7761',
'camila@gmail.com',
'feminino','1025')

-- select user
SELECT *
FROM usuario

-- especific user apllying WHERE command
SELECT *
FROM usuario
WHERE email = 'renato@gmail.com';

-- new datas/changes
SELECT *
FROM usuario;
UPDATE usuario SET email='renato123@gmail.com'
WHERE id = 1;

-- delete user
SELECT *
FROM usuario;
DELETE FROM usuario WHERE id = 1
