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
    VremeKreiranjeMusterije DATETIME NULL,
);
--======================================

--=====================================
--=======Tabela za Racune==============
CREATE TABLE Racuni (
    Id          INT        IDENTITY (1, 1) primary key NOT NULL,
    Racun       FLOAT (53) NULL,
    MusterijaId INT        NULL,
    KreiranjeRacuna DATETIME NULL,
    Placen 	BIT NULL,
    FOREIGN KEY (MusterijaId) REFERENCES Musterijas(Id) ON DELETE CASCADE
);
--======================================


--=====================================
--=======Tabela za Tepihe==============
CREATE TABLE Tepisi (
    Id          INT        IDENTITY (1, 1) primary key NOT NULL,
    Duzina      FLOAT (53) NOT NULL,
    Kvadratura  REAL       NOT NULL,
    Sirina      FLOAT (53) NOT NULL,
    RacunId     INT        NOT NULL,
    FOREIGN KEY (RacunId)     REFERENCES Racuni(Id) ON DELETE CASCADE
);
--======================================




