CREATE TABLE [dbo].[Customers]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [CustomerId] INT NOT NULL UNIQUE, 
    [FirstName] varchar(20) NOT NULL, 
    [LastName] varchar(20) NOT NULL,
	[Email] varchar(40) NOT NULL,
	[PhoneNumber] int NOT NULL,
	[Address] varchar(50) NOT NULL,
	[City] varchar(50) NOT NULL,
	[Region] varchar(50),
	[Country] varchar(50) NOT NULL
)
