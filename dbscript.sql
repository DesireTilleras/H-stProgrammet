USE [BestBookDb]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2021-06-15 10:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[HomeTown] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2021-06-15 10:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[GenreID] [int] NULL,
	[AuthorID] [int] NOT NULL,
	[PicLink] [nvarchar](4000) NULL,
	[AvgStar] [decimal](3, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 2021-06-15 10:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](32) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 2021-06-15 10:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Text] [nvarchar](500) NULL,
	[BookID] [int] NULL,
	[Stars] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([ID], [Name], [HomeTown]) VALUES (1, N'Bram Stoker', N'London')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Name], [Description], [GenreID], [AuthorID], [PicLink], [AvgStar]) VALUES (1002, N'Harry Potter and the deathly hallows', N'Voldemort is a bad guy. Harry must stop him.', 8, 1, N'https://images-na.ssl-images-amazon.com/images/I/81XQ0e5LfsL.jpg', CAST(5.00 AS Decimal(3, 2)))
INSERT [dbo].[Book] ([ID], [Name], [Description], [GenreID], [AuthorID], [PicLink], [AvgStar]) VALUES (1003, N'Harry Potter and the philosopher''s stone', N'Harry Potter is a wizard. He is awesome.', 8, 1, N'data:image/webp;base64,UklGRkAzAABXRUJQVlA4IDQzAABw4wCdASq0ABgBPpU8l0glo6IhMfTOoLASiWwzX40AyI+n+WHNz', NULL)
INSERT [dbo].[Book] ([ID], [Name], [Description], [GenreID], [AuthorID], [PicLink], [AvgStar]) VALUES (1004, N'Harry potter and the chamber of secrets', N'Harry finds out voldemort is the heir of slytherin.', 8, 1, N'https://upload.wikimedia.org/wikipedia/en/c/c0/Harry_Potter_and_the_Chamber_of_Secrets_movie.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (1, N'Horror')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (2, N'Adventure')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (3, N'Romance')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (4, N'Biography')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (5, N'Science fiction')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (6, N'Thriller')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (7, N'Mystery')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (8, N'Fantasy')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (9, N'Comics')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (10, N'Childrens')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([ID], [Name], [Text], [BookID], [Stars]) VALUES (6, N'Emanuel', N'Test1', 1002, 5)
INSERT [dbo].[Review] ([ID], [Name], [Text], [BookID], [Stars]) VALUES (9, N'Emanuel', N'Detta är den bästa boken någonsin. Jag tycker den är sååååååååå bra!', 1002, 5)
INSERT [dbo].[Review] ([ID], [Name], [Text], [BookID], [Stars]) VALUES (12, N'Emanuel', N'Test för att se att det fungerar med dolt fält', 1002, 5)
INSERT [dbo].[Review] ([ID], [Name], [Text], [BookID], [Stars]) VALUES (13, N'Emanuel', N'Bästa boken någonsin. Voldemort är en fjant och Snape är taskig.', 1003, 5)
INSERT [dbo].[Review] ([ID], [Name], [Text], [BookID], [Stars]) VALUES (14, N'Emanuel', N'Test avg stars', 1002, 5)
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([ID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__BookID__2B3F6F97] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__BookID__2B3F6F97]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD CHECK  (([Stars]<=(5) AND [Stars]>=(0)))
GO
