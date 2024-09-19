CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [FirstName] varchar(20) NOT NULL, 
    [LastName] varchar(20) NOT NULL,
	[Email] varchar(40) NOT NULL,
	[PhoneNumber] int NOT NULL,
	[Address] varchar(50) NOT NULL,
	[City] varchar(50) NOT NULL,
	[Region] varchar(50),
	[Country] varchar(50) NOT NULL
)
