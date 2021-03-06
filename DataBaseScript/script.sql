USE [FinancialTX]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2018-04-12 9:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Step] [int] NOT NULL,
	[IdTxTypeFK] [int] NOT NULL,
	[NameOrig] [varchar](50) NOT NULL,
	[OldbalanceOrg] [numeric](18, 0) NOT NULL,
	[Amount] [numeric](18, 0) NOT NULL,
	[NewbalanceOrig] [numeric](18, 0) NOT NULL,
	[NameDest] [varchar](50) NOT NULL,
	[OldBalanceDest] [numeric](18, 0) NOT NULL,
	[NewBalanceDest] [numeric](18, 0) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[IsFraud] [bit] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 2018-04-12 9:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[TransactionName] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_TransactionDate]  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_IsFraud]  DEFAULT ((0)) FOR [IsFraud]
GO
ALTER TABLE [dbo].[TransactionType] ADD  CONSTRAINT [DF_TransactionType_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY([IdTxTypeFK])
REFERENCES [dbo].[TransactionType] ([IdType])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_TransactionType]
GO
/****** Object:  StoredProcedure [dbo].[TransactionsSp]    Script Date: 2018-04-12 9:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Juan Rute
-- Create date: Abril 12,2018
-- Description:	Filters for service
-- =============================================
CREATE PROCEDURE [dbo].[TransactionsSp] 
	@type int,
	@name nvarchar(50) = null,
	@dateFrom Datetime = null,
	@dateTo Datetime = null
AS
BEGIN
	SET NOCOUNT ON;
	if(@type=1)
		SELECT * from Transactions TX inner join TransactionType TT on TX.IdTxTypeFK=TT.IdType where TX.IsFraud=1;
	else if(@type=2)
		SELECT * from Transactions TX inner join TransactionType TT on TX.IdTxTypeFK=TT.IdType where TX.NameDest LIKE '%'+@name+'%';
	else
		SELECT * from Transactions TX inner join TransactionType TT on TX.IdTxTypeFK=TT.IdType where tx.TransactionDate between  @dateFrom and @dateTo;
END
GO
