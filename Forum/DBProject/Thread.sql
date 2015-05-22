CREATE TABLE [dbo].[Thread]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [CreationDate] DATETIME NULL, 
    [Title] NCHAR(200) NULL, 
    [Description] NTEXT NULL, 
    [QuestionStatus] BIT NULL, 
    [State] INT NULL, 
    [SectionId] UNIQUEIDENTIFIER NOT NULL foreign key (SectionId) references Section(Id), 
    [UserId] UNIQUEIDENTIFIER NULL 
)
