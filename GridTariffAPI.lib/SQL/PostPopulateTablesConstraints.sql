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
CREATE NONCLUSTERED INDEX IX_MeteringPointProduct_MeteringPointId
    ON dbo.meteringpointproduct (meteringpointid);
GO
CREATE NONCLUSTERED INDEX IX_PublicHoliday_HolidayDate
    ON dbo.publicholiday (holidaydate);	
GO	
CREATE NONCLUSTERED INDEX IX_FixedPriceConfig_MonthIndex
    ON dbo.fixedpriceconfig (MonthNo,PriceFromDate,PriceToDate);
GO
CREATE NONCLUSTERED INDEX IX_VariablePriceConfig_MonthIndex
    ON dbo.variablepriceconfig (MonthNo,PriceFromDate,PriceToDate);	
GO
ALTER DATABASE [NettTariff-dev] SET  READ_WRITE 
--ALTER DATABASE [NettTariff-test] SET  READ_WRITE 
--ALTER DATABASE [NettTariff-prod] SET  READ_WRITE 
GO
