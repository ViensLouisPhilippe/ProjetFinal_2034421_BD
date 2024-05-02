use BD1_BengalsCincinnati_TP1
go
Create or alter procedure GetContractAndStatusByPlayer
	@FirstName Varchar(50),
	@LastName varchar(50)
as 
begin
select CONCAT(P.FirstName,' ', P.LastName) as 'Full name', T.TeamName, C.ContractTerms, C.[AverageSalary/Year], C.YearExpire, S.ReasonUnavailability, S.ExpectedDateReturn
from Players.Player P
left join Players.[Contract] C
on C.PlayerID = P.PlayerID
left join Players.[Status] S
on S.PlayerID = P.PlayerID
left join Teams.Team T
on T.TeamID = P.TeamID
where P.FirstName = @FirstName and P.LastName = @LastName
end