CREATE TABLE [dbo].[Attendees]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [Email] VARCHAR(150) NULL, 
    [CreatedDate] DATE NOT NULL DEFAULT GETDATE(), 
    [CreatedBy] NCHAR(10) NULL, 
    [ModifiedDate] DATE NULL, 
    [ModifiedBy] NCHAR(10) NULL, 
    [Status] INT NOT NULL DEFAULT 1, 
    [RegistrationType] INT NULL, 
    [RegistrationDate] DATE NULL
)
