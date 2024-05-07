Create Table Players.[Image](
	ImageID int identity(1,1),
	Nom nvarchar(100) not null,
	Identifiant uniqueIdentifier not null rowGuidcol,
	JoueurID int not null,
	Constraint PK_Image_ImageID Primary Key (ImageID)
)
go
alter table Players.[Image] add constraint UC_Image_Identifiant
unique (Identifiant)
go
alter table Players.[Image] add constraint DF_Image_Identifiant
default newid() for Identifiant
go
alter table Players.[Image] add FichierImage varbinary(max) Filestream null;
go
ALTER TABLE [Players].[Image] ADD  CONSTRAINT [FK_Image_PlayerID] FOREIGN KEY([PlayerID])
REFERENCES Players.Player ([PlayerID])
GO
