USE master

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Invoice_Creator')
BEGIN
    CREATE DATABASE [Invoice_Creator]
END
GO

USE [Invoice_Creator]

GO

CREATE TABLE [dbo].[LevelUp]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(100) NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    CONSTRAINT [PK_LevelUp_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [UQ_LevelUp_Name] UNIQUE ([Name])

)

GO

CREATE TABLE [dbo].[QuestionDifficulty]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(500) NULL, 
    [Cost] DECIMAL(30, 2) NOT NULL, 
    CONSTRAINT [PK_QuestionDifficulty] PRIMARY KEY ([Id]), 
    CONSTRAINT [UQ_QuestionDifficulty_Name] UNIQUE ([Name])
)

GO

CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Description] VARCHAR(500) NOT NULL, 
    [QuestionDifficultyId] INT NOT NULL, 
    [LevelUpId] INT NOT NULL, 

    CONSTRAINT [FK_Question_QuestionDifficulty] FOREIGN KEY ([QuestionDifficultyId]) REFERENCES [QuestionDifficulty]([Id]), 
    CONSTRAINT [FK_Question_LevelUp] FOREIGN KEY ([LevelUpId]) REFERENCES [LevelUp]([Id]), 
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id])


)

GO

CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [FirstName] VARCHAR(50) NOT NULL , 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [GradYear] DATE NOT NULL, 
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]), 
    CONSTRAINT [UQ_Student_Email] UNIQUE ([Email])
)

GO

CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL, 
    [QuestionId] INT NOT NULL, 
    [StudentId] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_Student] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]), 
    CONSTRAINT [FK_Transaction_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question]([Id]), 
    CONSTRAINT [PK_Transaction] PRIMARY KEY ([Id]) 
)

GO