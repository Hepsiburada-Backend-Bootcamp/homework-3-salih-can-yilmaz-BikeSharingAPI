PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

DROP TABLE IF EXISTS Sessions;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Bicycles;

CREATE TABLE Users(
	Id 			INTEGER 	NOT NULL 
						PRIMARY KEY 
						AUTOINCREMENT,
	Name 			NVARCHAR(50) 	NOT NULL,
	Surname 		NVARCHAR(50) 	NOT NULL,
	Gender 		CHARACTER,
	BirthDate 		DATETIME,
	DateJoined 		DATETIME,
	EMail 			NVARCHAR(50),
	PhoneNumber 		NVARCHAR(15),
	Balance 		NUMERIC 	DEFAULT 0
	);
	
CREATE TABLE Sessions(
	Id 			NVARCHAR(36) 	NOT NULL 
						PRIMARY KEY,
	UserId			INTEGER	REFERENCES Users(Id) ON DELETE NO ACTION ON UPDATE CASCADE,
	BicycleId		INTEGER	REFERENCES Bycycles(Id) ON DELETE NO ACTION ON UPDATE CASCADE,
	StartDate 		DATETIME,
	EndDate 		DATETIME,
	StartLocation		NVARCHAR(15),
	EndLocation		NVARCHAR(15),
	Temperature		NUMERIC	DEFAULT 20,
	IsHoliday		BOOLEAN,
	Cost			NUMERIC	DEFAULT 0,
	UserComment		NVARCHAR(150),
	TotalDistance		NUMERIC,
	UserRating		INTEGER
	);
	
CREATE TABLE Bicycles(
	Id 			NVARCHAR(36) 	NOT NULL 
						PRIMARY KEY,
	InServiceDate 		DATETIME,
	Location		NVARCHAR(15)
	);
	
INSERT INTO Users VALUES (NULL,"Can", "Yılmaz", "M", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO Users VALUES (NULL,"Mehmet", "Demir", "M", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO Users VALUES (NULL,"Derya", "Durmuş", "F", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);
INSERT INTO Users VALUES (NULL,"Ayşe", "Bulut", "F", "1995-05-20", "2020-03-19", "canyilmaz999@gmail.com", "05551231212", 85.5);

INSERT INTO Sessions VALUES ("48fc25ed-bf80-4c40-9375-c59dca26528f", 1, "07c4843e-79d6-4268-98c1-514d2b4c97af", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 5);
INSERT INTO Sessions VALUES ("71a6cb62-1da4-4876-87d7-e1382cf7ac52", 1, "8b33d2cb-3501-4eb4-8136-c52c5a213819", "2020-02-11 14:00:00", "2020-02-11 17:00:00", "KADIKOY", "PENDIK", 13.1, FALSE, 110.7,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 20012, 3);
INSERT INTO Sessions VALUES ("e73366f3-c1da-4806-82fd-4bfc12b0f1aa", 1, "878f5b80-4ef4-40dc-80de-2e9980963fcd", "2020-08-19 14:00:00", "2020-08-19 19:30:00", "KARTAL", "KADIKOY", 34.5, FALSE, 18.1,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 8436, 4);
INSERT INTO Sessions VALUES ("f3145e41-6f5c-4890-a845-f6034bb82841", 1, "c114eb63-805c-48b3-ac78-a82e5f0ccaff", "2020-12-19 14:00:00", "2020-12-19 15:00:00", "KADIKOY", "KARTAL", 4.5, TRUE, 7.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 2456, 2);
INSERT INTO Sessions VALUES ("86850c29-cd3b-439a-a36f-321cf7d7dd39", 2, "7faaf191-3bd7-4821-8039-6c370ebd39a9", "2020-01-29 11:00:00", "2020-01-29 15:00:00", "MALTEPE", "PENDIK", -4.5, TRUE, 36.2,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 12312, 5);
INSERT INTO Sessions VALUES ("95fbe881-4d34-46d9-8548-370e2e262083", 2, "07c4843e-79d6-4268-98c1-514d2b4c97af", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "PENDIK", "KARTAL", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 3456, 5);
INSERT INTO Sessions VALUES ("d0aa1ae1-2eb5-4729-866e-9a58a520d59b", 3, "b2c7d701-ecc8-47d7-bdb7-b133654a7fec", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "PENDIK", "MALTEPE", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 256, 4);
INSERT INTO Sessions VALUES ("0d605c39-4a6e-412a-9566-47629a318d2f", 3, "e089a4eb-a092-4b43-b2e7-d1d68ca715f4", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "PENDIK", 14.5, TRUE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 556, 4);
INSERT INTO Sessions VALUES ("ca8b08e1-251c-4825-a7e3-7b7e630ae467", 3, "50aa4a41-25c6-4241-81b9-59ba184cdd6b", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "KADIKOY", 14.5, FALSE, 80.3,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 15456, 4);
INSERT INTO Sessions VALUES ("579ef790-e251-47d8-86ec-5137db0aace3", 4, "878f5b80-4ef4-40dc-80de-2e9980963fcd", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KADIKOY", "MALTEPE", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 1);
INSERT INTO Sessions VALUES ("22f78d8d-33f5-4b2b-ade1-289b06f1f52c", 4, "e089a4eb-a092-4b43-b2e7-d1d68ca715f4", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "PENDIK", "KARTAL", 14.5, FALSE, 80.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 15456, 5);
INSERT INTO Sessions VALUES ("551f30ee-3338-4c0b-b098-b4d51bb55bb2", 4, "8b33d2cb-3501-4eb4-8136-c52c5a213819", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "KARTAL", "MALTEPE", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 3);
INSERT INTO Sessions VALUES ("fcdcc587-2965-4af3-a949-03076f708192", 4, "b2c7d701-ecc8-47d7-bdb7-b133654a7fec", "2020-03-19 14:00:00", "2020-03-19 15:00:00", "MALTEPE", "KARTAL", 14.5, FALSE, 10.4,
"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad", 5456, 4);
 

INSERT INTO Bicycles VALUES ("07c4843e-79d6-4268-98c1-514d2b4c97af","2016-02-19 05:00:00", "KARTAL");
INSERT INTO Bicycles VALUES ("8b33d2cb-3501-4eb4-8136-c52c5a213819","2017-01-12 05:00:00", "MALTEPE");
INSERT INTO Bicycles VALUES ("7faaf191-3bd7-4821-8039-6c370ebd39a9","2019-08-11 05:00:00", "PENDIK");
INSERT INTO Bicycles VALUES ("b2c7d701-ecc8-47d7-bdb7-b133654a7fec","2017-01-30 05:00:00", "PENDIK");
INSERT INTO Bicycles VALUES ("e089a4eb-a092-4b43-b2e7-d1d68ca715f4","2017-01-30 05:00:00", "MALTEPE");
INSERT INTO Bicycles VALUES ("c114eb63-805c-48b3-ac78-a82e5f0ccaff","2017-11-30 05:00:00", "MALTEPE");
INSERT INTO Bicycles VALUES ("50aa4a41-25c6-4241-81b9-59ba184cdd6b","2016-02-19 05:00:00", "KARTAL");
INSERT INTO Bicycles VALUES ("878f5b80-4ef4-40dc-80de-2e9980963fcd","2017-01-12 05:00:00", "KADIKOY");

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
SELECT * FROM Users;
SELECT * FROM Sessions;
SELECT * FROM Bicycles;
