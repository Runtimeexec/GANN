/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (10000) [idx]
      ,[filename]
      ,[filesize]
      ,[startime]
      ,[endtime]
      ,[mac_daddr]
      ,[mac_saddr]
  FROM [gann].[dbo].[binary_data]
  where filename is not null