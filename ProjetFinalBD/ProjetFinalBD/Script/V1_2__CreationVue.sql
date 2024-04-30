use BD1_BengalsCincinnati_TP1
go
--VUE : observer les details de contracts des joueurs puis observer si le joueur est disponible ou non et pourquoi?
CREATE OR ALTER VIEW Players.vw_InfoJoueurEtContract
	AS
			SELECT Top(200) CONCAT(FirstName, ' ', LastName) As 'Nom complet', P.BirthDate, P.Number, C.ContractTerms , C.[AverageSalary/Year], C.Guaranteed, C.YearExpire, C.Acquired,
			Case
				when P.Available = 0 then 'False'
				when P.Available = 1 then 'True'
				end as 'Active?', S.ReasonUnavailability, S.DateSinceUnavailability, S.ExpectedDateReturn

			FROM Players.Player P
			inner JOIN Players.[Contract] C
			ON C.PlayerID = P.PlayerID
			left JOIN Players.[Status] S
			on S.PlayerID = P.PlayerID
			Order By CONCAT(FirstName, ' ', LastName)
	GO


	--FONCTION : On veut retourner le nombre total de TouchDowns(TD) de l'equipe selon le ID (TeamID) selectionner 
	-- Donc la question poser ici en utilisant cette fonction est : Combien de touchdown l'équipe a-t-elle obtenu en tout parmi ses joueurs peut importe la manière?
	Create or ALter FUNCTION [Teams].ufn_NbrTotalDeTDPourLequipe
	(@TeamID int)
	RETURNS int
	AS 
	BEGIN
		DECLARE @answer int;

		SELECT @answer = ISNULL(SUM(Rec.TotalTD),0) + ISNULL(SUM(Pass.TotalTD),0) + ISNULL(SUM(Rush.TotalTD),0)
		FROM BD1_BengalsCincinnati_TP1.Players.Player P
			inner join BD1_BengalsCincinnati_TP1.[Stats].Stat S
			on S.PlayerId = P.PlayerID
			left join BD1_BengalsCincinnati_TP1.[Stats].Rushing Rush
			on Rush.StatID = S.StatID
			left join BD1_BengalsCincinnati_TP1.[Stats].Passing Pass
			on Pass.StatID = S.StatID
			left join BD1_BengalsCincinnati_TP1.[Stats].Receiving Rec
			on Rec.StatID = S.StatID
			where P.TeamID = @TeamID
		RETURN @answer;
	END
	GO
	--Requete de test de la fonction
	select TeamName, SeasonYear, Teams.ufn_NbrTotalDeTDPourLequipe(TeamID) as 'Nbr de touchdown Total'
	from Teams.Team

	--DECLENCHEUR
	--Le déclencheur est conçu pour garantir que lorsqu'un nouveau joueur est inséré, ses détails de contrat sont automatiquement ajoutés à la table Players.Contract.
	--Cependant, il est important de noter que les valeurs de @ContractTerms, @AverageSalaryYear, @Guaranteed, @YearExpire, et @Acquired ne sont pas initialisées ou assignées dans le code fourni. 
	go
	Create or alter Trigger Players.trg_iContractToPlayer
	on [Players].Player
	after Insert
	as
	begin
		declare @PlayerID int
		declare @ContractTerms int
		declare @AverageSalaryYear int
		declare @Guaranteed int
		declare @YearExpire int
		declare @Acquired nvarchar(30)
		select @PlayerID = PlayerID from inserted;
		insert into Players.[Contract](PlayerID, ContractTerms, [AverageSalary/Year], Guaranteed,YearExpire, Acquired)
		values (@PlayerID, @ContractTerms, @AverageSalaryYear, @Guaranteed ,@YearExpire, @Acquired);
	end
	go
	
	--TEST POUR DECLENCHEUR
	--select * from Players.Player
	--delete from Players.Player where FirstName = 'Maxime'
	--	select * from Players.Player
	--	SELECT * FROM Players.Contract
	--insert into Players.Player(FirstName, LastName,Position,Number, TeamID, BirthDate, AgeExperience, Available)
	--values ('Maxime', 'Pelletier', 'Long-Snapper', 40, 1, '1995-11-12', 3, 1)
	--	select * from Players.Player
	--	SELECT * FROM Players.Contract
