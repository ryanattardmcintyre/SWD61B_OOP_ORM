USE [LibraryBooks]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 07/01/2021 14:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Isbn] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Publisher] [varchar](100) NOT NULL,
	[Year] [int] NOT NULL,
	[GenreFK] [int] NOT NULL,
	[Author] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 07/01/2021 14:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 07/01/2021 14:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](500) NOT NULL,
	[Rating] [int] NOT NULL,
	[BookFK] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Books] ([Isbn], [Name], [Publisher], [Year], [GenreFK], [Author]) VALUES (N'11111', N'bla bla bla', N'noname', 2000, 1, N'noname')
GO
INSERT [dbo].[Books] ([Isbn], [Name], [Publisher], [Year], [GenreFK], [Author]) VALUES (N'2', N'Test book', N'no one', 2020, 3, N'author1')
GO
INSERT [dbo].[Books] ([Isbn], [Name], [Publisher], [Year], [GenreFK], [Author]) VALUES (N'5', N'my new book name', N'My New Book Publishier', 2020, 2, N'My New book author')
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Fiction')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Narrative')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Novel')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Genres] FOREIGN KEY([GenreFK])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Genres]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Books] FOREIGN KEY([BookFK])
REFERENCES [dbo].[Books] ([Isbn])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Books]
GO
