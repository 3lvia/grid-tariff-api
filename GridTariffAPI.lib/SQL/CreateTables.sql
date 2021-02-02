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

CREATE TABLE [dbo].[producttariffmapping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[netproduct] [varchar](50) NOT NULL,
	[tariffkey] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[lastupdated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[integrationconfig](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tableupdated] [varchar](100) NOT NULL,
	[updateddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[meteringpointproduct](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mpid] [varchar](25) NOT NULL,
	[product] [varchar](100) NOT NULL,
	[tariffkey] [varchar](100) NOT NULL,
	[areacode] [int] NOT NULL,
	[lastupdateddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
