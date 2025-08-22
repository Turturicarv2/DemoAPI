IF OBJECT_ID('dbo.Person', 'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Person]
    (
        [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
        [FirstName] VARCHAR(50) NOT NULL, 
        [LastName] NVARCHAR(50) NOT NULL
    );
END