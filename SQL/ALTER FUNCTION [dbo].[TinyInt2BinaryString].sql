USE [gann]
GO
/****** Object:  UserDefinedFunction [dbo].[TinyInt2BinaryString]    Script Date: 13/07/2020 07:58:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
/********* Decimal to binary */
-- MAX VALUE: 256 which is binary 11111111
ALTER FUNCTION [dbo].[TinyInt2BinaryString] (@i Tinyint) RETURNS NVARCHAR(8) AS BEGIN
    RETURN
        CASE WHEN CONVERT(VARCHAR(8), @i &   128 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &    64 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &    32 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &    16 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &     8 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &     4 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &     2 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(8), @i &     1 ) > 0 THEN '1' ELSE '0'   END +
		CASE WHEN CONVERT(VARCHAR(8), @i &     0 ) > 0 THEN '1' ELSE '0'   END 
END;
