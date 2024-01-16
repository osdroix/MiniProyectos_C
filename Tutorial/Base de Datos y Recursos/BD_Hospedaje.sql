CREATE DATABASE BD3_Hospedaje
GO

USE BD3_Hospedaje
GO

CREATE TABLE Habitacion(
	id_hab INT IDENTITY PRIMARY KEY,
	descripcion_hab VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Huesped(
	id_hsp INT IDENTITY PRIMARY KEY,
	dni_hsp CHAR(8) NOT NULL,
	nombre_hsp VARCHAR(50) NOT NULL,
	apellido_pat_hsp VARCHAR(50) NOT NULL,
	apellido_mat_hsp VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Alquiler(
	id_alq INT IDENTITY PRIMARY KEY,
	id_hab INT FOREIGN KEY REFERENCES Habitacion(id_hab) NOT NULL,
	estado_alq BIT NOT NULL,
	fecha_registro_alq DATE NOT NULL,
	numero_dias_aql INT NOT NULL
)
GO

CREATE TABLE Detalle_alquiler(
	id_aql INT FOREIGN KEY REFERENCES Alquiler(id_alq) NOT NULL,
	id_hsp INT FOREIGN KEY REFERENCES Huesped(id_hsp) NOT NULL
)
GO

INSERT INTO Habitacion VALUES('Habitación A101'),('Habitación A102'),('Habitación A103'),('Habitación A201'),('Habitación A202')

INSERT INTO Huesped VALUES('53525101','Juan','Balta','Gonzales'),('53525102','Patricio','Ugarte','Perez')
INSERT INTO Huesped VALUES('53525103','Juana','Alcalde','Gonzales'),('53525104','Lourdes','Perez','Perez')
INSERT INTO Huesped VALUES('53525105','Angelina','Bolognesi','Li'),('53525106','Alberto','Castillo','Morales')
INSERT INTO Huesped VALUES('53525107','Maria','Li','Alcalde'),('53525108','Omar','Villegas','Delgado')
INSERT INTO Huesped VALUES('53525109','Paola','Gonzales','Li'),('53525110','Pedro','Perales','Plata')
INSERT INTO Huesped VALUES('53525111','Ana','Perez','Alcalde'),('53525112','Luis','Morales','Custodio')

INSERT INTO Alquiler VALUES(1,'True','2019-10-04',5)
INSERT INTO Alquiler VALUES(2,'True','2019-10-04',1)
INSERT INTO Alquiler VALUES(3,'False','2019-10-04',2)

INSERT INTO Detalle_alquiler VALUES(1,1),(1,2)
INSERT INTO Detalle_alquiler VALUES(2,3),(2,4),(2,5)
INSERT INTO Detalle_alquiler VALUES(3,6)

SELECT * FROM Habitacion
SELECT * FROM Huesped
SELECT * FROM Alquiler
SELECT * FROM Detalle_alquiler