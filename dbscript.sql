USE [master]
GO
/****** Object:  Database [BestBookDb]    Script Date: 2021-06-09 15:30:06 ******/
CREATE DATABASE [BestBookDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BestBookDb', FILENAME = N'C:\Users\oscar\BestBookDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BestBookDb_log', FILENAME = N'C:\Users\oscar\BestBookDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BestBookDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BestBookDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BestBookDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BestBookDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BestBookDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BestBookDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BestBookDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BestBookDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BestBookDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BestBookDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BestBookDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BestBookDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BestBookDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BestBookDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BestBookDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BestBookDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BestBookDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BestBookDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BestBookDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BestBookDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BestBookDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BestBookDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BestBookDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BestBookDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BestBookDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BestBookDb] SET  MULTI_USER 
GO
ALTER DATABASE [BestBookDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BestBookDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BestBookDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BestBookDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BestBookDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BestBookDb] SET QUERY_STORE = OFF
GO
USE [BestBookDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BestBookDb]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2021-06-09 15:30:06 ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 2021-06-09 15:30:06 ******/
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
	[PicLink] [nvarchar](100) NULL,
	[AvgStar] [decimal](3, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 2021-06-09 15:30:06 ******/
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
/****** Object:  Table [dbo].[Review]    Script Date: 2021-06-09 15:30:06 ******/
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

INSERT [dbo].[Book] ([ID], [Name], [Description], [GenreID], [AuthorID], [PicLink], [AvgStar]) VALUES (1, N'Dracula', N'Dracula is an epistolary novel, told through letters, diary entries, newspaper articles, telegrams, and a ships log. The novel is set mostly in Transylvania and England, and unfolds mostly chronologically between 3 May and 6 November.', 1, 1, NULL, NULL)
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
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([ID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD CHECK  (([Stars]<=(5) AND [Stars]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [BestBookDb] SET  READ_WRITE 
GO
