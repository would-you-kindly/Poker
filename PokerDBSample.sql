USE [Poker]
GO
/****** Object:  Table [dbo].[CardQualities]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardQualities](
	[Id] [uniqueidentifier] NOT NULL,
	[CardQuality] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CardQualities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cards]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [uniqueidentifier] NOT NULL,
	[CardSuit] [uniqueidentifier] NOT NULL,
	[CardQuality] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardSuits]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardSuits](
	[Id] [uniqueidentifier] NOT NULL,
	[CardSuit] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CardSuits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Combinations]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combinations](
	[Id] [uniqueidentifier] NOT NULL,
	[CombinationType_Id] [uniqueidentifier] NOT NULL,
	[Card1_Id] [uniqueidentifier] NOT NULL,
	[Card2_Id] [uniqueidentifier] NOT NULL,
	[Card3_Id] [uniqueidentifier] NOT NULL,
	[Card4_Id] [uniqueidentifier] NOT NULL,
	[Card5_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Combinations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CombinationTypes]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CombinationTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Weight] [int] NOT NULL,
	[CombinationType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CombinationTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Distributions]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distributions](
	[Id] [uniqueidentifier] NOT NULL,
	[Player_Id] [uniqueidentifier] NOT NULL,
	[Hand_Id] [uniqueidentifier] NOT NULL,
	[Card1_Id] [uniqueidentifier] NOT NULL,
	[Card2_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Distributions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hands]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hands](
	[Id] [uniqueidentifier] NOT NULL,
	[Outcome] [uniqueidentifier] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[FinishTime] [datetime] NOT NULL,
	[Bank] [int] NOT NULL,
 CONSTRAINT [PK_Hands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutcomeTypes]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutcomeTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[OutcomeType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OutcomeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Players]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Account] [int] NOT NULL,
	[LastTimeRequest1000] [datetime] NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rates]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[Id] [uniqueidentifier] NOT NULL,
	[Turn_Id] [uniqueidentifier] NOT NULL,
	[RateTypes_Id] [uniqueidentifier] NOT NULL,
	[Rate] [int] NOT NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RateTypes]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[RateType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RateTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Turns]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turns](
	[Id] [uniqueidentifier] NOT NULL,
	[Hand_Id] [uniqueidentifier] NOT NULL,
	[TurnType_Id] [uniqueidentifier] NOT NULL,
	[Player_Id] [uniqueidentifier] NOT NULL,
	[TurnTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Turns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TurnTypes]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurnTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[TurnType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TurnTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Victories]    Script Date: 16.03.2018 1:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Victories](
	[Id] [uniqueidentifier] NOT NULL,
	[Player_Id] [uniqueidentifier] NOT NULL,
	[WinCombination_Id] [uniqueidentifier] NULL,
	[Hand_Id] [uniqueidentifier] NOT NULL,
	[Benefit] [int] NOT NULL,
 CONSTRAINT [PK_Victories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'e7544ed4-23fb-4d37-bf3f-070f537e210f', N'King')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'e0ab67c3-e4da-4aa6-a1c7-0fef63559089', N'4')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'139d43ec-a57a-4634-a106-2b35aca73907', N'5')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'b309bfbc-d789-4103-ae35-2cbc990f514d', N'10')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'409a12c5-ba87-4a87-86e2-2ea6bf7cfb8e', N'6')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'72768feb-2dbb-4d7d-b3fd-370246c2c80b', N'7')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'de419bfd-e4d2-4102-ad75-73c77059c90d', N'9')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'3ed1536d-14fa-486b-8f6b-8504c79ad311', N'Jack')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'34b5f0ad-1617-4181-a1aa-92e9af4ec5e9', N'Ace')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'07d1435a-052d-42aa-a50d-bbe7104b265a', N'8')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'b171f4a0-1815-473b-be50-cc37aefc07cd', N'Queen')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'10b84e1b-e662-4b69-9142-d90975375d2a', N'3')
INSERT [dbo].[CardQualities] ([Id], [CardQuality]) VALUES (N'ae1703d4-1505-4e65-b509-ef0c96ede1be', N'2')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ef1e1d1e-306c-4a27-b2a0-05e5aebf529e', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'72768feb-2dbb-4d7d-b3fd-370246c2c80b')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'7d434dc4-2a10-4362-bda0-0947de207b82', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'72768feb-2dbb-4d7d-b3fd-370246c2c80b')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'bb80d48c-0928-4fb4-bc7d-1a4ed658c9f6', N'892de494-56f3-4816-871e-9ae5be491f89', N'139d43ec-a57a-4634-a106-2b35aca73907')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'eb3e8dc8-7809-4ac1-b771-1c8a71eaf7cb', N'892de494-56f3-4816-871e-9ae5be491f89', N'ae1703d4-1505-4e65-b509-ef0c96ede1be')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ec528549-7e44-4b19-b580-1e446ee07df3', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'3ed1536d-14fa-486b-8f6b-8504c79ad311')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'60b6396f-d8ee-4245-bbaf-24fdef0cca37', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'139d43ec-a57a-4634-a106-2b35aca73907')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'85e57f93-3808-4568-961b-27d370e01e5e', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'07d1435a-052d-42aa-a50d-bbe7104b265a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'c217cbfe-4e7c-4884-bb49-2e3273ac2527', N'892de494-56f3-4816-871e-9ae5be491f89', N'3ed1536d-14fa-486b-8f6b-8504c79ad311')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'84e64117-ec7a-43b8-8631-2fa6acfe6fea', N'892de494-56f3-4816-871e-9ae5be491f89', N'07d1435a-052d-42aa-a50d-bbe7104b265a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'e708859b-58b7-4bd4-bae9-3b7b3caf1c10', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'139d43ec-a57a-4634-a106-2b35aca73907')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'5ef0a56c-71db-47b2-9c21-3e5daa1c3096', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'de419bfd-e4d2-4102-ad75-73c77059c90d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'f11977d4-46d8-4c3d-83dd-402baf1113c4', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'b309bfbc-d789-4103-ae35-2cbc990f514d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'5747cafa-21ad-4725-9554-427fcdacc5f9', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'ae1703d4-1505-4e65-b509-ef0c96ede1be')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'775ba8ec-1ae5-4c50-b2b7-43095dd2c4ee', N'892de494-56f3-4816-871e-9ae5be491f89', N'10b84e1b-e662-4b69-9142-d90975375d2a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'3569bd5a-f567-42b3-885d-4a3d0a0d3074', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'b171f4a0-1815-473b-be50-cc37aefc07cd')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'aa3e225b-8762-4265-9151-4dda680cd444', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'10b84e1b-e662-4b69-9142-d90975375d2a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'7515d5f9-aa4a-4751-8001-57231935ad24', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'3ed1536d-14fa-486b-8f6b-8504c79ad311')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'12d59c6f-75fd-48b5-a065-57c61e1bb29c', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'e7544ed4-23fb-4d37-bf3f-070f537e210f')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ff6b1be4-d223-4e21-b9b4-5806a763585b', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'b171f4a0-1815-473b-be50-cc37aefc07cd')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'c350e6e3-92d6-491b-9887-5b4e374a380c', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'139d43ec-a57a-4634-a106-2b35aca73907')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'f8592a75-d03c-4d75-9f23-66c1b0684158', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'10b84e1b-e662-4b69-9142-d90975375d2a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'eb1478cd-bd81-430d-851b-6b736de8a27e', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'e0ab67c3-e4da-4aa6-a1c7-0fef63559089')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'eb3d0ce0-e5c4-472c-9a46-6c4b41d3f336', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'409a12c5-ba87-4a87-86e2-2ea6bf7cfb8e')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'b48f0dea-0462-41cf-8f7f-6d5e8165df36', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'10b84e1b-e662-4b69-9142-d90975375d2a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'fe3938ee-bd93-4b37-8ce8-6dc3c6428924', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'07d1435a-052d-42aa-a50d-bbe7104b265a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'874b823d-f3f7-4487-99fb-6efdc4186b74', N'892de494-56f3-4816-871e-9ae5be491f89', N'b309bfbc-d789-4103-ae35-2cbc990f514d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ce688ef9-1632-4ca1-960c-7907f964ab42', N'892de494-56f3-4816-871e-9ae5be491f89', N'e7544ed4-23fb-4d37-bf3f-070f537e210f')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'3028ade8-07b8-472c-a36a-8ae53c9c8b28', N'892de494-56f3-4816-871e-9ae5be491f89', N'72768feb-2dbb-4d7d-b3fd-370246c2c80b')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'6bdeafae-ac75-46b8-b07c-8fc0b9cb357c', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'07d1435a-052d-42aa-a50d-bbe7104b265a')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'de477507-8d5e-4cd3-a657-92874bcb8757', N'892de494-56f3-4816-871e-9ae5be491f89', N'409a12c5-ba87-4a87-86e2-2ea6bf7cfb8e')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'c9da8152-929b-4bea-946b-9432bc7b7cc1', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'409a12c5-ba87-4a87-86e2-2ea6bf7cfb8e')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'76732c77-15d8-4be9-b17d-a0e0efa0c5ef', N'892de494-56f3-4816-871e-9ae5be491f89', N'e0ab67c3-e4da-4aa6-a1c7-0fef63559089')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'0f1f89b9-8205-4a39-9d09-afc9e29d21b9', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'ae1703d4-1505-4e65-b509-ef0c96ede1be')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ad1fc074-80e4-4664-b49a-b171335715e2', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'34b5f0ad-1617-4181-a1aa-92e9af4ec5e9')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'a8e9f97a-1570-4514-a10b-b4bf8bb43c1d', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'3ed1536d-14fa-486b-8f6b-8504c79ad311')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ab6308af-bf04-46cb-b52b-ba11c1377035', N'892de494-56f3-4816-871e-9ae5be491f89', N'b171f4a0-1815-473b-be50-cc37aefc07cd')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'6d54783d-46a2-4186-a64a-c243586693e4', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'e7544ed4-23fb-4d37-bf3f-070f537e210f')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'9b3f94d9-681b-43fe-9b5c-c6b38d56d495', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'e7544ed4-23fb-4d37-bf3f-070f537e210f')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'f447839c-f54e-4ec3-8a51-d62aef0b064f', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'e0ab67c3-e4da-4aa6-a1c7-0fef63559089')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'd4f8584b-f417-4332-9c5d-d6f2fe21b98d', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'72768feb-2dbb-4d7d-b3fd-370246c2c80b')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ce96612f-63fc-45d6-82a8-d951e4841794', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'34b5f0ad-1617-4181-a1aa-92e9af4ec5e9')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'1ec071af-cf6f-4bdb-afd1-dadb366b540f', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'de419bfd-e4d2-4102-ad75-73c77059c90d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'83029598-6727-4051-9ca6-dc3bfbd5a54e', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'b171f4a0-1815-473b-be50-cc37aefc07cd')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ecab6372-a215-478e-9660-de5a76f2b5c4', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'e0ab67c3-e4da-4aa6-a1c7-0fef63559089')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'30c714d0-c949-486b-912b-e35589162b1e', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'de419bfd-e4d2-4102-ad75-73c77059c90d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'ed8686cb-90cd-406e-a758-ea8fdc93d4cb', N'892de494-56f3-4816-871e-9ae5be491f89', N'34b5f0ad-1617-4181-a1aa-92e9af4ec5e9')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'6e81aa0e-2058-4ab5-bba8-ecd3490585cb', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'ae1703d4-1505-4e65-b509-ef0c96ede1be')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'9a34e315-dc9a-440a-9885-ed60532f86fa', N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'b309bfbc-d789-4103-ae35-2cbc990f514d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'c728685b-2319-4a39-a604-f53a1cabe7b8', N'892de494-56f3-4816-871e-9ae5be491f89', N'de419bfd-e4d2-4102-ad75-73c77059c90d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'64088d67-b8ab-41bf-9dfa-f7ebe7b2baff', N'4aeda601-3085-481f-8043-c8817aadc7b4', N'409a12c5-ba87-4a87-86e2-2ea6bf7cfb8e')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'728bf350-bb6c-4cc5-b0ad-fcab81869b93', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'b309bfbc-d789-4103-ae35-2cbc990f514d')
INSERT [dbo].[Cards] ([Id], [CardSuit], [CardQuality]) VALUES (N'f793a2b3-8fae-4a50-9b37-fdb3f10061a8', N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'34b5f0ad-1617-4181-a1aa-92e9af4ec5e9')
INSERT [dbo].[CardSuits] ([Id], [CardSuit]) VALUES (N'892de494-56f3-4816-871e-9ae5be491f89', N'Diamonds')
INSERT [dbo].[CardSuits] ([Id], [CardSuit]) VALUES (N'eef57c98-e4ad-47aa-87b1-b87e997325c9', N'Hearts')
INSERT [dbo].[CardSuits] ([Id], [CardSuit]) VALUES (N'4aeda601-3085-481f-8043-c8817aadc7b4', N'Spades')
INSERT [dbo].[CardSuits] ([Id], [CardSuit]) VALUES (N'43bf5bdb-6e46-49a0-971d-f4896dbeb68d', N'Clubs')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'3e8256e2-358d-44ab-a049-359dc452b752', 201, N'Royal flush')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'f66e8a91-8511-4992-8b06-3c495b64c39b', 7, N'Three of a kind')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'49450e6b-5cc5-406b-ad45-4ddc2e5441d5', 5, N'Two pairs')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'8ce9fdfd-6105-4b6a-8ee7-53218d5268db', 101, N'Straight flush')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'b798924c-fb78-4072-9cfe-6a06df9dc42d', 11, N'Flush')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'ecca0b32-1092-4a1d-88e1-87a79cad0f61', 41, N'Four of a kind')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'fda27460-9949-4e86-97e8-8bf71f2821c4', 3, N'One pair')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'2d9a10fb-cccc-4e3a-9477-cf26fe4651d6', 15, N'Full house')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'1da9683e-6df8-48ac-9a5e-d1cd1acc4c3a', 9, N'Straight')
INSERT [dbo].[CombinationTypes] ([Id], [Weight], [CombinationType]) VALUES (N'0be75ca1-5f4b-4d4f-8254-ec7be33251c3', 1, N'High card')
INSERT [dbo].[Distributions] ([Id], [Player_Id], [Hand_Id], [Card1_Id], [Card2_Id]) VALUES (N'3531b269-3e89-4b8e-ae7b-3db4ba5e4cb2', N'64e94343-418f-4640-a49a-0467196a9983', N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'30c714d0-c949-486b-912b-e35589162b1e', N'de477507-8d5e-4cd3-a657-92874bcb8757')
INSERT [dbo].[Distributions] ([Id], [Player_Id], [Hand_Id], [Card1_Id], [Card2_Id]) VALUES (N'ad68f36d-9f31-445e-b50d-bd12ac6e22c2', N'299b0040-1204-4a75-8595-084218ab5628', N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'5747cafa-21ad-4725-9554-427fcdacc5f9', N'f793a2b3-8fae-4a50-9b37-fdb3f10061a8')
INSERT [dbo].[Hands] ([Id], [Outcome], [StartTime], [FinishTime], [Bank]) VALUES (N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'a9b8d01d-4a5e-4f18-adff-4ca16ff584e3', CAST(N'2018-03-16T01:21:01.003' AS DateTime), CAST(N'2018-03-16T01:40:00.160' AS DateTime), 30)
INSERT [dbo].[OutcomeTypes] ([Id], [OutcomeType]) VALUES (N'a9b8d01d-4a5e-4f18-adff-4ca16ff584e3', N'Win')
INSERT [dbo].[OutcomeTypes] ([Id], [OutcomeType]) VALUES (N'e491b208-7d2e-4071-804f-7a210d376aea', N'Draw')
INSERT [dbo].[Players] ([Id], [Name], [Login], [Password], [Account], [LastTimeRequest1000]) VALUES (N'64e94343-418f-4640-a49a-0467196a9983', N'Алексей', N'lixich', N'123456', 1000, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Login], [Password], [Account], [LastTimeRequest1000]) VALUES (N'299b0040-1204-4a75-8595-084218ab5628', N'Александр', N'smalex', N'123456', 1000, NULL)
INSERT [dbo].[Rates] ([Id], [Turn_Id], [RateTypes_Id], [Rate]) VALUES (N'487a9b0d-3b1c-4f3a-9c04-56cc7b842d95', N'40bb1bce-e0c0-49c1-9184-fa09aaaab496', N'96a90d18-fcce-4689-bd88-e1208e9af588', 20)
INSERT [dbo].[Rates] ([Id], [Turn_Id], [RateTypes_Id], [Rate]) VALUES (N'ae3e90f2-83f7-4c5d-aafa-d6f38577a302', N'f971f019-bbd1-4954-aa68-776fcb2fca82', N'f934857e-7736-4b1c-afae-8a6ee1b97870', 10)
INSERT [dbo].[RateTypes] ([Id], [RateType]) VALUES (N'f934857e-7736-4b1c-afae-8a6ee1b97870', N'Small blind')
INSERT [dbo].[RateTypes] ([Id], [RateType]) VALUES (N'96a90d18-fcce-4689-bd88-e1208e9af588', N'Big blind')
INSERT [dbo].[RateTypes] ([Id], [RateType]) VALUES (N'a61d52fe-46e2-4160-95bd-e40a421b7c17', N'Normal')
INSERT [dbo].[Turns] ([Id], [Hand_Id], [TurnType_Id], [Player_Id], [TurnTime]) VALUES (N'f971f019-bbd1-4954-aa68-776fcb2fca82', N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'27f2a574-1b0f-4802-86d9-4f3a4aebd891', N'299b0040-1204-4a75-8595-084218ab5628', CAST(N'2018-03-16T01:22:49.557' AS DateTime))
INSERT [dbo].[Turns] ([Id], [Hand_Id], [TurnType_Id], [Player_Id], [TurnTime]) VALUES (N'cad48f15-4fb2-48c0-ae1d-c69ff20e2074', N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'92607893-1484-441e-932f-4b4df1fd1004', N'64e94343-418f-4640-a49a-0467196a9983', CAST(N'2018-03-16T01:38:42.647' AS DateTime))
INSERT [dbo].[Turns] ([Id], [Hand_Id], [TurnType_Id], [Player_Id], [TurnTime]) VALUES (N'40bb1bce-e0c0-49c1-9184-fa09aaaab496', N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', N'27f2a574-1b0f-4802-86d9-4f3a4aebd891', N'64e94343-418f-4640-a49a-0467196a9983', CAST(N'2018-03-16T01:22:49.550' AS DateTime))
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'cf9e6863-d8f2-4f33-a4ff-310d22fff498', N'Bet')
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'92607893-1484-441e-932f-4b4df1fd1004', N'Fold')
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'27f2a574-1b0f-4802-86d9-4f3a4aebd891', N'Ante')
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'6d553efb-0e00-4fa2-9cd2-995451f2dae6', N'Check')
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'61870b43-1b5d-457b-adf7-c3d634dd16e5', N'Call')
INSERT [dbo].[TurnTypes] ([Id], [TurnType]) VALUES (N'1916d79b-df42-43de-bc13-c81931461624', N'Raise')
INSERT [dbo].[Victories] ([Id], [Player_Id], [WinCombination_Id], [Hand_Id], [Benefit]) VALUES (N'4184316a-8e8a-45a2-b697-05b1470605b2', N'299b0040-1204-4a75-8595-084218ab5628', NULL, N'66c1fda3-2156-45f5-80fd-4743b2e0ca04', 10)
