USE [gann]
GO

/****** Object:  Table [dbo].[binary_data]    Script Date: 24/10/2020 21:02:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[binary_data](
	[idx] [bigint] NULL,
	[filename] [varchar](max) NULL,
	[filesize] [varchar](max) NULL,
	[startime] [datetime] NULL,
	[endtime] [datetime] NULL,
	[mac_daddr] [varchar](max) NULL,
	[mac_saddr] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO