CREATE DATABASE Familia
GO
USE Familia
GO
CREATE TABLE Padres
( 
Identificacion INT PRIMARY KEY NOT NULL,
Nombres VARCHAR(50) NOT NULL,
Apellidos VARCHAR(50)NOT NULL, 
FechaNacimiento DATETIME NOT NULL,
Genero VARCHAR (1) NOT NULL,
TipoEmpleo VARCHAR (1) NOT NULL,
ExperienciaLaboral INT NULL,
Observaciones VARCHAR (500) NULL
)
GO
CREATE TABLE Hijos
( 
Identificacion INT PRIMARY KEY NOT NULL,
Nombres VARCHAR(50) NOT NULL,
Apellidos VARCHAR(50)NOT NULL, 
FechaNacimiento DATETIME NOT NULL,
Genero VARCHAR (1) NOT NULL,
Estudia VARCHAR (1) NOT NULL,
Estatura INT NULL,
DescripcionFisica VARCHAR (500) NULL,
IdentificacionPadre INT FOREIGN KEY REFERENCES Padres(Identificacion),
IdentificacionMadre INT FOREIGN KEY REFERENCES Padres(Identificacion)
) 