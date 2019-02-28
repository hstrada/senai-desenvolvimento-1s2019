CREATE DATABASE Inlock_Games_Manha;

USE Inlock_Games_Manha;

CREATE TABLE Usuarios (
	UsuarioId INT PRIMARY KEY IDENTITY,
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL,
	TipoUsuario VARCHAR(50) NOT NULL
);

INSERT INTO Usuarios VALUES ('admin@admin.com', 'admin', 'ADMINISTRADOR'), ('cliente@cliente.com', 'cliente', 'CLIENTE');

CREATE TABLE Estudios (
	EstudioId INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR(100) NOT NULL
);

INSERT INTO Estudios VALUES ('Blizzard'), ('Rockstar Studios'),( 'Square Enix');

CREATE TABLE Jogos (
	JogoId INT PRIMARY KEY IDENTITY,
	NomeJogo VARCHAR(50) NOT NULL,
	Descricao TEXT NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor DECIMAL(5,2),
	EstudioId INT FOREIGN KEY REFERENCES Estudios(EstudioId)
);

INSERT INTO Jogos VALUES 
('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','2012-05-15', '99.00', 1),
('Red Dead Redemption II','Jogo eletrônico de ação-aventura western','2018-10-26', '120.00', 2)

