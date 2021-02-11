SET IDENTITY_INSERT [dbo].[company] ON 
GO
INSERT [dbo].[company] ([id], [company]) VALUES (1, N'Elvia AS')
GO
SET IDENTITY_INSERT [dbo].[company] OFF
GO
SET IDENTITY_INSERT [dbo].[fixedpriceconfig] ON 
GO
--Oslo og Viken Rush&Ro: 20201029:Are:endret pricetodate 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (1, 1, 5, 1, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (2, 1, 5, 2, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (3, 1, 5, 3, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (4, 1, 2, 4, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (5, 1, 2, 5, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (6, 1, 2, 6, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (7, 1, 2, 7, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (8, 1, 2, 8, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (9, 1, 2, 9, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (10, 1, 2, 10, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (11, 1, 5, 11, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (12, 1, 5, 12, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Oslo og Viken Dag&Natt: 20201029:Are:endret pricetodate 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (13, 2, 5, 1, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (14, 2, 5, 2, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (15, 2, 5, 3, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (16, 2, 2, 4, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (17, 2, 2, 5, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (18, 2, 2, 6, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (19, 2, 2, 7, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (20, 2, 2, 8, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (21, 2, 2, 9, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (22, 2, 2, 10, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (23, 2, 5, 11, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (24, 2, 5, 12, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Oslo og Viken - bolig: 20201029:Are:endret pricetodate 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (25, 3, 5, 1, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (26, 3, 5, 2, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (27, 3, 5, 3, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (28, 3, 2, 4, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (29, 3, 2, 5, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (30, 3, 2, 6, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (31, 3, 2, 7, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (32, 3, 2, 8, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (33, 3, 2, 9, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (34, 3, 2, 10, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (35, 3, 5, 11, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (36, 3, 5, 12, 1, CAST(100.0000 AS Decimal(10, 4)), CAST(80.0000 AS Decimal(10, 4)), CAST(20.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Oslo og Viken - hytte: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (37, 4, 5, 1, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (38, 4, 5, 2, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (39, 4, 5, 3, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (40, 4, 2, 4, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (41, 4, 2, 5, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (42, 4, 2, 6, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (43, 4, 2, 7, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (44, 4, 2, 8, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (45, 4, 2, 9, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (46, 4, 2, 10, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (47, 4, 5, 11, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (48, 4, 5, 12, 3, CAST(165.0000 AS Decimal(10, 4)), CAST(132.0000 AS Decimal(10, 4)), CAST(33.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - Rush&Ro: 20201029:Are:nye rader og priser 20201106:Are:Endret tarifftypeid til 13 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (49, 13, 5, 1, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (50, 13, 5, 2, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (51, 13, 5, 3, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (52, 13, 2, 4, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (53, 13, 2, 5, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (54, 13, 2, 6, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (55, 13, 2, 7, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (56, 13, 2, 8, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (57, 13, 2, 9, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (58, 13, 2, 10, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (59, 13, 5, 11, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (60, 13, 5, 12, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - Dag&Natt: 20201029:Are:nye rader og priser 20201106:Are:Endret tarifftypeid til 14 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (61, 14, 5, 1, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (62, 14, 5, 2, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (63, 14, 5, 3, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (64, 14, 2, 4, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (65, 14, 2, 5, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (66, 14, 2, 6, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (67, 14, 2, 7, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (68, 14, 2, 8, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (69, 14, 2, 9, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (70, 14, 2, 10, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (71, 14, 5, 11, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (72, 14, 5, 12, 4, CAST(200.0000 AS Decimal(10, 4)), CAST(160.0000 AS Decimal(10, 4)), CAST(40.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E10: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (73, 5, 5, 1, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (74, 5, 5, 2, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (75, 5, 5, 3, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (76, 5, 2, 4, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (77, 5, 2, 5, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (78, 5, 2, 6, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (79, 5, 2, 7, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (80, 5, 2, 8, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (81, 5, 2, 9, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (82, 5, 2, 10, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (83, 5, 5, 11, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (84, 5, 5, 12, 5, CAST(333.3333 AS Decimal(10, 4)), CAST(266.6667 AS Decimal(10, 4)), CAST(66.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E17: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (85, 6, 5, 1, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (86, 6, 5, 2, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (87, 6, 5, 3, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (88, 6, 2, 4, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (89, 6, 2, 5, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (90, 6, 2, 6, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (91, 6, 2, 7, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (92, 6, 2, 8, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (93, 6, 2, 9, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (94, 6, 2, 10, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (95, 6, 5, 11, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (96, 6, 5, 12, 6, CAST(441.6667 AS Decimal(10, 4)), CAST(353.3336 AS Decimal(10, 4)), CAST(88.3331 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E25: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (97, 7, 5, 1, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (98, 7, 5, 2, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (99, 7, 5, 3, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (100, 7, 2, 4, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (101, 7, 2, 5, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (102, 7, 2, 6, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (103, 7, 2, 7, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (104, 7, 2, 8, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (105, 7, 2, 9, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (106, 7, 2, 10, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (107, 7, 5, 11, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (108, 7, 5, 12, 7, CAST(635.4167 AS Decimal(10, 4)), CAST(508.3333 AS Decimal(10, 4)), CAST(127.0834 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E35: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (109, 8, 5, 1, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (110, 8, 5, 2, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (111, 8, 5, 3, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (112, 8, 2, 4, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (113, 8, 2, 5, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (114, 8, 2, 6, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (115, 8, 2, 7, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (116, 8, 2, 8, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (117, 8, 2, 9, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (118, 8, 2, 10, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (119, 8, 5, 11, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (120, 8, 5, 12, 8, CAST(838.3333 AS Decimal(10, 4)), CAST(670.6667 AS Decimal(10, 4)), CAST(167.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E50: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (121, 9, 5, 1, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (122, 9, 5, 2, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (123, 9, 5, 3, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (124, 9, 2, 4, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (125, 9, 2, 5, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (126, 9, 2, 6, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (127, 9, 2, 7, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (128, 9, 2, 8, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (129, 9, 2, 9, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (130, 9, 2, 10, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (131, 9, 5, 11, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (132, 9, 5, 12, 9, CAST(1156.2500 AS Decimal(10, 4)), CAST(925.0000 AS Decimal(10, 4)), CAST(231.2500 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E65: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (133, 10, 5, 1, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (134, 10, 5, 2, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (135, 10, 5, 3, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (136, 10, 2, 4, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (137, 10, 2, 5, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (138, 10, 2, 6, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (139, 10, 2, 7, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (140, 10, 2, 8, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (141, 10, 2, 9, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (142, 10, 2, 10, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (143, 10, 5, 11, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (144, 10, 5, 12, 10, CAST(1463.3333 AS Decimal(10, 4)), CAST(1170.6667 AS Decimal(10, 4)), CAST(292.6666 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E80: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (145, 11, 5, 1, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (146, 11, 5, 2, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (147, 11, 5, 3, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (148, 11, 2, 4, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (149, 11, 2, 5, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (150, 11, 2, 6, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (151, 11, 2, 7, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (152, 11, 2, 8, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (153, 11, 2, 9, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (154, 11, 2, 10, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (155, 11, 5, 11, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (156, 11, 5, 12, 11, CAST(1766.6667 AS Decimal(10, 4)), CAST(1413.3333 AS Decimal(10, 4)), CAST(353.3334 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Innlandet - E99: 20201029:Are:nye rader 2020-12-18:Are:Endret pricetodate til 2020-12-31
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (157, 12, 5, 1, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (158, 12, 5, 2, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (159, 12, 5, 3, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (160, 12, 2, 4, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (161, 12, 2, 5, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (162, 12, 2, 6, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (163, 12, 2, 7, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (164, 12, 2, 8, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (165, 12, 2, 9, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (166, 12, 2, 10, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (167, 12, 5, 11, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (168, 12, 5, 12, 12, CAST(2150.0000 AS Decimal(10, 4)), CAST(1720.0000 AS Decimal(10, 4)), CAST(430.0000 AS Decimal(10, 4)), 1, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date))
GO
--Oslo og Viken Rush&Ro: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (169, 1, 5, 1, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (170, 1, 5, 2, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (171, 1, 5, 3, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (172, 1, 2, 4, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (173, 1, 2, 5, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (174, 1, 2, 6, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (175, 1, 2, 7, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (176, 1, 2, 8, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (177, 1, 2, 9, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (178, 1, 2, 10, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (179, 1, 5, 11, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (180, 1, 5, 12, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Oslo og Viken Dag&Natt: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (181, 2, 5, 1, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (182, 2, 5, 2, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (183, 2, 5, 3, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (184, 2, 2, 4, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (185, 2, 2, 5, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (186, 2, 2, 6, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (187, 2, 2, 7, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (188, 2, 2, 8, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (189, 2, 2, 9, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (190, 2, 2, 10, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (191, 2, 5, 11, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (192, 2, 5, 12, 2, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Oslo og Viken - bolig: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (193, 3, 5, 1, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (194, 3, 5, 2, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (195, 3, 5, 3, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (196, 3, 2, 4, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (197, 3, 2, 5, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (198, 3, 2, 6, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (199, 3, 2, 7, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (200, 3, 2, 8, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (201, 3, 2, 9, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (202, 3, 2, 10, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (203, 3, 5, 11, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (204, 3, 5, 12, 1, CAST(115.0000 AS Decimal(10, 4)), CAST(92.0000 AS Decimal(10, 4)), CAST(23.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Oslo og Viken - hytte: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (205, 4, 5, 1, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (206, 4, 5, 2, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (207, 4, 5, 3, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (208, 4, 2, 4, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (209, 4, 2, 5, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (210, 4, 2, 6, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (211, 4, 2, 7, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (212, 4, 2, 8, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (213, 4, 2, 9, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (214, 4, 2, 10, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (215, 4, 5, 11, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (216, 4, 5, 12, 3, CAST(180.0000 AS Decimal(10, 4)), CAST(144.0000 AS Decimal(10, 4)), CAST(36.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - Rush&Ro: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (217, 13, 5, 1, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (218, 13, 5, 2, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (219, 13, 5, 3, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (220, 13, 2, 4, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (221, 13, 2, 5, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (222, 13, 2, 6, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (223, 13, 2, 7, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (224, 13, 2, 8, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (225, 13, 2, 9, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (226, 13, 2, 10, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (227, 13, 5, 11, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (228, 13, 5, 12, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - Dag&Natt: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (229, 14, 5, 1, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (230, 14, 5, 2, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (231, 14, 5, 3, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (232, 14, 2, 4, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (233, 14, 2, 5, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (234, 14, 2, 6, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (235, 14, 2, 7, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (236, 14, 2, 8, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (237, 14, 2, 9, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (238, 14, 2, 10, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (239, 14, 5, 11, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (240, 14, 5, 12, 4, CAST(170.0000 AS Decimal(10, 4)), CAST(136.0000 AS Decimal(10, 4)), CAST(34.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E10: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (241, 5, 5, 1, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (242, 5, 5, 2, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (243, 5, 5, 3, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (244, 5, 2, 4, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (245, 5, 2, 5, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (246, 5, 2, 6, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (247, 5, 2, 7, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (248, 5, 2, 8, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (249, 5, 2, 9, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (250, 5, 2, 10, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (251, 5, 5, 11, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (252, 5, 5, 12, 5, CAST(279.1667 AS Decimal(10, 4)), CAST(223.3334 AS Decimal(10, 4)), CAST(55.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E17: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (253, 6, 5, 1, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (254, 6, 5, 2, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (255, 6, 5, 3, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (256, 6, 2, 4, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (257, 6, 2, 5, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (258, 6, 2, 6, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (259, 6, 2, 7, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (260, 6, 2, 8, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (261, 6, 2, 9, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (262, 6, 2, 10, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (263, 6, 5, 11, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (264, 6, 5, 12, 6, CAST(370.8333 AS Decimal(10, 4)), CAST(296.6666 AS Decimal(10, 4)), CAST(74.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E25: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (265, 7, 5, 1, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (266, 7, 5, 2, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (267, 7, 5, 3, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (268, 7, 2, 4, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (269, 7, 2, 5, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (270, 7, 2, 6, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (271, 7, 2, 7, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (272, 7, 2, 8, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (273, 7, 2, 9, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (274, 7, 2, 10, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (275, 7, 5, 11, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (276, 7, 5, 12, 7, CAST(529.1667 AS Decimal(10, 4)), CAST(423.3334 AS Decimal(10, 4)), CAST(105.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E35: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (277, 8, 5, 1, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (278, 8, 5, 2, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (279, 8, 5, 3, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (280, 8, 2, 4, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (281, 8, 2, 5, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (282, 8, 2, 6, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (283, 8, 2, 7, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (284, 8, 2, 8, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (285, 8, 2, 9, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (286, 8, 2, 10, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (287, 8, 5, 11, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (288, 8, 5, 12, 8, CAST(704.1667 AS Decimal(10, 4)), CAST(563.3334 AS Decimal(10, 4)), CAST(140.8333 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E50: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (289, 9, 5, 1, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (290, 9, 5, 2, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (291, 9, 5, 3, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (292, 9, 2, 4, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (293, 9, 2, 5, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (294, 9, 2, 6, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (295, 9, 2, 7, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (296, 9, 2, 8, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (297, 9, 2, 9, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (298, 9, 2, 10, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (299, 9, 5, 11, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (300, 9, 5, 12, 9, CAST(970.8333 AS Decimal(10, 4)), CAST(776.6666 AS Decimal(10, 4)), CAST(194.1667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E65: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (301, 10, 5, 1, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (302, 10, 5, 2, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (303, 10, 5, 3, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (304, 10, 2, 4, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (305, 10, 2, 5, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (306, 10, 2, 6, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (307, 10, 2, 7, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (308, 10, 2, 8, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (309, 10, 2, 9, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (310, 10, 2, 10, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (311, 10, 5, 11, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (312, 10, 5, 12, 10, CAST(1225.0000 AS Decimal(10, 4)), CAST(980.0000 AS Decimal(10, 4)), CAST(245.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E80: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (313, 11, 5, 1, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (314, 11, 5, 2, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (315, 11, 5, 3, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (316, 11, 2, 4, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (317, 11, 2, 5, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (318, 11, 2, 6, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (319, 11, 2, 7, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (320, 11, 2, 8, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (321, 11, 2, 9, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (322, 11, 2, 10, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (323, 11, 5, 11, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (324, 11, 5, 12, 11, CAST(1483.3333 AS Decimal(10, 4)), CAST(1186.6666 AS Decimal(10, 4)), CAST(296.6667 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
--Innlandet - E99: 2020-12-18:Are:Added
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (325, 12, 5, 1, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (326, 12, 5, 2, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (327, 12, 5, 3, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (328, 12, 2, 4, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (329, 12, 2, 5, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (330, 12, 2, 6, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (331, 12, 2, 7, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (332, 12, 2, 8, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (333, 12, 2, 9, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (334, 12, 2, 10, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (335, 12, 5, 11, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[fixedpriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [fixed], [taxes], [uomid], [pricefromdate], [pricetodate]) VALUES (336, 12, 5, 12, 12, CAST(1800.0000 AS Decimal(10, 4)), CAST(1440.0000 AS Decimal(10, 4)), CAST(360.0000 AS Decimal(10, 4)), 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[fixedpriceconfig] OFF
GO
SET IDENTITY_INSERT [dbo].[fixedpricelevel] ON 
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (1, N'Level1', N'Elvia private fixed price component: Oslo og Viken - bolig')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (2, N'Level2', N'Elvia private fixed price component: Oslo og Viken - Rush&Ro og Dag&Natt')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (3, N'Level3', N'Elvia private fixed price component: Oslo og Viken - hytte')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (4, N'Level4', N'Elvia private fixed price component: Innlandet - Rush&Ro og Dag&Natt')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (5, N'Level5', N'Elvia private fixed price component: Innlandet - E10')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (6, N'Level6', N'Elvia private fixed price component: Innlandet - E17')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (7, N'Level7', N'Elvia private fixed price component: Innlandet - E25')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (8, N'Level8', N'Elvia private fixed price component: Innlandet - E35')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (9, N'Level9', N'Elvia private fixed price component: Innlandet - E50')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (10, N'Level10', N'Elvia private fixed price component: Innlandet - E65')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (11, N'Level11', N'Elvia private fixed price component: Innlandet - E80')
GO
INSERT [dbo].[fixedpricelevel] ([id], [pricelevel], [levelinfo]) VALUES (12, N'Level12', N'Elvia private fixed price component: Innlandet - E99')
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
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (1, CAST(N'2020-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (2, CAST(N'2020-04-05' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (3, CAST(N'2020-04-09' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (4, CAST(N'2020-04-10' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (5, CAST(N'2020-04-12' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (6, CAST(N'2020-04-13' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (7, CAST(N'2020-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (8, CAST(N'2020-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (9, CAST(N'2020-05-21' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (10, CAST(N'2020-05-31' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (11, CAST(N'2020-06-01' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (12, CAST(N'2020-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (13, CAST(N'2020-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (14, CAST(N'2021-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (15, CAST(N'2021-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (16, CAST(N'2021-05-24' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (17, CAST(N'2021-05-23' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (18, CAST(N'2021-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (19, CAST(N'2021-05-13' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (20, CAST(N'2021-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (21, CAST(N'2021-04-05' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (22, CAST(N'2021-04-04' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (23, CAST(N'2021-04-02' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (24, CAST(N'2021-04-01' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (25, CAST(N'2021-03-28' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (26, CAST(N'2021-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (27, CAST(N'2022-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (28, CAST(N'2022-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (29, CAST(N'2022-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (30, CAST(N'2022-06-05' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (31, CAST(N'2022-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (32, CAST(N'2022-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (33, CAST(N'2022-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (34, CAST(N'2022-04-18' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (35, CAST(N'2022-04-17' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (36, CAST(N'2022-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (37, CAST(N'2022-04-14' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (38, CAST(N'2022-04-10' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (39, CAST(N'2022-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (40, CAST(N'2023-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (41, CAST(N'2023-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (42, CAST(N'2023-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (43, CAST(N'2023-05-28' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (44, CAST(N'2023-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (45, CAST(N'2023-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (46, CAST(N'2023-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (47, CAST(N'2023-04-10' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (48, CAST(N'2023-04-09' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (49, CAST(N'2023-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (50, CAST(N'2023-04-06' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (51, CAST(N'2023-04-02' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (52, CAST(N'2023-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (53, CAST(N'2024-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (54, CAST(N'2024-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (55, CAST(N'2024-05-20' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (56, CAST(N'2024-05-19' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (57, CAST(N'2024-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (58, CAST(N'2024-05-09' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (59, CAST(N'2024-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (60, CAST(N'2024-04-01' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (61, CAST(N'2024-03-31' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (62, CAST(N'2024-03-29' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (63, CAST(N'2024-03-28' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (64, CAST(N'2024-03-24' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (65, CAST(N'2024-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (66, CAST(N'2025-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (67, CAST(N'2025-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (68, CAST(N'2025-06-09' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (69, CAST(N'2025-06-08' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (70, CAST(N'2025-05-29' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (71, CAST(N'2025-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (72, CAST(N'2025-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (73, CAST(N'2025-04-21' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (74, CAST(N'2025-04-20' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (75, CAST(N'2025-04-18' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (76, CAST(N'2025-04-17' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (77, CAST(N'2025-04-13' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (78, CAST(N'2025-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (79, CAST(N'2026-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (80, CAST(N'2026-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (81, CAST(N'2026-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (82, CAST(N'2026-05-24' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (83, CAST(N'2026-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (84, CAST(N'2026-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (85, CAST(N'2026-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (86, CAST(N'2026-04-06' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (87, CAST(N'2026-04-05' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (88, CAST(N'2026-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (89, CAST(N'2026-04-02' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (90, CAST(N'2026-03-29' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (91, CAST(N'2026-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (92, CAST(N'2027-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (93, CAST(N'2027-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (94, CAST(N'2027-05-17' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (95, CAST(N'2027-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (96, CAST(N'2027-05-16' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (97, CAST(N'2027-05-06' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (98, CAST(N'2027-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (99, CAST(N'2027-03-29' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (100, CAST(N'2027-03-28' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (101, CAST(N'2027-03-26' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (102, CAST(N'2027-03-25' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (103, CAST(N'2027-03-21' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (104, CAST(N'2027-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (105, CAST(N'2028-06-05' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (106, CAST(N'2028-06-04' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (107, CAST(N'2028-05-25' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (108, CAST(N'2028-04-17' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (109, CAST(N'2028-04-16' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (110, CAST(N'2028-04-14' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (111, CAST(N'2028-04-13' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (112, CAST(N'2028-04-09' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (113, CAST(N'2028-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (114, CAST(N'2028-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (115, CAST(N'2028-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (116, CAST(N'2028-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (117, CAST(N'2028-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (118, CAST(N'2029-05-21' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (119, CAST(N'2029-05-20' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (120, CAST(N'2029-05-10' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (121, CAST(N'2029-04-02' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (122, CAST(N'2029-04-01' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (123, CAST(N'2029-03-30' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (124, CAST(N'2029-03-29' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (125, CAST(N'2029-03-25' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (126, CAST(N'2029-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (127, CAST(N'2029-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (128, CAST(N'2029-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (129, CAST(N'2029-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (130, CAST(N'2029-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (131, CAST(N'2030-06-10' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (132, CAST(N'2030-06-09' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (133, CAST(N'2030-05-30' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (134, CAST(N'2030-04-22' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (135, CAST(N'2030-04-21' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (136, CAST(N'2030-04-19' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (137, CAST(N'2030-04-18' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (138, CAST(N'2030-04-14' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (139, CAST(N'2030-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (140, CAST(N'2030-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (141, CAST(N'2030-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (142, CAST(N'2030-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (143, CAST(N'2030-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (144, CAST(N'2031-06-02' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (145, CAST(N'2031-06-01' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (146, CAST(N'2031-05-22' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (147, CAST(N'2031-04-14' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (148, CAST(N'2031-04-13' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (149, CAST(N'2031-04-11' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (150, CAST(N'2031-04-10' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (151, CAST(N'2031-04-06' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (152, CAST(N'2031-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (153, CAST(N'2031-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (154, CAST(N'2031-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (155, CAST(N'2031-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (156, CAST(N'2031-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (157, CAST(N'2032-05-17' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (158, CAST(N'2032-05-16' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (159, CAST(N'2032-05-06' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (160, CAST(N'2032-03-29' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (161, CAST(N'2032-03-28' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (162, CAST(N'2032-03-26' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (163, CAST(N'2032-03-25' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (164, CAST(N'2032-03-21' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (165, CAST(N'2032-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (166, CAST(N'2032-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (167, CAST(N'2032-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (168, CAST(N'2032-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (169, CAST(N'2032-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (170, CAST(N'2033-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (171, CAST(N'2033-06-05' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (172, CAST(N'2033-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (173, CAST(N'2033-04-18' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (174, CAST(N'2033-04-17' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (175, CAST(N'2033-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (176, CAST(N'2033-04-14' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (177, CAST(N'2033-04-10' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (178, CAST(N'2033-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (179, CAST(N'2033-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (180, CAST(N'2033-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (181, CAST(N'2033-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (182, CAST(N'2033-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (183, CAST(N'2034-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (184, CAST(N'2034-05-28' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (185, CAST(N'2034-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (186, CAST(N'2034-04-10' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (187, CAST(N'2034-04-09' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (188, CAST(N'2034-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (189, CAST(N'2034-04-06' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (190, CAST(N'2034-04-02' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (191, CAST(N'2034-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (192, CAST(N'2034-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (193, CAST(N'2034-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (194, CAST(N'2034-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (195, CAST(N'2034-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (196, CAST(N'2035-05-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (197, CAST(N'2035-05-13' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (198, CAST(N'2035-05-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (199, CAST(N'2035-03-26' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (200, CAST(N'2035-03-25' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (201, CAST(N'2035-03-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (202, CAST(N'2035-03-22' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (203, CAST(N'2035-03-18' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (204, CAST(N'2035-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (205, CAST(N'2035-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (206, CAST(N'2035-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (207, CAST(N'2035-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (208, CAST(N'2035-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (209, CAST(N'2036-06-02' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (210, CAST(N'2036-06-01' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (211, CAST(N'2036-05-22' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (212, CAST(N'2036-04-14' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (213, CAST(N'2036-04-13' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (214, CAST(N'2036-04-11' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (215, CAST(N'2036-04-10' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (216, CAST(N'2036-04-06' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (217, CAST(N'2036-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (218, CAST(N'2036-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (219, CAST(N'2036-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (220, CAST(N'2036-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (221, CAST(N'2036-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (222, CAST(N'2037-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (223, CAST(N'2037-05-24' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (224, CAST(N'2037-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (225, CAST(N'2037-04-06' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (226, CAST(N'2037-04-05' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (227, CAST(N'2037-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (228, CAST(N'2037-04-02' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (229, CAST(N'2037-03-29' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (230, CAST(N'2037-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (231, CAST(N'2037-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (232, CAST(N'2037-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (233, CAST(N'2037-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (234, CAST(N'2037-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (235, CAST(N'2038-06-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (236, CAST(N'2038-06-13' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (237, CAST(N'2038-06-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (238, CAST(N'2038-04-26' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (239, CAST(N'2038-04-25' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (240, CAST(N'2038-04-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (241, CAST(N'2038-04-22' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (242, CAST(N'2038-04-18' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (243, CAST(N'2038-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (244, CAST(N'2038-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (245, CAST(N'2038-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (246, CAST(N'2038-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (247, CAST(N'2038-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (248, CAST(N'2039-05-30' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (249, CAST(N'2039-05-29' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (250, CAST(N'2039-05-19' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (251, CAST(N'2039-04-11' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (252, CAST(N'2039-04-10' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (253, CAST(N'2039-04-08' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (254, CAST(N'2039-04-07' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (255, CAST(N'2039-04-03' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (256, CAST(N'2039-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (257, CAST(N'2039-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (258, CAST(N'2039-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (259, CAST(N'2039-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (260, CAST(N'2039-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (261, CAST(N'2040-05-21' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (262, CAST(N'2040-05-20' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (263, CAST(N'2040-05-10' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (264, CAST(N'2040-04-02' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (265, CAST(N'2040-04-01' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (266, CAST(N'2040-03-30' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (267, CAST(N'2040-03-29' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (268, CAST(N'2040-03-25' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (269, CAST(N'2040-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (270, CAST(N'2040-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (271, CAST(N'2040-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (272, CAST(N'2040-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (273, CAST(N'2040-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (274, CAST(N'2041-06-10' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (275, CAST(N'2041-06-09' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (276, CAST(N'2041-05-30' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (277, CAST(N'2041-04-22' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (278, CAST(N'2041-04-21' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (279, CAST(N'2041-04-19' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (280, CAST(N'2041-04-18' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (281, CAST(N'2041-04-14' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (282, CAST(N'2041-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (283, CAST(N'2041-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (284, CAST(N'2041-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (285, CAST(N'2041-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (286, CAST(N'2041-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (287, CAST(N'2042-05-26' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (288, CAST(N'2042-05-25' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (289, CAST(N'2042-05-15' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (290, CAST(N'2042-04-07' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (291, CAST(N'2042-04-06' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (292, CAST(N'2042-04-04' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (293, CAST(N'2042-04-03' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (294, CAST(N'2042-03-30' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (295, CAST(N'2042-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (296, CAST(N'2042-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (297, CAST(N'2042-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (298, CAST(N'2042-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (299, CAST(N'2042-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (300, CAST(N'2043-05-18' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (301, CAST(N'2043-05-17' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (302, CAST(N'2043-05-07' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (303, CAST(N'2043-03-30' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (304, CAST(N'2043-03-29' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (305, CAST(N'2043-03-27' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (306, CAST(N'2043-03-26' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (307, CAST(N'2043-03-22' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (308, CAST(N'2043-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (309, CAST(N'2043-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (310, CAST(N'2043-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (311, CAST(N'2043-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (312, CAST(N'2043-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (313, CAST(N'2044-06-06' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (314, CAST(N'2044-06-05' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (315, CAST(N'2044-05-26' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (316, CAST(N'2044-04-18' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (317, CAST(N'2044-04-17' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (318, CAST(N'2044-04-15' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (319, CAST(N'2044-04-14' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (320, CAST(N'2044-04-10' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (321, CAST(N'2044-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (322, CAST(N'2044-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (323, CAST(N'2044-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (324, CAST(N'2044-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (325, CAST(N'2044-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (326, CAST(N'2045-05-29' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (327, CAST(N'2045-05-28' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (328, CAST(N'2045-05-18' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (329, CAST(N'2045-04-10' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (330, CAST(N'2045-04-09' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (331, CAST(N'2045-04-07' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (332, CAST(N'2045-04-06' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (333, CAST(N'2045-04-02' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (334, CAST(N'2045-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (335, CAST(N'2045-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (336, CAST(N'2045-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (337, CAST(N'2045-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (338, CAST(N'2045-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (339, CAST(N'2046-05-14' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (340, CAST(N'2046-05-13' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (341, CAST(N'2046-05-03' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (342, CAST(N'2046-03-26' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (343, CAST(N'2046-03-25' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (344, CAST(N'2046-03-23' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (345, CAST(N'2046-03-22' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (346, CAST(N'2046-03-18' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (347, CAST(N'2046-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (348, CAST(N'2046-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (349, CAST(N'2046-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (350, CAST(N'2046-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (351, CAST(N'2046-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (352, CAST(N'2047-06-03' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (353, CAST(N'2047-06-02' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (354, CAST(N'2047-05-23' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (355, CAST(N'2047-04-15' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (356, CAST(N'2047-04-14' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (357, CAST(N'2047-04-12' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (358, CAST(N'2047-04-11' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (359, CAST(N'2047-04-07' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (360, CAST(N'2047-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (361, CAST(N'2047-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (362, CAST(N'2047-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (363, CAST(N'2047-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (364, CAST(N'2047-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (365, CAST(N'2048-05-25' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (366, CAST(N'2048-05-24' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (367, CAST(N'2048-05-14' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (368, CAST(N'2048-04-06' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (369, CAST(N'2048-04-05' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (370, CAST(N'2048-04-03' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (371, CAST(N'2048-04-02' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (372, CAST(N'2048-03-29' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (373, CAST(N'2048-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (374, CAST(N'2048-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (375, CAST(N'2048-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (376, CAST(N'2048-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (377, CAST(N'2048-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (378, CAST(N'2049-06-07' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (379, CAST(N'2049-06-06' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (380, CAST(N'2049-05-27' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (381, CAST(N'2049-04-19' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (382, CAST(N'2049-04-18' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (383, CAST(N'2049-04-16' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (384, CAST(N'2049-04-15' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (385, CAST(N'2049-04-11' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (386, CAST(N'2049-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (387, CAST(N'2049-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (388, CAST(N'2049-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (389, CAST(N'2049-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (390, CAST(N'2049-01-01' AS Date), N'F�rste nytt�rsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (391, CAST(N'2050-05-30' AS Date), N'Andre pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (392, CAST(N'2050-05-29' AS Date), N'F�rste pinsedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (393, CAST(N'2050-05-19' AS Date), N'Kristi himmelfartsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (394, CAST(N'2050-04-11' AS Date), N'Andre p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (395, CAST(N'2050-04-10' AS Date), N'F�rste p�skedag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (396, CAST(N'2050-04-08' AS Date), N'Langfredag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (397, CAST(N'2050-04-07' AS Date), N'Skj�rtorsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (398, CAST(N'2050-04-03' AS Date), N'Palmes�ndag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (399, CAST(N'2050-12-26' AS Date), N'Andre juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (400, CAST(N'2050-12-25' AS Date), N'F�rste juledag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (401, CAST(N'2050-05-17' AS Date), N'Grunnlovsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (402, CAST(N'2050-05-01' AS Date), N'Offentlig h�ytidsdag')
GO
INSERT [dbo].[publicholiday] ([id], [holidaydate], [description]) VALUES (403, CAST(N'2050-01-01' AS Date), N'F�rste nytt�rsdag')
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
--20201106: Are: Endret tariffkey for fuselevel1 til fuselevel8 20201106:Are:Lagt til tarifftype 13 og 14 og endret title p� nr 1,2,3,4 og endret tariffkey og description p� nr 1 og 2
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (1, N'private_tou_rush1', 1, N'private', N'Nettleie Rush&Ro (Oslo og Viken)', 60, N'Tariff focused on lowering energy consumption during high consumption periods of the day. Future prices are subject to changes. Applies to Oslo og Viken.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (2, N'private_tou_daynight1', 1, N'private', N'Nettleie Dag&Natt (Oslo og Viken)', 60, N'Tariff focused on moving consumption from day to night. Future prices are subject to changes. Applies to Oslo og Viken.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (3, N'private_flatrate_house', 1, N'private', N'Nettleie - bolig (Oslo og Viken)', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Oslo og Viken.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (4, N'private_flatrate_cabin', 1, N'private', N'Nettleie - hytte (Oslo og Viken)', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Oslo og Viken.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (5, N'private_flatrate_fuselevel1', 1, N'private', N'Nettleie - E10', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (6, N'private_flatrate_fuselevel2', 1, N'private', N'Nettleie - E17', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (7, N'private_flatrate_fuselevel3', 1, N'private', N'Nettleie - E25', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (8, N'private_flatrate_fuselevel4', 1, N'private', N'Nettleie - E35', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (9, N'private_flatrate_fuselevel5', 1, N'private', N'Nettleie - E50', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (10, N'private_flatrate_fuselevel6', 1, N'private', N'Nettleie - E65', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (11, N'private_flatrate_fuselevel7', 1, N'private', N'Nettleie - E80', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (12, N'private_flatrate_fuselevel8', 1, N'private', N'Nettleie - E99', 60, N'Flat tariff with no differencing on hour of day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (13, N'private_tou_rush2', 1, N'private', N'Nettleie Rush&Ro (Innlandet)', 60, N'Tariff focused on lowering energy consumption during high consumption periods of the day. Future prices are subject to changes. Applies to Innlandet.')
GO
INSERT [dbo].[tarifftype] ([id], [tariffkey], [companyid], [customertype], [title], [resolution], [description]) VALUES (14, N'private_tou_daynight2', 1, N'private', N'Nettleie Dag&Natt (Innlandet)', 60, N'Tariff focused on moving consumption from day to night. Future prices are subject to changes. Applies to Innlandet.')
GO
SET IDENTITY_INSERT [dbo].[tarifftype] OFF
GO
SET IDENTITY_INSERT [dbo].[uom] ON 
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (2, N'NOK', N'kr/kWh')
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (1, N'NOK', N'kr/month')
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (3, N'NOK', N'�re/kWh')
GO
INSERT [dbo].[uom] ([id], [currency], [uom]) VALUES (4, N'NOK', N'kr/hour')
GO

SET IDENTITY_INSERT [dbo].[uom] OFF
GO
SET IDENTITY_INSERT [dbo].[variablepriceconfig] ON 
GO
-- Rush & Ro - Oslo og Viken og Innlandet 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (1, 1, 5, 1, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (2, 1, 5, 1, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (3, 1, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (4, 1, 5, 2, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (5, 1, 5, 2, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (6, 1, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (7, 1, 5, 3, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (8, 1, 5, 3, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (9, 1, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (10, 1, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (11, 1, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (12, 1, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (13, 1, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (14, 1, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (15, 1, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (16, 1, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (17, 1, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (18, 1, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (19, 1, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (20, 1, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (21, 1, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (22, 1, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (23, 1, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (24, 1, 5, 11, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (25, 1, 5, 11, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (26, 1, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (27, 1, 5, 12, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (28, 1, 5, 12, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (29, 1, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Dag&Natt - Oslo og Viken og Innlandet 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (30, 2, 5, 1, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (31, 2, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (32, 2, 5, 2, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (33, 2, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (34, 2, 5, 3, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (35, 2, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (36, 2, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (37, 2, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (38, 2, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (39, 2, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (40, 2, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (41, 2, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (42, 2, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (43, 2, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (44, 2, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (45, 2, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (46, 2, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (47, 2, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (48, 2, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (49, 2, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (50, 2, 5, 11, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (51, 2, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (52, 2, 5, 12, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (53, 2, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Bolig - Oslo og Viken 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (54, 3, 5, 1, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (55, 3, 5, 2, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (56, 3, 5, 3, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (57, 3, 2, 4, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (58, 3, 2, 5, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (59, 3, 2, 6, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (60, 3, 2, 7, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (61, 3, 2, 8, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (62, 3, 2, 9, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (63, 3, 2, 10, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (64, 3, 5, 11, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (65, 3, 5, 12, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- Hytte - Oslo og Viken 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (66, 4, 5, 1, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (67, 4, 5, 2, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (68, 4, 5, 3, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (69, 4, 2, 4, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (70, 4, 2, 5, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (71, 4, 2, 6, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (72, 4, 2, 7, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (73, 4, 2, 8, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (74, 4, 2, 9, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (75, 4, 2, 10, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (76, 4, 5, 11, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (77, 4, 5, 12, 3, CAST(0.4833 AS Decimal(10, 4)), CAST(0.2153 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0967 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E10 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (78, 5, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (79, 5, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (80, 5, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (81, 5, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (82, 5, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (83, 5, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (84, 5, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (85, 5, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (86, 5, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (87, 5, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (88, 5, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (89, 5, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E17 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (90, 6, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (91, 6, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (92, 6, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (93, 6, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (94, 6, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (95, 6, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (96, 6, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (97, 6, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (98, 6, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (99, 6, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (100, 6, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (101, 6, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E25 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (102, 7, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (103, 7, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (104, 7, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (105, 7, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (106, 7, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (107, 7, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (108, 7, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (109, 7, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (110, 7, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (111, 7, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (112, 7, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (113, 7, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E35 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (114, 8, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (115, 8, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (116, 8, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (117, 8, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (118, 8, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (119, 8, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (120, 8, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (121, 8, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (122, 8, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (123, 8, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (124, 8, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (125, 8, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E50 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (126, 9, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (127, 9, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (128, 9, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (129, 9, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (130, 9, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (131, 9, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (132, 9, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (133, 9, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (134, 9, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (135, 9, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (136, 9, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (137, 9, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E65 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (138, 10, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (139, 10, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (140, 10, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (141, 10, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (142, 10, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (143, 10, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (144, 10, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (145, 10, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (146, 10, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (147, 10, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (148, 10, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (149, 10, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E80 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (150, 11, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (151, 11, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (152, 11, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (153, 11, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (154, 11, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (155, 11, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (156, 11, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (157, 11, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (158, 11, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (159, 11, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (160, 11, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (161, 11, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E99 - Innlandet 20201029:Are: nye rader 20201104:Are:endret verdier energy,taxmva
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (162, 12, 5, 1, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (163, 12, 5, 2, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (164, 12, 5, 3, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (165, 12, 2, 4, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (166, 12, 2, 5, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (167, 12, 2, 6, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (168, 12, 2, 7, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (169, 12, 2, 8, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (170, 12, 2, 9, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (171, 12, 2, 10, 3, CAST(0.2641 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0528 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (172, 12, 5, 11, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (173, 12, 5, 12, 3, CAST(0.3016 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0603 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- Rush & Ro - Innlandet 20201109:Are:lagt til tarifftypeid 13
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (174, 13, 5, 1, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (175, 13, 5, 1, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (176, 13, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (177, 13, 5, 2, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (178, 13, 5, 2, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (179, 13, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (180, 13, 5, 3, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (181, 13, 5, 3, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (182, 13, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (183, 13, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (184, 13, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (185, 13, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (186, 13, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (187, 13, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (188, 13, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (189, 13, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (190, 13, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (191, 13, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (192, 13, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (193, 13, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (194, 13, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (195, 13, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (196, 13, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (197, 13, 5, 11, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (198, 13, 5, 11, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (199, 13, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (200, 13, 5, 12, 4, CAST(0.8470 AS Decimal(10, 4)), CAST(0.5063 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1694 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (201, 13, 5, 12, 3, CAST(0.5805 AS Decimal(10, 4)), CAST(0.2931 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1161 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (202, 13, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Dag&Natt - Innlandet 20201109:Are:lagt til tarifftypeid 14
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (203, 14, 5, 1, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (204, 14, 5, 1, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (205, 14, 5, 2, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (206, 14, 5, 2, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (207, 14, 5, 3, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (208, 14, 5, 3, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (209, 14, 2, 4, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (210, 14, 2, 4, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (211, 14, 2, 5, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (212, 14, 2, 5, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (213, 14, 2, 6, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (214, 14, 2, 6, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (215, 14, 2, 7, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (216, 14, 2, 7, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (217, 14, 2, 8, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (218, 14, 2, 8, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (219, 14, 2, 9, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (220, 14, 2, 9, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (221, 14, 2, 10, 3, CAST(0.2765 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0553 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (222, 14, 2, 10, 2, CAST(0.2515 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0503 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (223, 14, 5, 11, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (224, 14, 5, 11, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (225, 14, 5, 12, 4, CAST(0.7170 AS Decimal(10, 4)), CAST(0.4023 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1434 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (226, 14, 5, 12, 2, CAST(0.2890 AS Decimal(10, 4)), CAST(0.0599 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0578 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1613 AS Decimal(10, 4)), 2, CAST(N'2020-11-01' AS Date), CAST(N'2020-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Rush & Ro - Oslo og Viken og Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (227, 1, 5, 1, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (228, 1, 5, 1, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (229, 1, 5, 1, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (230, 1, 5, 2, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (231, 1, 5, 2, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (232, 1, 5, 2, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (233, 1, 5, 3, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (234, 1, 5, 3, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (235, 1, 5, 3, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (236, 1, 2, 4, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (237, 1, 2, 4, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (238, 1, 2, 5, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (239, 1, 2, 5, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (240, 1, 2, 6, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (241, 1, 2, 6, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (242, 1, 2, 7, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (243, 1, 2, 7, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (244, 1, 2, 8, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (245, 1, 2, 8, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (246, 1, 2, 9, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (247, 1, 2, 9, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (248, 1, 2, 10, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (249, 1, 2, 10, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (250, 1, 5, 11, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (251, 1, 5, 11, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (252, 1, 5, 11, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (253, 1, 5, 12, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (254, 1, 5, 12, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (255, 1, 5, 12, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Dag&Natt - Oslo og Viken og Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (256, 2, 5, 1, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (257, 2, 5, 1, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (258, 2, 5, 2, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (259, 2, 5, 2, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (260, 2, 5, 3, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (261, 2, 5, 3, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (262, 2, 2, 4, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (263, 2, 2, 4, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (264, 2, 2, 5, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (265, 2, 2, 5, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (266, 2, 2, 6, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (267, 2, 2, 6, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (268, 2, 2, 7, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (269, 2, 2, 7, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (270, 2, 2, 8, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (271, 2, 2, 8, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (272, 2, 2, 9, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (273, 2, 2, 9, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (274, 2, 2, 10, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (275, 2, 2, 10, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (276, 2, 5, 11, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (277, 2, 5, 11, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (278, 2, 5, 12, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (279, 2, 5, 12, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Bolig - Oslo og Viken 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (280, 3, 5, 1, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (281, 3, 5, 2, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (282, 3, 5, 3, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (283, 3, 2, 4, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (284, 3, 2, 5, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (285, 3, 2, 6, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (286, 3, 2, 7, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (287, 3, 2, 8, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (288, 3, 2, 9, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (289, 3, 2, 10, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (290, 3, 5, 11, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (291, 3, 5, 12, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- Hytte - Oslo og Viken 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (292, 4, 5, 1, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (293, 4, 5, 2, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (294, 4, 5, 3, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (295, 4, 2, 4, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (296, 4, 2, 5, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (297, 4, 2, 6, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (298, 4, 2, 7, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (299, 4, 2, 8, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (300, 4, 2, 9, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (301, 4, 2, 10, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (302, 4, 5, 11, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (303, 4, 5, 12, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E10 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (304, 5, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (305, 5, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (306, 5, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (307, 5, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (308, 5, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (309, 5, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (310, 5, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (311, 5, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (312, 5, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (313, 5, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (314, 5, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (315, 5, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E17 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (316, 6, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (317, 6, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (318, 6, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (319, 6, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (320, 6, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (321, 6, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (322, 6, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (323, 6, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (324, 6, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (325, 6, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (326, 6, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (327, 6, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E25 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (328, 7, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (329, 7, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (330, 7, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (331, 7, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (332, 7, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (333, 7, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (334, 7, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (335, 7, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (336, 7, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (337, 7, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (338, 7, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (339, 7, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E35 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (340, 8, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (341, 8, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (342, 8, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (343, 8, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (344, 8, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (345, 8, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (346, 8, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (347, 8, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (348, 8, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (349, 8, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (350, 8, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (351, 8, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E50 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (352, 9, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (353, 9, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (354, 9, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (355, 9, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (356, 9, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (357, 9, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (358, 9, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (359, 9, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (360, 9, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (361, 9, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (362, 9, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (363, 9, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E65 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (364, 10, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (365, 10, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (366, 10, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (367, 10, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (368, 10, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (369, 10, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (370, 10, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (371, 10, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (372, 10, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (373, 10, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (374, 10, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (375, 10, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E80 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (376, 11, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (377, 11, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (378, 11, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (379, 11, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (380, 11, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (381, 11, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (382, 11, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (383, 11, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (384, 11, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (385, 11, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (386, 11, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (387, 11, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- E99 - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (388, 12, 5, 1, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (389, 12, 5, 2, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (390, 12, 5, 3, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (391, 12, 2, 4, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (392, 12, 2, 5, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (393, 12, 2, 6, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (394, 12, 2, 7, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (395, 12, 2, 8, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (396, 12, 2, 9, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (397, 12, 2, 10, 3, CAST(0.2711 AS Decimal(10, 4)), CAST(0.0400 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0542 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (398, 12, 5, 11, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (399, 12, 5, 12, 3, CAST(0.3086 AS Decimal(10, 4)), CAST(0.0700 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0617 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23')
GO
-- Rush & Ro - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (400, 13, 5, 1, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (401, 13, 5, 1, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (402, 13, 5, 1, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (403, 13, 5, 2, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (404, 13, 5, 2, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (405, 13, 5, 2, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (406, 13, 5, 3, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (407, 13, 5, 3, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (408, 13, 5, 3, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (409, 13, 2, 4, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (410, 13, 2, 4, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (411, 13, 2, 5, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (412, 13, 2, 5, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (413, 13, 2, 6, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (414, 13, 2, 6, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (415, 13, 2, 7, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (416, 13, 2, 7, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (417, 13, 2, 8, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (418, 13, 2, 8, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (419, 13, 2, 9, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (420, 13, 2, 9, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (421, 13, 2, 10, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (422, 13, 2, 10, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (423, 13, 5, 11, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (424, 13, 5, 11, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (425, 13, 5, 11, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (426, 13, 5, 12, 4, CAST(0.8060 AS Decimal(10, 4)), CAST(0.4679 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1612 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'8;9;10;11;16;17;18;19')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (427, 13, 5, 12, 3, CAST(0.4480 AS Decimal(10, 4)), CAST(0.1815 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0896 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;12;13;14;15;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (428, 13, 5, 12, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
-- Dag&Natt - Innlandet 2020-12-18:Are:Added
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (429, 14, 5, 1, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (430, 14, 5, 1, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (431, 14, 5, 2, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (432, 14, 5, 2, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (433, 14, 5, 3, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (434, 14, 5, 3, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (435, 14, 2, 4, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (436, 14, 2, 4, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (437, 14, 2, 5, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (438, 14, 2, 5, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (439, 14, 2, 6, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (440, 14, 2, 6, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (441, 14, 2, 7, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (442, 14, 2, 7, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (443, 14, 2, 8, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (444, 14, 2, 8, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (445, 14, 2, 9, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (446, 14, 2, 9, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (447, 14, 2, 10, 3, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (448, 14, 2, 10, 2, CAST(0.2585 AS Decimal(10, 4)), CAST(0.0299 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0517 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (449, 14, 5, 11, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (450, 14, 5, 11, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (451, 14, 5, 12, 4, CAST(0.6310 AS Decimal(10, 4)), CAST(0.3279 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.1262 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21')
GO
INSERT [dbo].[variablepriceconfig] ([id], [tarifftypeid], [seasonid], [monthno], [pricelevelid], [total], [energy], [power_], [taxmva], [taxenova], [taxenergy], [uomid], [pricefromdate], [pricetodate], [hours]) VALUES (452, 14, 5, 12, 2, CAST(0.2835 AS Decimal(10, 4)), CAST(0.0499 AS Decimal(10, 4)), CAST(0.0000 AS Decimal(10, 4)), CAST(0.0567 AS Decimal(10, 4)), CAST(0.0100 AS Decimal(10, 4)), CAST(0.1669 AS Decimal(10, 4)), 2, CAST(N'2021-01-01' AS Date), CAST(N'2021-12-31' AS Date), N'0;1;2;3;4;5;22;23')
GO
SET IDENTITY_INSERT [dbo].[variablepriceconfig] OFF
GO

SET IDENTITY_INSERT [dbo].[producttariffmapping] ON 
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (1, 'HN ELP-RR time avr','private_tou_rush1',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (2, 'HN ELP-DN time avr','private_tou_daynight1',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (3, 'HN ELHA avr','private_flatrate_house',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (4, 'HN ELHYA avr','private_flatrate_cabin',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (5, 'E10','private_flatrate_fuselevel1',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (6, 'E17','private_flatrate_fuselevel2',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (7, 'E25','private_flatrate_fuselevel3',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (8, 'E35','private_flatrate_fuselevel4',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (9, 'E50','private_flatrate_fuselevel5',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (10, 'E65','private_flatrate_fuselevel6',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (11, 'E80','private_flatrate_fuselevel7',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (12, 'E99','private_flatrate_fuselevel8',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (13, 'PLP1','private_tou_rush2',GETDATE(),GETDATE())
GO
INSERT [dbo].[producttariffmapping] ([id], [netproduct], [tariffkey], [created], [lastupdated]) VALUES (14, 'PLP2','private_tou_daynight2',GETDATE(),GETDATE())
GO
SET IDENTITY_INSERT [dbo].[producttariffmapping] OFF 
GO
