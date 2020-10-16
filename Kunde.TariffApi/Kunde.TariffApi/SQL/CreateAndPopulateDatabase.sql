-- Change at bottom also required
USE [NettTariff-dev]
--USE [NettTariff-test]
--USE [NettTariff-prod]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fixedpriceconfig]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fixedpriceconfig](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tarifftypeid] [int] NOT NULL,
	[seasonid] [int] NOT NULL,
	[monthno] [int] NOT NULL,
	[pricelevelid] [int] NOT NULL,
	[total] [decimal](10, 4) NOT NULL,
	[fixed] [decimal](10, 4) NOT NULL,
	[taxes] [decimal](10, 4) NOT NULL,
	[uomid] [int] NOT NULL,
	[pricefromdate] [date] NOT NULL,
	[pricetodate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fixedpricelevel]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fixedpricelevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pricelevel] [varchar](100) NOT NULL,
	[levelinfo] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hours]    Script Date: 13.10.2020 09:15:56 ******/
/****** Object:  Table [dbo].[pricelevel]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pricelevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sortorder] [int] NOT NULL,
	[pricelevel] [varchar](100) NOT NULL,PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publicholiday]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publicholiday](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[holidaydate] [date] NOT NULL,
	[description] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[season]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[season](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[season] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarifftype]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarifftype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tariffkey] [varchar](100) NOT NULL,
	[companyid] [int] NOT NULL,
	[customertype] [varchar](100) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[resolution] [int] NOT NULL,
	[description] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uom]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uom](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[currency] [varchar](100) NOT NULL,
	[uom] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[variablepriceconfig]    Script Date: 13.10.2020 09:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[variablepriceconfig](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tarifftypeid] [int] NOT NULL,
	[seasonid] [int] NOT NULL,
	[monthno] [int] NOT NULL,
	[pricelevelid] [int] NOT NULL,
	[total] [decimal](10, 4) NOT NULL,
	[energy] [decimal](10, 4) NOT NULL,
	[power_] [decimal](10, 4) NOT NULL,
	[taxmva] [decimal](10, 4) NOT NULL,
	[taxenova] [decimal](10, 4) NOT NULL,
	[taxenergy] [decimal](10, 4) NOT NULL,
	[uomid] [int] NOT NULL,
	[pricefromdate] [date] NOT NULL,
	[pricetodate] [date] NOT NULL,
	[hours] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[company] ON 
GO
INSERT [dbo].[company] ([id], [company]) VALUES (1, N'Elvia AS')
GO
SET IDENTITY_INSERT [dbo].[company] OFF
GO
SET IDENTITY_INSERT [dbo].[fixedpriceconfig] ON 
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (1, 1, 5, 1, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (2, 1, 5, 2, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (3, 1, 5, 3, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (4, 1, 2, 4, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (5, 1, 2, 5, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (6, 1, 2, 6, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (7, 1, 2, 7, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (8, 1, 2, 8, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (9, 1, 2, 9, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (10, 1, 2, 10, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (11, 1, 5, 11, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (12, 1, 5, 12, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (13, 2, 5, 1, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (14, 2, 5, 2, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (15, 2, 5, 3, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (16, 2, 2, 4, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (17, 2, 2, 5, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (18, 2, 2, 6, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (19, 2, 2, 7, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (20, 2, 2, 8, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (21, 2, 2, 9, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (22, 2, 2, 10, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (23, 2, 5, 11, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (24, 2, 5, 12, 2, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (25, 3, 5, 1, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (26, 3, 5, 2, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (27, 3, 5, 3, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (28, 3, 2, 4, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (29, 3, 2, 5, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (30, 3, 2, 6, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (31, 3, 2, 7, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (32, 3, 2, 8, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (33, 3, 2, 9, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (34, 3, 2, 10, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (35, 3, 5, 11, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (36, 3, 5, 12, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[fixedpriceconfig] OFF
GO
SET IDENTITY_INSERT [dbo].[fixedpricelevel] ON 
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (1, N'Level1', N'For alle privatkunder')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (2, N'Level2', N'For alle privatkunder')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (3, N'Level3', N'For kunder med årlig forbruk 15.000-20.000 kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (4, N'Level4', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (5, N'Level5', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (6, N'Level6', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (7, N'Level7', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (8, N'Level8', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (9, N'Level9', N'For kunder med årlig forbruk X kWh')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (10, N'Level10', N'For kunder med årlig forbruk X kWh')
GO
SET IDENTITY_INSERT [dbo].[fixedpricelevel] OFF
GO
SET IDENTITY_INSERT [dbo].[pricelevel] ON 
GO
INSERT [dbo].[pricelevel] ([id], [sortorder], [pricelevel]) VALUES (2,1, N'CHEAP')
GO
INSERT [dbo].[pricelevel] ([id], [sortorder],[pricelevel]) VALUES (4,3, N'EXPENSIVE')
GO
INSERT [dbo].[pricelevel] ([id], [sortorder], [pricelevel]) VALUES (3,2, N'NORMAL')
GO
INSERT [dbo].[pricelevel] ([id], [sortorder], [pricelevel]) VALUES (1,0, N'VERY_CHEAP')
GO
INSERT [dbo].[pricelevel] ([id], [sortorder], [pricelevel]) VALUES (5,4, N'VERY_EXPENSIVE')
GO
SET IDENTITY_INSERT [dbo].[pricelevel] OFF
GO
SET IDENTITY_INSERT [dbo].[publicholiday] ON 
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (1, CAST(N'2020-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (2, CAST(N'2020-04-05' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (3, CAST(N'2020-04-09' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (4, CAST(N'2020-04-10' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (5, CAST(N'2020-04-12' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (6, CAST(N'2020-04-13' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (7, CAST(N'2020-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (8, CAST(N'2020-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (9, CAST(N'2020-05-21' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (10, CAST(N'2020-05-31' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (11, CAST(N'2020-06-01' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (12, CAST(N'2020-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (13, CAST(N'2020-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (14, CAST(N'2021-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (15, CAST(N'2021-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (16, CAST(N'2021-05-24' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (17, CAST(N'2021-05-23' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (18, CAST(N'2021-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (19, CAST(N'2021-05-13' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (20, CAST(N'2021-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (21, CAST(N'2021-04-05' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (22, CAST(N'2021-04-04' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (23, CAST(N'2021-04-02' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (24, CAST(N'2021-04-01' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (25, CAST(N'2021-03-28' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (26, CAST(N'2021-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (27, CAST(N'2022-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (28, CAST(N'2022-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (29, CAST(N'2022-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (30, CAST(N'2022-06-05' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (31, CAST(N'2022-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (32, CAST(N'2022-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (33, CAST(N'2022-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (34, CAST(N'2022-04-18' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (35, CAST(N'2022-04-17' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (36, CAST(N'2022-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (37, CAST(N'2022-04-14' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (38, CAST(N'2022-04-10' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (39, CAST(N'2022-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (40, CAST(N'2023-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (41, CAST(N'2023-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (42, CAST(N'2023-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (43, CAST(N'2023-05-28' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (44, CAST(N'2023-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (45, CAST(N'2023-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (46, CAST(N'2023-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (47, CAST(N'2023-04-10' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (48, CAST(N'2023-04-09' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (49, CAST(N'2023-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (50, CAST(N'2023-04-06' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (51, CAST(N'2023-04-02' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (52, CAST(N'2023-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (53, CAST(N'2024-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (54, CAST(N'2024-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (55, CAST(N'2024-05-20' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (56, CAST(N'2024-05-19' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (57, CAST(N'2024-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (58, CAST(N'2024-05-09' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (59, CAST(N'2024-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (60, CAST(N'2024-04-01' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (61, CAST(N'2024-03-31' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (62, CAST(N'2024-03-29' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (63, CAST(N'2024-03-28' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (64, CAST(N'2024-03-24' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (65, CAST(N'2024-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (66, CAST(N'2025-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (67, CAST(N'2025-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (68, CAST(N'2025-06-09' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (69, CAST(N'2025-06-08' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (70, CAST(N'2025-05-29' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (71, CAST(N'2025-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (72, CAST(N'2025-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (73, CAST(N'2025-04-21' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (74, CAST(N'2025-04-20' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (75, CAST(N'2025-04-18' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (76, CAST(N'2025-04-17' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (77, CAST(N'2025-04-13' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (78, CAST(N'2025-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (79, CAST(N'2026-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (80, CAST(N'2026-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (81, CAST(N'2026-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (82, CAST(N'2026-05-24' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (83, CAST(N'2026-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (84, CAST(N'2026-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (85, CAST(N'2026-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (86, CAST(N'2026-04-06' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (87, CAST(N'2026-04-05' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (88, CAST(N'2026-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (89, CAST(N'2026-04-02' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (90, CAST(N'2026-03-29' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (91, CAST(N'2026-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (92, CAST(N'2027-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (93, CAST(N'2027-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (94, CAST(N'2027-05-17' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (95, CAST(N'2027-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (96, CAST(N'2027-05-16' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (97, CAST(N'2027-05-06' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (98, CAST(N'2027-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (99, CAST(N'2027-03-29' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (100, CAST(N'2027-03-28' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (101, CAST(N'2027-03-26' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (102, CAST(N'2027-03-25' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (103, CAST(N'2027-03-21' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (104, CAST(N'2027-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (105, CAST(N'2028-06-05' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (106, CAST(N'2028-06-04' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (107, CAST(N'2028-05-25' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (108, CAST(N'2028-04-17' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (109, CAST(N'2028-04-16' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (110, CAST(N'2028-04-14' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (111, CAST(N'2028-04-13' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (112, CAST(N'2028-04-09' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (113, CAST(N'2028-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (114, CAST(N'2028-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (115, CAST(N'2028-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (116, CAST(N'2028-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (117, CAST(N'2028-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (118, CAST(N'2029-05-21' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (119, CAST(N'2029-05-20' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (120, CAST(N'2029-05-10' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (121, CAST(N'2029-04-02' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (122, CAST(N'2029-04-01' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (123, CAST(N'2029-03-30' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (124, CAST(N'2029-03-29' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (125, CAST(N'2029-03-25' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (126, CAST(N'2029-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (127, CAST(N'2029-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (128, CAST(N'2029-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (129, CAST(N'2029-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (130, CAST(N'2029-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (131, CAST(N'2030-06-10' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (132, CAST(N'2030-06-09' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (133, CAST(N'2030-05-30' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (134, CAST(N'2030-04-22' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (135, CAST(N'2030-04-21' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (136, CAST(N'2030-04-19' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (137, CAST(N'2030-04-18' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (138, CAST(N'2030-04-14' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (139, CAST(N'2030-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (140, CAST(N'2030-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (141, CAST(N'2030-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (142, CAST(N'2030-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (143, CAST(N'2030-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (144, CAST(N'2031-06-02' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (145, CAST(N'2031-06-01' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (146, CAST(N'2031-05-22' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (147, CAST(N'2031-04-14' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (148, CAST(N'2031-04-13' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (149, CAST(N'2031-04-11' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (150, CAST(N'2031-04-10' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (151, CAST(N'2031-04-06' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (152, CAST(N'2031-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (153, CAST(N'2031-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (154, CAST(N'2031-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (155, CAST(N'2031-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (156, CAST(N'2031-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (157, CAST(N'2032-05-17' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (158, CAST(N'2032-05-16' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (159, CAST(N'2032-05-06' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (160, CAST(N'2032-03-29' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (161, CAST(N'2032-03-28' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (162, CAST(N'2032-03-26' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (163, CAST(N'2032-03-25' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (164, CAST(N'2032-03-21' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (165, CAST(N'2032-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (166, CAST(N'2032-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (167, CAST(N'2032-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (168, CAST(N'2032-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (169, CAST(N'2032-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (170, CAST(N'2033-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (171, CAST(N'2033-06-05' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (172, CAST(N'2033-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (173, CAST(N'2033-04-18' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (174, CAST(N'2033-04-17' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (175, CAST(N'2033-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (176, CAST(N'2033-04-14' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (177, CAST(N'2033-04-10' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (178, CAST(N'2033-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (179, CAST(N'2033-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (180, CAST(N'2033-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (181, CAST(N'2033-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (182, CAST(N'2033-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (183, CAST(N'2034-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (184, CAST(N'2034-05-28' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (185, CAST(N'2034-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (186, CAST(N'2034-04-10' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (187, CAST(N'2034-04-09' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (188, CAST(N'2034-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (189, CAST(N'2034-04-06' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (190, CAST(N'2034-04-02' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (191, CAST(N'2034-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (192, CAST(N'2034-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (193, CAST(N'2034-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (194, CAST(N'2034-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (195, CAST(N'2034-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (196, CAST(N'2035-05-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (197, CAST(N'2035-05-13' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (198, CAST(N'2035-05-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (199, CAST(N'2035-03-26' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (200, CAST(N'2035-03-25' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (201, CAST(N'2035-03-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (202, CAST(N'2035-03-22' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (203, CAST(N'2035-03-18' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (204, CAST(N'2035-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (205, CAST(N'2035-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (206, CAST(N'2035-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (207, CAST(N'2035-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (208, CAST(N'2035-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (209, CAST(N'2036-06-02' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (210, CAST(N'2036-06-01' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (211, CAST(N'2036-05-22' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (212, CAST(N'2036-04-14' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (213, CAST(N'2036-04-13' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (214, CAST(N'2036-04-11' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (215, CAST(N'2036-04-10' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (216, CAST(N'2036-04-06' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (217, CAST(N'2036-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (218, CAST(N'2036-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (219, CAST(N'2036-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (220, CAST(N'2036-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (221, CAST(N'2036-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (222, CAST(N'2037-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (223, CAST(N'2037-05-24' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (224, CAST(N'2037-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (225, CAST(N'2037-04-06' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (226, CAST(N'2037-04-05' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (227, CAST(N'2037-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (228, CAST(N'2037-04-02' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (229, CAST(N'2037-03-29' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (230, CAST(N'2037-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (231, CAST(N'2037-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (232, CAST(N'2037-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (233, CAST(N'2037-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (234, CAST(N'2037-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (235, CAST(N'2038-06-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (236, CAST(N'2038-06-13' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (237, CAST(N'2038-06-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (238, CAST(N'2038-04-26' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (239, CAST(N'2038-04-25' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (240, CAST(N'2038-04-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (241, CAST(N'2038-04-22' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (242, CAST(N'2038-04-18' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (243, CAST(N'2038-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (244, CAST(N'2038-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (245, CAST(N'2038-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (246, CAST(N'2038-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (247, CAST(N'2038-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (248, CAST(N'2039-05-30' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (249, CAST(N'2039-05-29' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (250, CAST(N'2039-05-19' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (251, CAST(N'2039-04-11' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (252, CAST(N'2039-04-10' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (253, CAST(N'2039-04-08' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (254, CAST(N'2039-04-07' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (255, CAST(N'2039-04-03' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (256, CAST(N'2039-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (257, CAST(N'2039-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (258, CAST(N'2039-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (259, CAST(N'2039-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (260, CAST(N'2039-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (261, CAST(N'2040-05-21' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (262, CAST(N'2040-05-20' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (263, CAST(N'2040-05-10' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (264, CAST(N'2040-04-02' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (265, CAST(N'2040-04-01' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (266, CAST(N'2040-03-30' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (267, CAST(N'2040-03-29' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (268, CAST(N'2040-03-25' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (269, CAST(N'2040-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (270, CAST(N'2040-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (271, CAST(N'2040-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (272, CAST(N'2040-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (273, CAST(N'2040-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (274, CAST(N'2041-06-10' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (275, CAST(N'2041-06-09' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (276, CAST(N'2041-05-30' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (277, CAST(N'2041-04-22' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (278, CAST(N'2041-04-21' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (279, CAST(N'2041-04-19' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (280, CAST(N'2041-04-18' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (281, CAST(N'2041-04-14' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (282, CAST(N'2041-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (283, CAST(N'2041-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (284, CAST(N'2041-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (285, CAST(N'2041-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (286, CAST(N'2041-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (287, CAST(N'2042-05-26' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (288, CAST(N'2042-05-25' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (289, CAST(N'2042-05-15' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (290, CAST(N'2042-04-07' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (291, CAST(N'2042-04-06' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (292, CAST(N'2042-04-04' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (293, CAST(N'2042-04-03' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (294, CAST(N'2042-03-30' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (295, CAST(N'2042-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (296, CAST(N'2042-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (297, CAST(N'2042-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (298, CAST(N'2042-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (299, CAST(N'2042-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (300, CAST(N'2043-05-18' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (301, CAST(N'2043-05-17' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (302, CAST(N'2043-05-07' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (303, CAST(N'2043-03-30' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (304, CAST(N'2043-03-29' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (305, CAST(N'2043-03-27' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (306, CAST(N'2043-03-26' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (307, CAST(N'2043-03-22' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (308, CAST(N'2043-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (309, CAST(N'2043-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (310, CAST(N'2043-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (311, CAST(N'2043-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (312, CAST(N'2043-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (313, CAST(N'2044-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (314, CAST(N'2044-06-05' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (315, CAST(N'2044-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (316, CAST(N'2044-04-18' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (317, CAST(N'2044-04-17' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (318, CAST(N'2044-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (319, CAST(N'2044-04-14' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (320, CAST(N'2044-04-10' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (321, CAST(N'2044-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (322, CAST(N'2044-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (323, CAST(N'2044-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (324, CAST(N'2044-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (325, CAST(N'2044-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (326, CAST(N'2045-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (327, CAST(N'2045-05-28' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (328, CAST(N'2045-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (329, CAST(N'2045-04-10' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (330, CAST(N'2045-04-09' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (331, CAST(N'2045-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (332, CAST(N'2045-04-06' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (333, CAST(N'2045-04-02' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (334, CAST(N'2045-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (335, CAST(N'2045-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (336, CAST(N'2045-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (337, CAST(N'2045-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (338, CAST(N'2045-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (339, CAST(N'2046-05-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (340, CAST(N'2046-05-13' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (341, CAST(N'2046-05-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (342, CAST(N'2046-03-26' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (343, CAST(N'2046-03-25' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (344, CAST(N'2046-03-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (345, CAST(N'2046-03-22' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (346, CAST(N'2046-03-18' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (347, CAST(N'2046-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (348, CAST(N'2046-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (349, CAST(N'2046-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (350, CAST(N'2046-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (351, CAST(N'2046-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (352, CAST(N'2047-06-03' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (353, CAST(N'2047-06-02' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (354, CAST(N'2047-05-23' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (355, CAST(N'2047-04-15' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (356, CAST(N'2047-04-14' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (357, CAST(N'2047-04-12' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (358, CAST(N'2047-04-11' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (359, CAST(N'2047-04-07' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (360, CAST(N'2047-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (361, CAST(N'2047-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (362, CAST(N'2047-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (363, CAST(N'2047-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (364, CAST(N'2047-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (365, CAST(N'2048-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (366, CAST(N'2048-05-24' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (367, CAST(N'2048-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (368, CAST(N'2048-04-06' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (369, CAST(N'2048-04-05' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (370, CAST(N'2048-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (371, CAST(N'2048-04-02' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (372, CAST(N'2048-03-29' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (373, CAST(N'2048-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (374, CAST(N'2048-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (375, CAST(N'2048-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (376, CAST(N'2048-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (377, CAST(N'2048-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (378, CAST(N'2049-06-07' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (379, CAST(N'2049-06-06' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (380, CAST(N'2049-05-27' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (381, CAST(N'2049-04-19' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (382, CAST(N'2049-04-18' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (383, CAST(N'2049-04-16' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (384, CAST(N'2049-04-15' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (385, CAST(N'2049-04-11' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (386, CAST(N'2049-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (387, CAST(N'2049-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (388, CAST(N'2049-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (389, CAST(N'2049-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (390, CAST(N'2049-01-01' AS Date), N'Første nyttårsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (391, CAST(N'2050-05-30' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (392, CAST(N'2050-05-29' AS Date), N'Første pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (393, CAST(N'2050-05-19' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (394, CAST(N'2050-04-11' AS Date), N'Andre påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (395, CAST(N'2050-04-10' AS Date), N'Første påskedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (396, CAST(N'2050-04-08' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (397, CAST(N'2050-04-07' AS Date), N'Skjærtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (398, CAST(N'2050-04-03' AS Date), N'Palmesøndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (399, CAST(N'2050-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (400, CAST(N'2050-12-25' AS Date), N'Første juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (401, CAST(N'2050-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (402, CAST(N'2050-05-01' AS Date), N'Offentlig høytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (403, CAST(N'2050-01-01' AS Date), N'Første nyttårsdag')
GO
SET IDENTITY_INSERT [dbo].[publicholiday] OFF
GO
SET IDENTITY_INSERT [dbo].[season] ON 
GO
INSERT [dbo].[season] ([id], [season]) VALUES (2, N'summer')
GO
INSERT [dbo].[season] ([id], [season]) VALUES (3, N'summerHigh')
GO
INSERT [dbo].[season] ([id], [season]) VALUES (1, N'summerLow')
GO
INSERT [dbo].[season] ([id], [season]) VALUES (5, N'winter')
GO
INSERT [dbo].[season] ([id], [season]) VALUES (6, N'winterHigh')
GO
INSERT [dbo].[season] ([id], [season]) VALUES (4, N'winterLow')
GO
SET IDENTITY_INSERT [dbo].[season] OFF
GO
SET IDENTITY_INSERT [dbo].[tarifftype] ON 
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (1, N'private_tou_rush', 1, N'private', N'Nettleie Rush&Ro', 60, N'Tariff focused on lowering energy consumption during high consumption periods of the day')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (2, N'private_tou_daynight', 1, N'private', N'Nettleie Dag&Natt', 60, N'Tariff focused on moving energy consumption from day to night')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (3, N'private_flatrate', 1, N'private', N'Nettleie', 60, N'Flat tariff with no differencing on hour of day')
GO
SET IDENTITY_INSERT [dbo].[tarifftype] OFF
GO
SET IDENTITY_INSERT [dbo].[uom] ON 
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (2, N'NOK', N'kr/kWh')
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (1, N'NOK', N'kr/mnd')
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (3, N'NOK', N'øre/kWh')
GO
SET IDENTITY_INSERT [dbo].[uom] OFF
GO
SET IDENTITY_INSERT [dbo].[variablepriceconfig] ON 
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (1, 1, 5, 1, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5406 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1352 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (2, 1, 5, 1, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.3274 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0818 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (3, 1, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (4, 1, 5, 2, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5406 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1352 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (5, 1, 5, 2, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.3274 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0818 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (6, 1, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (7, 1, 5, 3, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5406 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1352 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (8, 1, 5, 3, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.3274 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0818 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (9, 1, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (10, 1, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (11, 1, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (12, 1, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (13, 1, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (14, 1, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (15, 1, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (16, 1, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (17, 1, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (18, 1, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (19, 1, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (20, 1, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (21, 1, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (22, 1, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (23, 1, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (24, 1, 5, 11, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5406 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1352 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (25, 1, 5, 11, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.3274 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0818 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (26, 1, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (27, 1, 5, 12, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5406 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1352 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (28, 1, 5, 12, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.3274 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0818 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (29, 1, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (30, 2, 5, 1, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4366 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1091 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (31, 2, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (32, 2, 5, 2, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4366 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1091 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (33, 2, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (34, 2, 5, 3, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4366 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1091 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (35, 2, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (36, 2, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (37, 2, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (38, 2, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (39, 2, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (40, 2, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (41, 2, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (42, 2, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (43, 2, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (44, 2, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (45, 2, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (46, 2, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (47, 2, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (48, 2, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0842 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0210 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (49, 2, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0642 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0160 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (50, 2, 5, 11, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4366 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1091 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (51, 2, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (52, 2, 5, 12, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4366 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1091 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (53, 2, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0942 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0235 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (54, 3, 5, 1, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (55, 3, 5, 2, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (56, 3, 5, 3, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (57, 3, 2, 4, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (58, 3, 2, 5, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (59, 3, 2, 6, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (60, 3, 2, 7, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (61, 3, 2, 8, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (62, 3, 2, 9, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (63, 3, 2, 10, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (64, 3, 5, 11, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (65, 3, 5, 12, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2496 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0624 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2024-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
SET IDENTITY_INSERT [dbo].[variablepriceconfig] OFF
GO
/****** Object:  Index [uc_fixedpriceconfig]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[fixedpriceconfig] ADD  CONSTRAINT [uc_fixedpriceconfig] UNIQUE NONCLUSTERED 
(
	[tarifftypeid] ASC,
	[seasonid] ASC,
	[monthno] ASC,
	[pricelevelid] ASC,
	[pricefromdate] ASC,
	[pricetodate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__fixedpri__EDDD99B6AEC43134]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[fixedpricelevel] ADD UNIQUE NONCLUSTERED 
(
	[pricelevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__hours__7F30AF4E38C64628]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[hours] ADD UNIQUE NONCLUSTERED 
(
	[hour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__pricelev__EDDD99B6F0E3D123]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[pricelevel] ADD UNIQUE NONCLUSTERED 
(
	[pricelevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__season__BC91B1706B5B0E8A]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[season] ADD UNIQUE NONCLUSTERED 
(
	[season] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uc_tarifftype]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[tarifftype] ADD  CONSTRAINT [uc_tarifftype] UNIQUE NONCLUSTERED 
(
	[customertype] ASC,
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uc_uom]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[uom] ADD  CONSTRAINT [uc_uom] UNIQUE NONCLUSTERED 
(
	[currency] ASC,
	[uom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uc_variablepriceconfig]    Script Date: 13.10.2020 09:15:56 ******/
