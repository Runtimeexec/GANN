-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
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
-- MAX VALUE: 65535 which is binary 1111111111111111
CREATE FUNCTION dbo.Int2Binary (@i INT) RETURNS NVARCHAR(16) AS BEGIN
    RETURN
        CASE WHEN CONVERT(VARCHAR(16), @i & 32768 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i & 16384 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &  8192 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &  4096 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &  2048 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &  1024 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &   512 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &   256 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &   128 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &    64 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &    32 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &    16 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &     8 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &     4 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &     2 ) > 0 THEN '1' ELSE '0'   END +
        CASE WHEN CONVERT(VARCHAR(16), @i &     1 ) > 0 THEN '1' ELSE '0'   END
END;
GO
SELECT dbo.Int2Binary(2)
GO

