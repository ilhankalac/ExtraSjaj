----=======Kreiranje baze za ovu aplikaciju========

IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Tepisi_2018')
drop database Tepisi_2018;
go
create database Tepisi_2018;

use Tepisi_2018;
go
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
    Sirina      FLOAT (53) NOT NULL,
	MusterijaId INT        NOT NULL,
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

