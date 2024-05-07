use BD1_BengalsCincinnati_TP1
go

Create or alter VIEW Players.vw_AllPlayersFromSameTeam
	as
		select CONCAT(P.FirstName,' ', P.LastName) as 'Full name', P.Number, P.AgeExperience, C.ContractTerms, C.Acquired, C.YearExpire, T.TeamName,
		Case
				when P.Available = 0 then 'Inactif'
				when P.Available = 1 then 'Actif'
				end as 'Active?', S.ReasonUnavailability, S.ExpectedDateReturn

		from Players.Player P

		left join Players.[Contract] C
		on C.PlayerID = P.PlayerID
		left join Players.[Status] S
		on S.PlayerID = P.PlayerID
		left join Teams.Team T
		on T.TeamID = P.TeamID
go



Create or alter procedure GetAllPlayersFromSameTeam
	@TeamId int
as 
begin
select CONCAT(P.FirstName,' ', P.LastName) as 'Full name', P.Number, P.AgeExperience, C.ContractTerms, C.Acquired, C.YearExpire,T.TeamName,
Case
				when P.Available = 0 then 'Inactif'
				when P.Available = 1 then 'Actif'
				end as 'Active?', S.ReasonUnavailability, S.ExpectedDateReturn
from Players.Player P
left join Players.[Contract] C
on C.PlayerID = P.PlayerID
left join Players.[Status] S
on S.PlayerID = P.PlayerID
left join Teams.Team T
on T.TeamID = P.TeamID
where P.TeamID = @TeamId
end