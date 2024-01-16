CREATE DATABASE BD1_Centro_Capacitacion
GO

USE BD1_Centro_Capacitacion
GO

CREATE TABLE Curso(
	id_cur INT IDENTITY PRIMARY KEY,
	descripcion_cur VARCHAR(25) NOT NULL,
	estado_cur BIT NOT NULL
)
GO

CREATE TABLE Alumno(
	id_alu INT IDENTITY PRIMARY KEY,
	dni_alu CHAR(8) NOT NULL,
	nombre_alu VARCHAR(50) NOT NULL,
	apellidos_alu VARCHAR(100) NOT NULL
)
GO

CREATE TABLE Seccion(
	id_sec INT IDENTITY PRIMARY KEY,
	aula_sec INT NOT NULL,
	id_cur INT FOREIGN KEY REFERENCES Curso(id_cur) NOT NULL,
	estado_sec BIT NOT NULL,
	fecha_registro_sec DATE NOT NULL
)
GO

CREATE TABLE Detalle_asig_alumno_seccion(
	id_sec INT FOREIGN KEY REFERENCES Seccion(id_sec) NOT NULL,
	id_alu INT FOREIGN KEY REFERENCES Alumno(id_alu) NOT NULL
)
GO

INSERT INTO Curso VALUES('Excel Básico','True'),('Excel Intermedio','False'),('Excel Avanzado','False'),('Ofimática I','True'),('Ofimática II','False')

INSERT INTO Alumno VALUES('42414201','Juan','Balta Gonzales'),('42414202','Patricio','Ugarte Perez')
INSERT INTO Alumno VALUES('42414203','Juana','Alcalde Gonzales'),('42414204','Lourdes','Perez Perez')
INSERT INTO Alumno VALUES('42414205','Angelina','Bolognesi Li'),('42414206','Alberto','Castillo Morales')
INSERT INTO Alumno VALUES('42414207','Maria','Li Alcalde'),('42414208','Omar','Villegas Delgado')
INSERT INTO Alumno VALUES('42414209','Paola','Gonzales Li'),('42414210','Pedro','Perales Plata')
INSERT INTO Alumno VALUES('42414211','Ana','Perez Alcalde'),('42414212','Luis','Morales Custodio')

INSERT INTO Seccion VALUES(1,1,'True','2019-10-02')
INSERT INTO Seccion VALUES(2,4,'False','2019-10-03')

INSERT INTO Detalle_asig_alumno_seccion VALUES(1,1),(1,2),(1,3),(1,4),(1,4),(1,6)
INSERT INTO Detalle_asig_alumno_seccion VALUES(2,7),(2,8),(2,9),(2,10),(2,11),(2,12)
Select* from Curso where estado_cur = 1
SELECT * FROM Alumno
SELECT S.id_sec, S.aula_sec, C.descripcion_cur, S.estado_sec, S.fecha_registro_sec FROM Seccion S INNER JOIN Curso C ON S.id_cur = C.id_cur
SELECT * FROM Detalle_asig_alumno_seccion

SELECT * FROM Curso WHERE estado_cur = 'True'

SELECT MAX(id_sec) FROM Seccion

Select* from Alumno where id_alu like 11
SELECT a.* FROM Detalle_asig_alumno_seccion d INNER JOIN Alumno a ON d.id_alu=a.id_alu WHERE d.id_sec = 2