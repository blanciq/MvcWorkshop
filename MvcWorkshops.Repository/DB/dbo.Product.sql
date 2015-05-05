CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [ImageUrl] NVARCHAR(50) NULL, 
    [Price] DECIMAL(18, 2) NOT NULL
)
