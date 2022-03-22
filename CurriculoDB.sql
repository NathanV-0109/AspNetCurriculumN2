CREATE DATABASE CurriculoDB
GO

USE CurriculoDB
GO

DROP TABLE formacao, experiencia, idioma, pessoa

CREATE TABLE pessoa
(
	id INT PRIMARY KEY NOT NULL ,
	cpf NVARCHAR(15) NOT NULL,
	nome NVARCHAR(70) NOT NULL, 
	telefone NVARCHAR(13) NOT NULL,
	email NVARCHAR(90) NOT NULL,
	pretensao_salarial DECIMAL(18,2) NOT NULL,
	cargo_pretendido NVARCHAR(60) NOT NULL,	
)
GO

CREATE TABLE formacao
(
	formacao_id INT PRIMARY KEY NOT NULL,
	pessoa_id INT FOREIGN KEY REFERENCES pessoa(id),
	nome_curso1 NVARCHAR(40) NULL,
	mes_formacao1 INT NULL,
	ano_formacao1 INT NULL,
	nome_curso2 NVARCHAR(40) NULL,
	mes_formacao2 INT NULL,
	ano_formacao2 INT NULL,
	nome_curso3 NVARCHAR(40) NULL,
	mes_formacao3 INT NULL,
	ano_formacao3 INT NULL,
	nome_curso4 NVARCHAR(40) NULL,
	mes_formacao4 INT NULL,
	ano_formacao4 INT NULL,
	nome_curso5 NVARCHAR(40) NULL,
	mes_formacao5 INT NULL,
	ano_formacao5 INT NULL,
)
GO

CREATE TABLE experiencia 
(
	experiencia_id INT PRIMARY KEY NOT NULL,
	pessoa_id INT FOREIGN KEY REFERENCES pessoa(id),
	nome_empresa1 NVARCHAR(40),
	nome_cargo1 NVARCHAR(40),
	dt_inicio1 DATE NULL,
	dt_fim1 DATE NULL,
	nome_empresa2 NVARCHAR(40),
	nome_cargo2 NVARCHAR(40),
	dt_inicio2 DATE NULL,
	dt_fim2 DATE NULL,
	nome_empresa3 NVARCHAR(40),
	nome_cargo3 NVARCHAR(40),
	dt_inicio3 DATE NULL,
	dt_fim3 DATE NULL,
)
GO

CREATE TABLE idioma
(
	idioma_id INT PRIMARY KEY NOT NULL,
	pessoa_id INT FOREIGN KEY REFERENCES pessoa(id),
	idioma1 NVARCHAR(20) NULL,
	nivel1 int NULL,
	idioma2 NVARCHAR(20) NULL,
	nivel2 int NULL,
	idioma3 NVARCHAR(20) NULL,
	nivel3 int NULL,
	idioma4 NVARCHAR(20) NULL,
	nivel4 int NULL,
	idioma5 NVARCHAR(20) NULL,
	nivel5 int NULL
)
GO
/*
	nome_curso NVARCHAR(40) NOT NULL,
	mes_formacao INT NOT NULL,
	ano_formacao INT NOT NULL,
	nome_empresa NVARCHAR(40),
	nome_cargo NVARCHAR(40),
	dt_inicio DATE NOT NULL,
	dt_fim DATE NOT NULL,
	idioma NVARCHAR(20) NULL,
	nivel NVARCHAR NULL
*/

INSERT INTO pessoa (id, cpf, nome, telefone, email, pretensao_salarial, cargo_pretendido)
VALUES(1, '231.432.381-23', 'Pataxó Clemência', '97810-4058', 'Caio.2003.rfs@gmail.com', 1600.00, 'Estagiário de TI')

SELECT * FROM pessoa
SELECT * FROM formacao
SELECT * FROM experiencia
SELECT * FROM idioma

delete from pessoa where id = 1