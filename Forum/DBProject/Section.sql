CREATE TABLE [dbo].[Section]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NCHAR(100) NOT NULL, 
    [DisplayOrder] INT NULL, 
    [State] INT NULL, 
    [CreationDate] DATETIME NULL, 
    [UserId] UNIQUEIDENTIFIER NULL 
)