ALTER TABLE [dbo].[variablepriceconfig] ADD  CONSTRAINT [uc_variablepriceconfig] UNIQUE NONCLUSTERED 
(
	[tarifftypeid] ASC,
	[seasonid] ASC,
	[monthno] ASC,
	[pricelevelid] ASC,
	[pricefromdate] ASC,
	[pricetodate] ASC,
	[hours] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[fixedpriceconfig]  WITH CHECK ADD FOREIGN KEY([pricelevelid])
REFERENCES [dbo].[fixedpricelevel] ([id])
GO
ALTER TABLE [dbo].[fixedpriceconfig]  WITH CHECK ADD FOREIGN KEY([seasonid])
REFERENCES [dbo].[season] ([id])
GO
ALTER TABLE [dbo].[fixedpriceconfig]  WITH CHECK ADD FOREIGN KEY([tarifftypeid])
REFERENCES [dbo].[tarifftype] ([id])
GO
ALTER TABLE [dbo].[fixedpriceconfig]  WITH CHECK ADD FOREIGN KEY([uomid])
REFERENCES [dbo].[uom] ([id])
GO
ALTER TABLE [dbo].[tarifftype]  WITH CHECK ADD FOREIGN KEY([companyid])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[variablepriceconfig]  WITH CHECK ADD FOREIGN KEY([pricelevelid])
REFERENCES [dbo].[pricelevel] ([id])
GO
ALTER TABLE [dbo].[variablepriceconfig]  WITH CHECK ADD FOREIGN KEY([seasonid])
REFERENCES [dbo].[season] ([id])
GO
ALTER TABLE [dbo].[variablepriceconfig]  WITH CHECK ADD FOREIGN KEY([tarifftypeid])
REFERENCES [dbo].[tarifftype] ([id])
GO
ALTER TABLE [dbo].[variablepriceconfig]  WITH CHECK ADD FOREIGN KEY([uomid])
REFERENCES [dbo].[uom] ([id])
GO
ALTER DATABASE [NettTariff-dev] SET  READ_WRITE 
--ALTER DATABASE [NettTariff-test] SET  READ_WRITE 
--ALTER DATABASE [NettTariff-prod] SET  READ_WRITE 
GO
