 use BD1_BengalsCincinnati_TP1
go
create MASTER key ENCRYPTION by Password = 'P4ssword!PasswordETC';
go
Create CERTIFICATE MonCertificat with SUBJECT = 'ChiffrementPosition'
go
create SYMMETRIC KEY MaCle with ALGORITHM = AES_128 encryption by Certificate MonCertificat;
go

--Ajout de la colonne
alter table Players.Player
add PositionChiffree varbinary(max)
go



--Chiffrer les positions des joueurs existants
open SYMMETRIC key MaCle DECRYPTION by Certificate MonCertificat
update Players.Player
set PositionChiffree = EncryptByKey(KEY_GUID('MaCle'), Position)
close SYMMETRIC key MaCle
go
alter table Players.Player
drop column Position
go


--CREATION de la table pour dechiffrement
Create Table Players.DeChiffrePosition(
Position nvarchar(50)
)
go

--DECHIFFREMENT DE POSITION
Create Procedure DeChiffrementPositionDesJoueurs
	@PlayerID int
as 
begin
	open SYMMETRIC key MaCle DECRYPTION by Certificate MonCertificat

	select Convert(nvarchar(50),DECRYPTBYKEY(PositionChiffree)) as 'Position' from Players.Player
	where PlayerID = @PlayerID
	close SYMMETRIC key MaCle
end
go


