use IoT_Test;
----=======Kreiranje baze za ovu aplikaciju========
--drop database TepisiBaza-2018;
--go
--create database TepisiBaza-2018;


--=====================================
--=======Tabela za Musterije===========
CREATE TABLE Musterijas (
    Id 		INT IDENTITY 	 (1, 1) primary key	NOT NULL,
    ImePrezime 	NVARCHAR (MAX)			NULL,
    BrojTepiha 	SMALLINT NULL,
    BrojTelefona NCHAR (10)		        NULL,
    Adresa NVARCHAR (MAX) NULL,
    VremeDolaskaTepiha DATETIME NULL,
    Platio BIT NULL
);
--======================================


--=====================================
--=======Tabela za Tepihe==============
CREATE TABLE Tepisi (
    Id          INT        IDENTITY (1, 1) primary key NOT NULL,
    Duzina      FLOAT (53) NOT NULL,
    Kvadratura  REAL       NOT NULL,
    MusterijaId INT        NOT NULL,
    Sirina      FLOAT (53) NOT NULL,
    FOREIGN KEY (MusterijaId) REFERENCES Musterijas(Id) ON DELETE CASCADE
);
--======================================


--=====================================
--=======Tabela za Racune==============
CREATE TABLE Racuni (
    Id          INT        IDENTITY (1, 1) primary key NOT NULL,
    Racun       FLOAT (53) NULL,
    MusterijaId INT        NULL,
    FOREIGN KEY (MusterijaId) REFERENCES Musterijas(Id) ON DELETE CASCADE
);
--======================================

