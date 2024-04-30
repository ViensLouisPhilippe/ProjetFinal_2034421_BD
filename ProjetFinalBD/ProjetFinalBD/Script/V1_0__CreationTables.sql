--Use [master]
--go
--Create DATABASE [BD1_BengalsCincinnati_TP1]
go
use [BD1_BengalsCincinnati_TP1]
go
Create Schema [Teams]
go

Create Schema [Players]
go

Create Schema [Stats]
go

Create Table [Teams].[Team](
	TeamID int IDENTITY(1,1) not Null,
	TeamName nvarchar(30) not null,
	CoachName nvarchar(30) null,
	SeasonYear int not null,
	[Record(W/L/T)] nvarchar(10)not null,
	[PlayOffRecord(W/L)] nvarchar(6) null
	constraint [PK_Team_TeamID] primary key (
	[TeamID] asc
	)
)
go

Create Table [Players].[Player](
	PlayerID int Identity(1,1) not null,
	LastName nvarchar(25) not null,
	FirstName nvarchar(40) not null,
	BirthDate date not null,
	AgeExperience int not null,
	Number int null,
	Position nvarchar(25) null,
	Available bit not null,
	TeamID int not null
	constraint [PK_Joueur_JoueurID] primary key (
	PlayerID asc
	)
)	
go

Create Table [Players].[Contract](
	ContractID int Identity(1,1) not null,
	ContractTerms nvarchar(30)null,
	[AverageSalary/Year] money  null,
	Guaranteed money  null,
	YearExpire int  null,
	Acquired nvarchar(20) null,
	PlayerID int not null
	constraint [PK_Contract_ContractID] primary key (
	ContractID asc
	)
)
go

Create Table [Players].[Status](
	StatusID int Identity(1,1) not null,
	ReasonUnavailability nvarchar(40) null,
	ExpectedDateReturn nvarchar(15) null,
	DateSinceUnavailability date not null,
	PlayerID int not null
	constraint [PK_Status_StatusID] primary key (
	StatusID asc
	)
)
go

Create Table [Stats].[Stat](
	StatID int Identity(1,1) not null,
	GamePlayed int null,
	GameMissed int null,
	PlayerId int not null
	constraint [PK_Stat_StatID] primary key (
	StatID asc
	)
)
go

Create Table [Stats].[Passing](
	PassingID int Identity(1,1) not null,
	StatID int not null,
	YardsTotal int null,
	TotalTD int null,
	Interception int null
	constraint [PK_Passing_PassingID] primary key (
	PassingID asc
	)
)
go

Create Table [Stats].[Rushing](
	RushingID int Identity(1,1) not null,
	StatID int not null,
	RushingAttempts int null,
	YardsTotal int null,
	TotalTD int null
	constraint [PK_Rushing_RushingID] primary key (
	RushingID asc
	)
)
go

Create Table [Stats].[Defense](
	DefenseID int Identity(1,1) not null,
	StatID int not null,
	SoloTackles int null,
	AssistedTackle int null,
	Sack decimal(10,1) null,
	Interception int null,
	ForceFumble int null
	constraint [PK_Defense_DefenseID] primary key (
	DefenseID asc
	)
)
go

Create Table [Stats].[Receiving](
	ReceivingID int Identity(1,1) not null,
	StatID int not null,
	Receptions int null,
	YardsTotal int null,
	TotalTD int null
	constraint [PK_Receiving_ReveivingID] primary key (
	ReceivingID asc
	)
)
go

ALTER TABLE [Players].[Player] ADD  CONSTRAINT [FK_Player_TeamID] FOREIGN KEY([TeamID])
REFERENCES [Teams].[Team] ([TeamID])
GO
ALTER TABLE [Players].[Contract] ADD  CONSTRAINT [FK_Contract_PlayerID] FOREIGN KEY([PlayerID])
REFERENCES [Players].[Player] ([PlayerID])
GO
ALTER TABLE [Players].[Status] ADD  CONSTRAINT [FK_Status_PlayerID] FOREIGN KEY([PlayerID])
REFERENCES [Players].[Player] ([PlayerID])
GO
ALTER TABLE [Stats].[Stat] ADD  CONSTRAINT [FK_Stat_PlayerID] FOREIGN KEY([PlayerID])
REFERENCES [Players].[Player] ([PlayerID])
GO
ALTER TABLE [Stats].[Passing] ADD  CONSTRAINT [FK_Passing_StatID] FOREIGN KEY([StatID])
REFERENCES [Stats].[Stat] ([StatID])
GO
ALTER TABLE [Stats].[Rushing] ADD  CONSTRAINT [FK_Rushing_StatID] FOREIGN KEY([StatID])
REFERENCES [Stats].[Stat] ([StatID])
GO
ALTER TABLE [Stats].[Defense] ADD  CONSTRAINT [FK_Defense_StatID] FOREIGN KEY([StatID])
REFERENCES [Stats].[Stat] ([StatID])
GO
ALTER TABLE [Stats].[Receiving] ADD  CONSTRAINT [FK_Receiving_StatID] FOREIGN KEY([StatID])
REFERENCES [Stats].[Stat] ([StatID])
GO
Alter TABLE [Players].[Player] add constraint [UC_Player_Number] Unique ([Number])
GO
Alter TABLE [Players].[Contract] add constraint [UC_Contract_PlayerID] Unique ([PlayerID])
GO
Alter TABLE [Players].[Status] add constraint [UC_Status_ReasonUnavailability] Default 'Unknown' for [ReasonUnavailability]
GO
Alter TABLE [Players].[Status] add constraint [UC_Status_ExpectedDateReturn] Default 'Next Season' for [ExpectedDateReturn]
GO
Alter TABLE [Players].[Contract] add constraint [CHK_Contract_Acquired] check (Acquired in ('Drafted', 'Free Agent','Traded', 'Claimed', 'Undrafted', 'Reserve/Future', 'FromPrac.Squad'))
GO