CREATE TABLE [dbo].[Post]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PostText] NTEXT NOT NULL, 
    [IsCorrect] BIT NULL DEFAULT 0, 
    [CreationDate] DATETIME NOT NULL, 
    [ThreadId] UNIQUEIDENTIFIER NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NULL,
	 FOREIGN  key(ThreadId) references Thread(id)
)
