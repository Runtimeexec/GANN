USE [gann]
GO

/****** Object:  StoredProcedure [dbo].[CreateTableWithNColumnsPrefixTinyintX]    Script Date: 13/06/2020 15:01:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[CreateTableWithNColumnsPrefixBitStringX]
(@TableName nvarchar(100),@NumofCols int)
AS
BEGIN
DECLARE @i INT
DECLARE @MAX INT
DECLARE @SQL NVARCHAR(MAX)
DECLARE @j VARCHAR(10)
DECLARE @len int
SELECT @i=1
SELECT @MAX=@NumofCols
SET @SQL='CREATE TABLE ' + @TableName + '('
WHILE @i<=@MAX
BEGIN
select @j= cast(@i as varchar)
SELECT @SQL= @SQL+'BitString'+ @j  + ' VARCHAR(8) , '
SET @i = @i + 1
END
select @len=len(@SQL)
select  @SQL = substring(@SQL,0,@len-1)
SELECT @SQL= @SQL + ' )'
exec (@SQL)
END
GO

