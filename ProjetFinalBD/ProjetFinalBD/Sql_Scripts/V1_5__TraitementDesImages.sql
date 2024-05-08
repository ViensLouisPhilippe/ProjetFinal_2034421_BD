use BD1_BengalsCincinnati_TP1
go
Create Table Players.[Image](
	ImageID int identity(1,1),
	Nom nvarchar(100) null,
	Identifiant uniqueIdentifier not null rowGuidcol,
	PlayerID int not null,
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
alter table Players.Player add ImageID int null
go
ALTER TABLE [Players].[Image] ADD  CONSTRAINT [FK_Image_PlayerID] FOREIGN KEY([PlayerID])
REFERENCES Players.Player ([PlayerID])
GO
ALTER TABLE [Players].Player ADD  CONSTRAINT [FK_Player_ImageID] FOREIGN KEY([ImageID])
REFERENCES Players.[Image] ([ImageID])
GO
