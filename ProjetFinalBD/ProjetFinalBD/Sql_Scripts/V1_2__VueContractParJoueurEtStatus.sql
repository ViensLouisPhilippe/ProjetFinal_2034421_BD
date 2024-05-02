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