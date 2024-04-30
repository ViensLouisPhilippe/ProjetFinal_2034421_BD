	Use [BD1_BengalsCincinnati_TP1]
go
insert into Teams.Team (TeamName, CoachName, SeasonYear, [Record(W/L/T)],[PlayOffRecord(W/L)])
values
('Bengals', 'Zac Taylor',2023, '9/8/0',null),
('Steelers', 'Mike Tomlin',2023, '10/7/0','0/1'),
('Browns', 'Kevin Stefanski',2023, '11/6/0','0/1'),
('Ravens', 'John Harbaugh',2023, '13/4/0','1/1'),
('Jets', 'Robert Salah',2023, '7/10/0',null),
('Patriot', 'Bill Belichick',2023, '4/13/0',null),
('Dolphins', 'Mike McDaniel',2023, '11/6/0','0/1'),
('Bills', 'Sean McDermott',2023, '11/6/0','1/1'),
('Chiefs', 'Andy Reid',2023, '12/5/0','4/0'),
('Raiders', 'Josh McDaniels',2023, '8/9/0',null),
('Broncos', 'Sean Payton',2023, '8/9/0',null),
('Chargers', 'Brandon Staley',2023, '5/12/0',null),
('Texans', 'DeMeco Ryan',2023, '10/7/0','1/1'),
('Jaguars', 'Doug Peterson',2023, '9/8/0',null),
('Colts', 'Shane Steichen',2023, '9/8/0',null),
('Titans', 'Mike Vrabel',2023, '6/11/0',null);
go
--En FAit les joueurs font tous partit de l'equipe 1
insert into Players.Player (LastName, FirstName, BirthDate, AgeExperience, Number, Position, Available , TeamID)
values
('Burrow','Joe', '1996-12-10', 4, 9, 'Quaterback', 0 , 1),
('Browning','Jake', '1996-4-11', 1, 6, 'Quaterback', 1,2),
('McCarron','A.J.', '1990-9-13', 8, 4, 'Quaterback', 1,5),
('Chase','Jamar', '2000-3-1', 3, 1, 'Receiver', 1,6),
('Boyd','Tyler', '1994-11-15', 8, 83, 'Receiver', 1,3),
('Higgins','Tee', '1999-1-18', 4, 5, 'Receiver', 0,5),
('Irwin','Trenton', '1995-12-10', 2, 16, 'Receiver', 1,7),
('Iosivas','Andrei', '1999-10-15', 1, 80, 'Receiver', 1,12),
('Jackson','Shedrick', '1998-10-29', 1, 15, 'Receiver', 1,1),
('Jones','Charlie', '1999-10-20', 1, 12, 'Receiver', 0,10),
('Hudson','Tanner', '1994-11-12', 4, 87, 'Tight End', 1,1),
('Willcox','Mitchell', '1997-9-1', 2, 84, 'Tight End', 1,4),
('Sample','Drew', '1996-4-16', 4, 89, 'Tight End', 1,2),
('Smith Jr.','Irv', '1998-9-8', 4, 81, 'Tight End', 0,10),
('Mixon','Joe', '1996-7-24', 7, 28, 'Runningback', 1,11),
('Brown','Chase', '2000-3-21', 1, 30, 'Runningback', 1,3),
('Evans','Chris', '1997-5-10', 2, 25, 'Runningback', 0,1),
('Williams','Trayveon', '1997-10-18', 4, 32, 'Runningback', 1,4),
('Pratt','Germaine', '1995-04-03', 3, 57, 'Linebacker', 1,6),
('Wilson','Logan', '1996-12-08', 3, 55, 'Linebacker', 0,7),
('Bachie','Joe', '1998-2-26', 3, 49, 'Linebacker', 1,13),
('Bailey','Markus', '1997-7-3', 3, 51, 'Linebacker', 1,12),
('Hilton','Mike', '1996-7-5', 3, 21, 'Cornerback', 1,4),
('Taylor-Britt','Cam', '1996-06-14', 3, 29, 'Cornerback', 0,2),
('Turner','DJ', '1996-05-07', 3, 20, 'Cornerback', 0,9),
('Awuzie','Chidobe', '1996-12-10', 3, 22, 'Cornerback', 1,5),
('Davis','Jalen', '1996-2-2', 5, 35, 'Cornerback', 1,14),
('Ivey','DJ', '2000-2-25', 1, 38, 'Cornerback', 1,16),
('Battle','Jordan', '1996-11-10', 3, 27, 'Safety', 1,1),
('Hill','Daxton', '1994-9-17', 3, 23, 'Safety', 1,2),
('Scott','Nick', '1996-12-10', 3, 33, 'Safety', 0,3),
('Anderson','Tycen', '1999-6-13', 1, 26, 'Safety',1,4),
('Carter','Zachary', '1996-12-10', 3, 95, 'Defensive Tackle', 0,5),
('Reader','D.J.', '1996-2-2', 3, 98, 'Defensive Tackle', 1,6),
('Hill','B.J.', '1997-1-5', 3, 92, 'Defensive Tackle', 1,7),
('Tupou','Josh', '1994-2-5', 6, 68, 'Defensive Tackle', 1,8),
('Hubbard','Sam', '1997-8-10', 3, 94, 'Defensive End', 0,9),
('Murphy','Myles', '2002-3-1', 1, 99, 'Defensive End', 1,10),
('Sample','Cameron', '1999-9-20', 2, 96, 'Defensive End', 1,11),
('Hendrickson','Trey', '1997-2-15', 3, 91, 'Defensive End', 1,12),
('Watt','T.J.', '1994-10-11', 7, 90, 'Defensive End', 1,2),
('Garrett','Myles.', '1995-12-29', 7, 97, 'Defensive End', 1,3),
('Jackson','Lamar', '1997-1-7', 6, 8, 'Quaterback', 1,4),
('Rodgers','Aaron', '1983-12-2', 19, 3, 'Quaterback', 1,5);
go
insert into Players.[Contract] (ContractTerms, [AverageSalary/Year], Guaranteed, YearExpire, Acquired, PlayerID)
values
('5 yr $275,000,000', 55000000,219010000,2030,'Drafted',1),
('1 yr $750,000', 750000,0,2024,'FromPrac.Squad',2),
('1 yr $1,165,000', 1165000,0,2024,'Free Agent',3),
('4 yr $30,819,641', 7704910,30819641,2026,'Drafted',4),
('4 yr $43,000,000', 10750000,17280769,2024,'Drafted',5),
('4 yr $8,686,785',2171696,5882518,2024,'Drafted',6),
('2 yr $1,765,000', 882500,0,2024,'Free Agent',7),
('4 yr $3,999,384', 999846,159384,2027,'Drafted',8),
('1 yr $915,000', 915000,0,2025,'Reserve/Future',9),
('4 yr $4,518,776', 1129694,678776,2027,'Drafted',10);
go
insert into Players.[Status] (PlayerID, ReasonUnavailability, ExpectedDateReturn, DateSinceUnavailability)
values
(1, 'Right wrist injury', 'Next Season', '2023-11-16'),
(6,	'Torn Muscle',	'2023-12-20','2023-11-09'),
(10,'Shoulder injury',	'2023-11-08','2023-10-20'),
(17,'Unknown',	'2024-01-04','2023-12-26'),
(20,'Torn right ACL', 'Next Season','2023-10-04'),
(24,'sprain left ankle','2023-12-26','2023-11-03'),
(25,'Unknown','Next Season','2024-01-10'),
(31,'sprain right ankle','2023-11-09','2023-09-23'),
(33,'ruptured left achilles tendon','Next Season','2023-12-04'),
(37,'PIP joint dislocation','2024-01-10','2023-10-16')
go
insert into [Stats].Stat (PlayerId, GamePlayed, GameMissed)
values
--Passing
(1,10,7),
(2,9,8),
(3,2,15),
--Receiving
(4,16,1),
(5,17,0),
(6,12,5),
--Rushing
(15,17,0),
(16,12,5),
(18,17,0),
--Defense
(19,17,0),
(20,17,0),
(24,12,5),
(26,15,2),
(30,17,0),
(34,14,3),
(37,15,2),
(40,17,0)
go
insert into [Stats].Passing (StatID,YardsTotal,TotalTD,Interception)
values
(1,2309,15,6),
(2,1939,12,7),
(3,19,0,0)
go
insert into [Stats].Receiving (StatID,Receptions,YardsTotal,TotalTD)
values
(4,100,1216,7),
(5,67,667,2),
(6,42,656,5)
go	
insert into [Stats].Rushing(StatID,RushingAttempts,YardsTotal,TotalTD)
values
(7,257,1034,9),
(8,44,179,0),
(9,15,69,0)
go	
insert into [Stats].Defense(StatID,SoloTackles,AssistedTackle,Sack, Interception, ForceFumble)
values
(10,63,55,2.0,2,2),
(11,78,57,0.0,4,1),
(12,40,10,1.0,4,1),
(13,43,14,0.0,0,1),
(14,72,38,1.5,2,0),
(15,20,14,1.0,0,1),
(16,58,20,6.0,0,2),
(17,28,15,17.5,0,3)
go	