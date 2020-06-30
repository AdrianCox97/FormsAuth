CREATE DATABASE pruebas;
GO
USE pruebas;
GO
CREATE TABLE [dbo].[Users] (
   [uname] [varchar] (15) NOT NULL primary key,
   [Pwd] [varchar] (25) NOT NULL ,
   [userRole] [varchar] (25) NOT NULL ,
)
GO
INSERT INTO Users VALUES ('admin', '1234', 'A'), ('prov', '1234', 'P');
GO
SELECT * FROM Users;