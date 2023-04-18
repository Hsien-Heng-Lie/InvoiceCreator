USE [Invoice_Creator]
GO
SET IDENTITY_INSERT [dbo].[LevelUp] ON 
GO
INSERT [dbo].[LevelUp] ([Id], [Name], [StartDate], [EndDate]) VALUES (1, N'Database Fundamentals', CAST(N'2023-01-27' AS Date), CAST(N'2023-02-24' AS Date))
GO
INSERT [dbo].[LevelUp] ([Id], [Name], [StartDate], [EndDate]) VALUES (2, N'Java and Spring Fundamentals', CAST(N'2023-02-24' AS Date), CAST(N'2023-03-24' AS Date))
GO
INSERT [dbo].[LevelUp] ([Id], [Name], [StartDate], [EndDate]) VALUES (3, N'C# and .Net Core Fundamentals', CAST(N'2023-03-24' AS Date), CAST(N'2023-04-21' AS Date))
GO
SET IDENTITY_INSERT [dbo].[LevelUp] OFF
GO
SET IDENTITY_INSERT [dbo].[QuestionDifficulty] ON 
GO
INSERT [dbo].[QuestionDifficulty] ([Id], [Name], [Description], [Cost]) VALUES (1, N'Easy', N'Short and simple', CAST(1.00 AS Decimal(30, 2)))
GO
INSERT [dbo].[QuestionDifficulty] ([Id], [Name], [Description], [Cost]) VALUES (2, N'Medium', N'Bit longer, bit complex', CAST(2.00 AS Decimal(30, 2)))
GO
INSERT [dbo].[QuestionDifficulty] ([Id], [Name], [Description], [Cost]) VALUES (3, N'Difficult', N'Thought Provoking', CAST(4.00 AS Decimal(30, 2)))
GO
INSERT [dbo].[QuestionDifficulty] ([Id], [Name], [Description], [Cost]) VALUES (4, N'What?', N'Deserves to be on Rudolph''s hitlist', CAST(1000.00 AS Decimal(30, 2)))
GO
SET IDENTITY_INSERT [dbo].[QuestionDifficulty] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 
GO
INSERT [dbo].[Question] ([Id], [Description], [QuestionDifficultyId], [LevelUpId]) VALUES (1, N'whats a database?', 2, 1)
GO
INSERT [dbo].[Question] ([Id], [Description], [QuestionDifficultyId], [LevelUpId]) VALUES (2, N'How much wood would a woodchuck chuck if a woodchuck could chuck wood?', 4, 2)
GO
INSERT [dbo].[Question] ([Id], [Description], [QuestionDifficultyId], [LevelUpId]) VALUES (3, N'What is EntityFramework and why can''t we use it?', 1, 3)
GO
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Email], [GradYear]) VALUES (1, N'Alwyn', N'Lie', N'hsien@bbd.co.za', CAST(N'2023-01-01' AS Date))
GO
INSERT [dbo].[Student] ([Id], [FirstName], [LastName], [Email], [GradYear]) VALUES (2, N'Ethan', N'Alberts', N'ImAlwaysSick@bbd.co.za', CAST(N'2023-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 
GO
INSERT [dbo].[Transaction] ([Id], [QuestionId], [StudentId]) VALUES (1, 1, 2)
GO
INSERT [dbo].[Transaction] ([Id], [QuestionId], [StudentId]) VALUES (2, 2, 2)
GO
INSERT [dbo].[Transaction] ([Id], [QuestionId], [StudentId]) VALUES (3, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
