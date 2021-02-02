USE [NettTariff-dev]
--USE [NettTariff-test]
--USE [NettTariff-prod]
GO

delete from meteringpointproduct;
delete from integrationconfig;
delete from producttariffmapping;
delete from variablepriceconfig;
delete from dbo.fixedpriceconfig;
delete from publicholiday;
delete from tarifftype;
delete from dbo.fixedpricelevel;
delete from dbo.company;
delete from pricelevel;
delete from season;
delete from uom;

drop table meteringpointproduct;
drop table integrationconfig;
drop table producttariffmapping;
drop table dbo.fixedpriceconfig;
drop table dbo.fixedpricelevel;
drop table publicholiday;
drop table variablepriceconfig;
drop table tarifftype;
drop table dbo.company;
drop table pricelevel;
drop table season;
drop table uom;

