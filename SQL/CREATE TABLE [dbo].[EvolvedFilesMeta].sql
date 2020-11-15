USE [gann]
GO

/****** Object:  Table [dbo].[EvolvedFilesMeta]    Script Date: 25/10/2020 05:10:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EvolvedFilesMeta](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[ID_EvolvedTinyInts] [int] NOT NULL,
	[Filename] [varchar](100) NOT NULL,
	[FileNumber] [bigint] NOT NULL,
	[FileSessionGUID] [uniqueidentifier] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[TF_Probability] [float] NULL,
	[CNTK_Probability] [float] NULL,
	[SNORT_ID] [int] NULL,
	[SNORT_Alert] [bit] NULL,
 CONSTRAINT [PK_EvolvedFiles] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

