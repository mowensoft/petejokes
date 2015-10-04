USE [PeteJokes]
GO
/****** Object:  Table [dbo].[Evidence]    Script Date: 10/3/2015 8:30:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evidence](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JokeId] [int] NOT NULL,
	[MimeType] [varchar](100) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Evidence] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Joke]    Script Date: 10/3/2015 8:30:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Joke](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](4000) NOT NULL,
	[ToldOn] [datetime] NOT NULL,
	[Location] [varchar](255) NULL,
	[Latitude] [decimal](9, 6) NULL,
	[Longitude] [decimal](9, 6) NULL,
	[UpGoats] [int] NOT NULL,
	[DownBoats] [int] NOT NULL,
 CONSTRAINT [PK_Joke] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Joke] ADD  CONSTRAINT [DF_Joke_ToldOn]  DEFAULT (getdate()) FOR [ToldOn]
GO
ALTER TABLE [dbo].[Joke] ADD  CONSTRAINT [DF_Joke_UpGoats]  DEFAULT ((0)) FOR [UpGoats]
GO
ALTER TABLE [dbo].[Joke] ADD  CONSTRAINT [DF_Joke_DownBoats]  DEFAULT ((0)) FOR [DownBoats]
GO
ALTER TABLE [dbo].[Evidence]  WITH CHECK ADD  CONSTRAINT [FK_Evidence_Joke] FOREIGN KEY([JokeId])
REFERENCES [dbo].[Joke] ([Id])
GO
ALTER TABLE [dbo].[Evidence] CHECK CONSTRAINT [FK_Evidence_Joke]
GO
