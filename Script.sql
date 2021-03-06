USE [master]
GO
/****** Object:  Database [RFQ_DEV]    Script Date: 01/23/2017 21:03:38 ******/
CREATE DATABASE [RFQ_DEV] ON  PRIMARY 
( NAME = N'RFQ_DEV', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\RFQ_DEV.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RFQ_DEV_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\RFQ_DEV_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RFQ_DEV] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RFQ_DEV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RFQ_DEV] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [RFQ_DEV] SET ANSI_NULLS OFF
GO
ALTER DATABASE [RFQ_DEV] SET ANSI_PADDING OFF
GO
ALTER DATABASE [RFQ_DEV] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [RFQ_DEV] SET ARITHABORT OFF
GO
ALTER DATABASE [RFQ_DEV] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [RFQ_DEV] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [RFQ_DEV] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [RFQ_DEV] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [RFQ_DEV] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [RFQ_DEV] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [RFQ_DEV] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [RFQ_DEV] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [RFQ_DEV] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [RFQ_DEV] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [RFQ_DEV] SET  DISABLE_BROKER
GO
ALTER DATABASE [RFQ_DEV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [RFQ_DEV] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [RFQ_DEV] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [RFQ_DEV] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [RFQ_DEV] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [RFQ_DEV] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [RFQ_DEV] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [RFQ_DEV] SET  READ_WRITE
GO
ALTER DATABASE [RFQ_DEV] SET RECOVERY SIMPLE
GO
ALTER DATABASE [RFQ_DEV] SET  MULTI_USER
GO
ALTER DATABASE [RFQ_DEV] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [RFQ_DEV] SET DB_CHAINING OFF
GO
USE [RFQ_DEV]
GO
/****** Object:  Table [dbo].[MarketMakerQuoteLog]    Script Date: 01/23/2017 21:03:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketMakerQuoteLog](
	[Id] [nchar](32) NOT NULL,
	[ParentId] [nchar](32) NOT NULL,
	[SellPrice] [bigint] NULL,
	[SellPriceBase] [bigint] NULL,
	[BuyPrice] [bigint] NULL,
	[BuyPriceBase] [bigint] NULL,
	[RFQId] [nchar](32) NOT NULL,
	[CurrentState] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[Action] [nvarchar](10) NOT NULL,
	[LogCreated] [datetime] NOT NULL,
	[BidSize] [bigint] NULL,
	[BidSizeBase] [bigint] NULL,
	[OfferSize] [bigint] NULL,
	[OfferSizeBase] [bigint] NULL,
	[BidPrice] [bigint] NULL,
	[OfferPrice] [bigint] NULL,
	[OfferPriceBase] [bigint] NULL,
	[BidPriceBase] [bigint] NULL,
	[NotTradedBidSize] [bigint] NULL,
	[NotTradedBidSizeBase] [bigint] NULL,
	[NotTradedOfferSize] [bigint] NULL,
	[NotTradedOfferSizeBase] [bigint] NULL,
	[IsVWAPQuote] [bit] NOT NULL,
 CONSTRAINT [PK_MarketMakerQuoteLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRSP]    Script Date: 01/23/2017 21:03:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRSP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VenueId] [nvarchar](max) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[IBUsername] [nvarchar](max) NULL,
	[IBPassword] [nvarchar](max) NULL,
	[IsAutoConnect] [bit] NULL,
	[Notes] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRSP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 01/23/2017 21:03:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ValueType] [nchar](10) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFQSessionLog]    Script Date: 01/23/2017 21:03:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFQSessionLog](
	[Id] [nchar](32) NOT NULL,
	[ParentId] [nchar](32) NOT NULL,
	[VenueId] [nvarchar](max) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[InstrumentId] [nvarchar](max) NOT NULL,
	[InstrumentName] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipientId] [int] NOT NULL,
	[InstanceId] [nvarchar](max) NOT NULL,
	[OwnerEVSPId] [nvarchar](max) NOT NULL,
	[Side] [int] NULL,
	[CurrentState] [int] NOT NULL,
	[IsSent] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[Action] [nvarchar](10) NOT NULL,
	[LogCreated] [datetime] NOT NULL,
	[AmountOfResponses] [int] NULL,
	[Size] [bigint] NULL,
	[SizeBase] [bigint] NULL,
	[OfferSize] [bigint] NULL,
	[OfferSizeBase] [bigint] NULL,
	[BidSize] [bigint] NULL,
	[BidSizeBase] [bigint] NULL,
	[IsVWAPRFQ] [bit] NOT NULL,
 CONSTRAINT [PK_RFQSessionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetQuoteStateDescription]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetQuoteStateDescription] 
(
	@State int
)
RETURNS nvarchar(15)
AS
BEGIN
	DECLARE @Description nvarchar(15) 

	SET @Description = 
		CASE
			WHEN @State = -1 OR @State = 0 THEN N'Created'
			WHEN @State = 1 THEN N'Cancelled'
			WHEN @State = 2 THEN N'Expired'
			WHEN @State = 4 THEN N'Traded'  
		END;
		

	RETURN @Description;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSideDescription]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetSideDescription] 
(
	@Side int
)
RETURNS nvarchar(15)
AS
BEGIN
	DECLARE @Description nvarchar(15)

	SET @Description = 
		CASE
			WHEN @Side = -1 THEN N'Unknown'
			WHEN @Side = 0 THEN N'Buy'
			WHEN @Side = 1 THEN N'Sell'
			WHEN @Side = 2 THEN N'Both'  
		END;

	RETURN @Description;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetRFQStateDescription]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetRFQStateDescription] 
(
	@State int
)
RETURNS nvarchar(15)
AS
BEGIN
	DECLARE @Description nvarchar(15) 

	SET @Description = 
		CASE
			WHEN @State = -1 OR @State = 0 THEN N'Initiated'
			WHEN @State = 1 THEN N'Cancelled'
			WHEN @State = 2 THEN N'Expired'
		END;
		

	RETURN @Description;

END
GO
/****** Object:  Table [dbo].[Filter]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestTimerDefault] [int] NULL,
	[RequestTimerMinimum] [int] NULL,
	[RequestTimerMaximum] [int] NULL,
	[ResponseTimerDefault] [int] NULL,
	[ResponseTimerMinimum] [int] NULL,
	[ResponseTimerMaximum] [int] NULL,
	[MinimumNumOfMarketMakers] [int] NULL,
	[ClearingType] [nvarchar](max) NULL,
	[TradeDisclosureToMissedResponders] [nvarchar](max) NULL,
	[TradeDisclosureToMarketData] [nvarchar](max) NULL,
	[FilterType] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[MinSize] [int] NULL,
	[InstrumentSizeValidationRules] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[RuleLevel] [nvarchar](max) NULL,
	[DefaultSize] [int] NULL,
	[IsAnonymous] [bit] NOT NULL,
	[AllowMultiExecute] [bit] NOT NULL,
	[VenueId] [nvarchar](max) NULL,
	[ProductId] [nvarchar](max) NULL,
	[OrderRule] [int] NOT NULL,
	[VWAP] [bit] NOT NULL,
	[AON] [bit] NOT NULL,
	[Magnitude] [nvarchar](100) NOT NULL,
	[MaxSize] [bigint] NULL,
 CONSTRAINT [PK_Filter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FCMToStaticData]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FCMToStaticData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_FCMToStaticData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FCM]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FCM](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ShortName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FCM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditMatrix]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditMatrix](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CreditMatrix] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[ConvertToDecimal]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ConvertToDecimal] 
(
	@Number bigint,
	@NumberBase bigint 
)
RETURNS float
AS
BEGIN
	IF @Number IS NULL OR @NumberBase IS NULL OR @NumberBase = 0
	BEGIN
		RETURN NULL;
	END

	DECLARE @Result float;
	SELECT @Result = CAST(CAST(@Number AS DECIMAL) / CAST(@NumberBase AS DECIMAL) AS FLOAT);
	RETURN @Result;
END
GO
/****** Object:  Table [dbo].[Firm]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MISCode] [nvarchar](max) NOT NULL,
	[HitRatio] [nvarchar](max) NOT NULL,
	[SuccessfulExecution] [nvarchar](max) NOT NULL,
	[TotalRequest] [nvarchar](max) NOT NULL,
	[ExternalId] [nvarchar](max) NULL,
	[ProductId] [nvarchar](max) NULL,
	[VenueId] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Firm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilterUser]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilterUser](
	[Filter_Id] [int] NOT NULL,
	[User_Username] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_FilterUser] PRIMARY KEY NONCLUSTERED 
(
	[Filter_Id] ASC,
	[User_Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilterFirm]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilterFirm](
	[Filter_Id] [int] NOT NULL,
	[Firm_Id] [int] NOT NULL,
	[IsMarketMaker] [bit] NOT NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Filter_Id] [int] NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Username] [nvarchar](256) NOT NULL,
	[DefaulEmail] [nvarchar](max) NULL,
	[DefaultPhone] [nvarchar](max) NULL,
	[LastLoginDate] [datetime] NULL,
	[Initials] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[LastLogoutDate] [datetime] NULL,
	[FirmId] [int] NOT NULL,
	[FusionId] [nvarchar](max) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ExternalId] [nvarchar](max) NULL,
	[VenueId] [nvarchar](max) NULL,
	[ProductId] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFQSession]    Script Date: 01/23/2017 21:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFQSession](
	[Id] [nchar](32) NOT NULL,
	[VenueId] [nvarchar](max) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[InstrumentId] [nvarchar](max) NOT NULL,
	[InstrumentName] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipientId] [int] NOT NULL,
	[InstanceId] [nvarchar](max) NOT NULL,
	[OwnerEVSPId] [nvarchar](max) NOT NULL,
	[Side] [int] NULL,
	[CurrentState] [int] NOT NULL,
	[IsSent] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[AmountOfResponses] [int] NULL,
	[Size] [bigint] NULL,
	[SizeBase] [bigint] NULL,
	[OfferSize] [bigint] NULL,
	[OfferSizeBase] [bigint] NULL,
	[BidSize] [bigint] NULL,
	[BidSizeBase] [bigint] NULL,
	[IsVWAPRFQ] [bit] NOT NULL,
 CONSTRAINT [PK_RFQSession] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetAONRFQHistory]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAONRFQHistory]
	@ActualDate varchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Date DATE;
	
	BEGIN TRY
		SELECT @DATE = CONVERT(DATE, @ActualDate, 103);
	END TRY
	BEGIN CATCH
		PRINT('Please use the following date format: [dd/MM/yyyy],');
		PRINT('where dd - day; MM - month; yyyy - year;');
		PRINT('For example: 22/12/2014.');
		RETURN;
	END CATCH

	SELECT
		requestLog.ParentId AS 'RFQ ID', 
		initiators.Username AS 'RFQ INITIATOR',
		organization.Name AS 'FIRM',
		requestLog.InstrumentName AS 'INSTRUMENT',
		dbo.ConvertToDecimal(requestLog.Size, requestLog.SizeBase) AS 'RFQ SIZE',
		dbo.GetSideDescription(requestLog.Side) AS 'SIDE',
		dbo.GetRFQStateDescription(requestLog.CurrentState) AS 'STATE',
		requestLog.Created AS 'CREATED',
		requestLog.LastModified AS 'MODIFIED'
	FROM [dbo].[RFQSessionLog] requestLog
	INNER JOIN [dbo].[User] initiators ON initiators.Id = requestLog.UserId
	INNER JOIN [dbo].[Firm] organization ON organization.Id = initiators.FirmId
	WHERE CONVERT(DATE, requestLog.LogCreated) = CONVERT(DATE, @Date, 103)
		AND requestLog.IsVWAPRFQ = 0
	ORDER BY requestLog.ParentId, requestLog.LastModified;
END
GO
/****** Object:  StoredProcedure [dbo].[GetVWAPRFQHistory]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVWAPRFQHistory]
	@ActualDate varchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Date DATE;
	
	BEGIN TRY
		SELECT @DATE = CONVERT(DATE, @ActualDate, 103);
	END TRY
	BEGIN CATCH
		PRINT('Please use the following date format: [dd/MM/yyyy],');
		PRINT('where dd - day; MM - month; yyyy - year;');
		PRINT('For example: 22/12/2014.');
		RETURN;
	END CATCH

	SELECT
		requestLog.ParentId AS 'RFQ ID', 
		initiators.Username AS 'RFQ INITIATOR',
		organization.Name AS 'FIRM',
		requestLog.InstrumentName AS 'INSTRUMENT',
		dbo.ConvertToDecimal(requestLog.BidSize, requestLog.BidSizeBase) AS 'BID SIZE',
		dbo.ConvertToDecimal(requestLog.OfferSize, requestLog.OfferSizeBase) AS 'OFFER SIZE',
		requestLog.AmountOfResponses AS 'TOTAL RESPONSES',
		dbo.GetSideDescription(requestLog.Side) AS 'SIDE',
		dbo.GetRFQStateDescription(requestLog.CurrentState) AS 'STATE',
		requestLog.Created AS 'CREATED',
		requestLog.LastModified AS 'MODIFIED'
	FROM [dbo].[RFQSessionLog] requestLog
	INNER JOIN [dbo].[User] initiators ON initiators.Id = requestLog.UserId
	INNER JOIN [dbo].[Firm] organization ON organization.Id = initiators.FirmId
	WHERE CONVERT(DATE, requestLog.LogCreated) = CONVERT(DATE, @Date, 103)
		AND requestLog.IsVWAPRFQ = 1
	ORDER BY requestLog.ParentId, requestLog.LastModified;
END
GO
/****** Object:  Table [dbo].[MarketMakerQuote]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketMakerQuote](
	[Id] [nchar](32) NOT NULL,
	[SellPrice] [bigint] NULL,
	[SellPriceBase] [bigint] NULL,
	[BuyPrice] [bigint] NULL,
	[BuyPriceBase] [bigint] NULL,
	[RFQId] [nchar](32) NOT NULL,
	[CurrentState] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[BidSize] [bigint] NULL,
	[BidSizeBase] [bigint] NULL,
	[OfferSize] [bigint] NULL,
	[OfferSizeBase] [bigint] NULL,
	[BidPrice] [bigint] NULL,
	[BidPriceBase] [bigint] NULL,
	[OfferPrice] [bigint] NULL,
	[OfferPriceBase] [bigint] NULL,
	[NotTradedBidSize] [bigint] NULL,
	[NotTradedBidSizeBase] [bigint] NULL,
	[NotTradedOfferSize] [bigint] NULL,
	[NotTradedOfferSizeBase] [bigint] NULL,
	[IsVWAPQuote] [bit] NOT NULL,
 CONSTRAINT [PK_MarketMakerQuote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetVWAPQuotesHistory]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetVWAPQuotesHistory]
	@ActualDate varchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Date DATE;
	
	BEGIN TRY
		SELECT @Date = CONVERT(DATE, @ActualDate, 103);
	END TRY
	BEGIN CATCH
		--PRINT('Please use the following date format: [dd/MM/yyyy],');
		--PRINT('where dd - day; MM - month; yyyy - year;');
		--PRINT('For example: 22/12/2014.');
		RETURN;
	END CATCH
	
	SELECT
		quoteLog.ParentId AS 'QUOTE ID',
		initiators.Username AS 'MARKET MAKER',
		marketMakerFirm.Name AS 'FIRM',
		dbo.ConvertToDecimal(quoteLog.OfferSize, quoteLog.OfferSizeBase) AS 'OFFER SIZE',
		dbo.ConvertToDecimal(quoteLog.OfferPrice, quoteLog.OfferPriceBase) AS 'OFFER PRICE',
		dbo.ConvertToDecimal(quoteLog.NotTradedOfferSize, quoteLog.NotTradedOfferSizeBase) AS 'NOT TRADED OFFER SIZE',
		dbo.ConvertToDecimal(quoteLog.BidSize, quoteLog.BidSizeBase) AS 'BID SIZE',
		dbo.ConvertToDecimal(quoteLog.BidPrice, quoteLog.BidPriceBase) AS 'BID PRICE',
		dbo.ConvertToDecimal(quoteLog.NotTradedBidSize, quoteLog.NotTradedBidSizeBase) AS 'NOT TRADED BID SIZE',
		dbo.GetQuoteStateDescription(quoteLog.CurrentState) AS 'STATE',
		request.Id AS 'RFQ ID', 
		initiators.Username AS 'RFQ INITIATOR',
		initiatorFirm.Name AS 'FIRM',
		request.InstrumentName AS 'INSTRUMENT',
		dbo.ConvertToDecimal(request.BidSize, request.BidSizeBase) AS 'RFQ BID SIZE',
		dbo.ConvertToDecimal(request.OfferSize, request.OfferSizeBase) AS 'RFQ OFFER SIZE',
		quoteLog.Created AS 'CREATED',
		quoteLog.LastModified AS 'MODIFIED'
	FROM [dbo].[MarketMakerQuoteLog] quoteLog
	INNER JOIN [dbo].[RFQSession] request ON request.Id = quoteLog.RFQId
	INNER JOIN [dbo].[User] initiators ON initiators.Id = request.UserId
	INNER JOIN [dbo].[Firm] initiatorFirm ON initiatorFirm.Id = initiators.FirmId
	INNER JOIN [dbo].[User] marketMaker ON marketMaker.Id = quoteLog.UserId
	INNER JOIN [dbo].[Firm] marketMakerFirm ON marketMakerFirm.Id = marketMaker.FirmId
	WHERE CONVERT(DATE, quoteLog.LogCreated) = @Date AND quoteLog.IsVWAPQuote = 1
	ORDER BY request.Id, quoteLog.ParentId, quoteLog.LastModified;

END
GO
/****** Object:  StoredProcedure [dbo].[GetAONQuotesHistory]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAONQuotesHistory]
	@ActualDate varchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Date DATE;
	
	BEGIN TRY
		SELECT @Date = CONVERT(DATE, @ActualDate, 103);
	END TRY
	BEGIN CATCH
		--PRINT('Please use the following date format: [dd/MM/yyyy],');
		--PRINT('where dd - day; MM - month; yyyy - year;');
		--PRINT('For example: 22/12/2014.');
		RETURN;
	END CATCH
	
	SELECT
		quoteLog.ParentId AS 'QUOTE ID',
		initiators.Username AS 'MARKET MAKER',
		marketMakerFirm.Name AS 'FIRM',
		dbo.GetSideDescription(request.Side) AS 'SIDE',
		dbo.ConvertToDecimal(quoteLog.SellPrice, quoteLog.SellPriceBase) AS 'SELL PRICE',
		dbo.ConvertToDecimal(quoteLog.BuyPrice, quoteLog.BuyPriceBase) AS 'BUY PRICE',
		dbo.GetQuoteStateDescription(quoteLog.CurrentState) AS 'STATE',
		request.Id AS 'RFQ ID', 
		initiators.Username AS 'RFQ INITIATOR',
		initiatorFirm.Name AS 'FIRM',
		request.InstrumentName AS 'INSTRUMENT',
		dbo.ConvertToDecimal(request.Size, request.SizeBase) AS 'RFQ SIZE',
		quoteLog.Created AS 'CREATED',
		quoteLog.LastModified AS 'MODIFIED'
	FROM [dbo].[MarketMakerQuoteLog] quoteLog
	INNER JOIN [dbo].[RFQSession] request ON request.Id = quoteLog.RFQId
	INNER JOIN [dbo].[User] initiators ON initiators.Id = request.UserId
	INNER JOIN [dbo].[Firm] initiatorFirm ON initiatorFirm.Id = initiators.FirmId
	INNER JOIN [dbo].[User] marketMaker ON marketMaker.Id = quoteLog.UserId
	INNER JOIN [dbo].[Firm] marketMakerFirm ON marketMakerFirm.Id = marketMaker.FirmId
	WHERE CONVERT(DATE, quoteLog.LogCreated) = @Date AND quoteLog.IsVWAPQuote = 0
	ORDER BY request.Id, quoteLog.ParentId, quoteLog.LastModified;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfInitiatedRequests]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfInitiatedRequests]
(	
	@UserId int
)
RETURNS int 
AS
BEGIN
	DECLARE @TotalInitiated int;
	
    SELECT @TotalInitiated = COUNT(*)
    FROM [RFQ_DEV].[dbo].[RFQSession]
	WHERE [UserId] = @UserId

	RETURN @TotalInitiated;
END
GO
/****** Object:  StoredProcedure [dbo].[GetResponsesRequestsMetrick]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetResponsesRequestsMetrick]
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Responced INT
	DECLARE @RequestedNCancel INT
	DECLARE @RequestedCancel INT
	DECLARE @Result FLOAT


	SELECT @Responced=COUNT(RFQSessionId)
	FROM  MarketMakerQuote
	WHERE CurrentState<>-1 AND CurrentState<>6 AND CurrentState<>1 AND UserId=@UserId
 
	SELECT @RequestedNCancel=COUNT(r.Id)
	FROM  RFQSession r INNER JOIN
		MarketMakerQuote m ON r.Id = m.RFQSessionId
	WHERE r.CurrentState<>1 AND m.UserId=@UserId
 
	SELECT @RequestedCancel=COUNT(r.Id)
	FROM  RFQSession r INNER JOIN
       MarketMakerQuote m ON r.Id = m.RFQSessionId
	WHERE r.CurrentState=1 AND m.CurrentState<>1 AND m.UserId=@UserId
 
	IF (@RequestedCancel = 0 AND @RequestedNCancel = 0)
	BEGIN
		SELECT 0;
		RETURN 0;
	END
 
	SELECT CAST(@Responced AS FLOAT) / (CAST(@RequestedCancel AS FLOAT) + CAST(@RequestedNCancel AS FLOAT)) * 100.0;
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfTradedRequests]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfTradedRequests]
(
	@UserId int
)
RETURNS int
AS
BEGIN
	DECLARE @Total int;

	SELECT @Total = COUNT(DISTINCT(rfq.Id))
	FROM [dbo].[RFQSession] rfq
	INNER JOIN [dbo].[MarketMakerQuote] quote
	ON rfq.Id = quote.RFQSessionId
	WHERE quote.CurrentState = 4 AND rfq.UserId = @UserId;

	RETURN @Total;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfRespondedRequests]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfRespondedRequests] 
(
	@UserId int
)
RETURNS int
AS
BEGIN
	DECLARE @TotalBeenResponded int;

	SELECT @TotalBeenResponded = COUNT(DISTINCT(rfq.Id))
	FROM [dbo].[RFQSession] rfq
	LEFT JOIN [dbo].[MarketMakerQuote] quote 
	ON rfq.Id = quote.RFQSessionId
	WHERE (
			rfq.UserId = @UserId AND rfq.CurrentState = 1
		) OR (
			rfq.UserId = @UserId AND 
			rfq.CurrentState <> 1 AND
			quote.CurrentState IS NOT NULL AND 
			quote.CurrentState <> -1 AND
			quote.CurrentState <> 6
		);

	RETURN @TotalBeenResponded;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfNotRespondedExpiredRequests]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfNotRespondedExpiredRequests]  
(
	@UserId int
)
RETURNS int
AS
BEGIN
	DECLARE @Total int;

	SELECT @Total = COUNT(DISTINCT(rfq.Id))
	FROM [dbo].[RFQSession] rfq
	WHERE rfq.CurrentState = 2 
	AND rfq.UserId = @UserId
	AND rfq.Id NOT IN 
	(
		SELECT qoute.RFQSessionId
		FROM [dbo].[MarketMakerQuote] qoute
		WHERE qoute.CurrentState <> -1 
			AND qoute.CurrentState <> 6 
			AND qoute.CurrentState IS NOT NULL 
			AND qoute.RFQSessionId = rfq.Id
	);

	RETURN @Total;
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfMarketMakerTrades]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfMarketMakerTrades]
(
	@UserId int
)
RETURNS int
AS
BEGIN

	DECLARE @Total int; 

	SELECT @Total = COUNT(*)
	FROM [dbo].[MarketMakerQuote]
	WHERE UserId = @UserId AND
	CurrentState = 4;

	RETURN @Total;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetNumberOfMarketMakerResponses]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetNumberOfMarketMakerResponses] 
(
	@UserId int
)
RETURNS int
AS
BEGIN

	DECLARE @Total int

	SELECT @Total = COUNT(*)
	FROM [dbo].[MarketMakerQuote] quote
	INNER JOIN [dbo].[RFQSession] rfq
	ON quote.RFQSessionId = rfq.Id
	WHERE quote.UserId = @UserId AND
	quote.CurrentState <> -1 AND 
	quote.CurrentState <> 6 AND
	rfq.CurrentState <> 1;

	RETURN @Total;

END
GO
/****** Object:  StoredProcedure [dbo].[GetNotInterestedInRFQsMeasure]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNotInterestedInRFQsMeasure]
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TotalInitiated float;
	DECLARE @TotalExpiredWithoutResponse float;
	
	SELECT @TotalInitiated = dbo.GetNumberOfInitiatedRequests(@UserId);
	SELECT @TotalExpiredWithoutResponse = dbo.GetNumberOfNotRespondedExpiredRequests(@UserId);
	
	IF (@TotalInitiated = 0)
	BEGIN
		SELECT 0;
		RETURN 0;
	END
	
	SELECT (@TotalExpiredWithoutResponse / @TotalInitiated) * 100;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMarketMakerRespondingQualityMeasure]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarketMakerRespondingQualityMeasure]
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @TotalBoughts float;
	DECLARE @TotalResponded float;

	SELECT @TotalBoughts = dbo.GetNumberOfMarketMakerTrades(@UserId);
	SELECT @TotalResponded = dbo.GetNumberOfMarketMakerResponses(@UserId);
	
	IF (@TotalResponded = 0)
	BEGIN
		SELECT 0;
		RETURN 0;
	END
	
	SELECT (@TotalBoughts / @TotalResponded) * 100;
END
GO
/****** Object:  StoredProcedure [dbo].[GetInitiatorTradingInterestMeasure]    Script Date: 01/23/2017 21:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInitiatorTradingInterestMeasure] 
	@UserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @TotalTraded float;
	DECLARE @TotalHavingResponse float;

	SELECT @TotalTraded = dbo.GetNumberOfTradedRequests(@UserId);
	SELECT @TotalHavingResponse = dbo.GetNumberOfRespondedRequests(@UserId);

	IF (@TotalHavingResponse = 0)
	BEGIN
		SELECT 0;
		RETURN 0;
	END

	SELECT (@TotalTraded / @TotalHavingResponse) * 100;
END
GO
/****** Object:  Default [DF__MarketMak__UserI__36B12243]    Script Date: 01/23/2017 21:03:39 ******/
ALTER TABLE [dbo].[MarketMakerQuoteLog] ADD  CONSTRAINT [DF__MarketMak__UserI__36B12243]  DEFAULT ((1)) FOR [UserId]
GO
/****** Object:  Default [DF_MarketMakerQuoteLog_LogCreationDate]    Script Date: 01/23/2017 21:03:39 ******/
ALTER TABLE [dbo].[MarketMakerQuoteLog] ADD  CONSTRAINT [DF_MarketMakerQuoteLog_LogCreationDate]  DEFAULT (getdate()) FOR [LogCreated]
GO
/****** Object:  Default [DF__RFQSessio__UserI__3A81B327]    Script Date: 01/23/2017 21:03:39 ******/
ALTER TABLE [dbo].[RFQSessionLog] ADD  CONSTRAINT [DF__RFQSessio__UserI__3A81B327]  DEFAULT ((1)) FOR [UserId]
GO
/****** Object:  Default [DF__RFQSessio__IsSen__3B75D760]    Script Date: 01/23/2017 21:03:39 ******/
ALTER TABLE [dbo].[RFQSessionLog] ADD  CONSTRAINT [DF__RFQSessio__IsSen__3B75D760]  DEFAULT ((0)) FOR [IsSent]
GO
/****** Object:  Default [DF_RFQSessionLog_LogCreationDate]    Script Date: 01/23/2017 21:03:39 ******/
ALTER TABLE [dbo].[RFQSessionLog] ADD  CONSTRAINT [DF_RFQSessionLog_LogCreationDate]  DEFAULT (getdate()) FOR [LogCreated]
GO
/****** Object:  Default [DF__Filter__IsAnonym__2E1BDC42]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ((1)) FOR [IsAnonymous]
GO
/****** Object:  Default [DF__Filter__AllowMul__2F10007B]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ((0)) FOR [AllowMultiExecute]
GO
/****** Object:  Default [DF__Filter__OrderRul__300424B4]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ((0)) FOR [OrderRule]
GO
/****** Object:  Default [DF__Filter__VWAP__30F848ED]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ((1)) FOR [VWAP]
GO
/****** Object:  Default [DF__Filter__AON__31EC6D26]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ((1)) FOR [AON]
GO
/****** Object:  Default [DF__Filter__Magnitud__32E0915F]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Filter] ADD  DEFAULT ('') FOR [Magnitude]
GO
/****** Object:  Default [DF__FilterFir__IsMar__33D4B598]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[FilterFirm] ADD  DEFAULT ((0)) FOR [IsMarketMaker]
GO
/****** Object:  Default [DF__RFQSessio__UserI__37A5467C]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[RFQSession] ADD  CONSTRAINT [DF__RFQSessio__UserI__37A5467C]  DEFAULT ((1)) FOR [UserId]
GO
/****** Object:  Default [DF__RFQSessio__IsSen__38996AB5]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[RFQSession] ADD  CONSTRAINT [DF__RFQSessio__IsSen__38996AB5]  DEFAULT ((0)) FOR [IsSent]
GO
/****** Object:  Default [DF__MarketMak__UserI__34C8D9D1]    Script Date: 01/23/2017 21:03:42 ******/
ALTER TABLE [dbo].[MarketMakerQuote] ADD  CONSTRAINT [DF__MarketMak__UserI__34C8D9D1]  DEFAULT ((1)) FOR [UserId]
GO
/****** Object:  ForeignKey [FK_FilterFirm_Filter]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[FilterFirm]  WITH CHECK ADD  CONSTRAINT [FK_FilterFirm_Filter] FOREIGN KEY([Filter_Id])
REFERENCES [dbo].[Filter] ([Id])
GO
ALTER TABLE [dbo].[FilterFirm] CHECK CONSTRAINT [FK_FilterFirm_Filter]
GO
/****** Object:  ForeignKey [FK_FilterFirm_Firm]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[FilterFirm]  WITH CHECK ADD  CONSTRAINT [FK_FilterFirm_Firm] FOREIGN KEY([Firm_Id])
REFERENCES [dbo].[Firm] ([Id])
GO
ALTER TABLE [dbo].[FilterFirm] CHECK CONSTRAINT [FK_FilterFirm_Firm]
GO
/****** Object:  ForeignKey [FK_FilterAttribute]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_FilterAttribute] FOREIGN KEY([Filter_Id])
REFERENCES [dbo].[Filter] ([Id])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_FilterAttribute]
GO
/****** Object:  ForeignKey [FK_UserFirm]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_UserFirm] FOREIGN KEY([FirmId])
REFERENCES [dbo].[Firm] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_UserFirm]
GO
/****** Object:  ForeignKey [FK_RecipientId]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[RFQSession]  WITH CHECK ADD  CONSTRAINT [FK_RecipientId] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RFQSession] CHECK CONSTRAINT [FK_RecipientId]
GO
/****** Object:  ForeignKey [FK_UserRFQSession]    Script Date: 01/23/2017 21:03:41 ******/
ALTER TABLE [dbo].[RFQSession]  WITH CHECK ADD  CONSTRAINT [FK_UserRFQSession] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RFQSession] CHECK CONSTRAINT [FK_UserRFQSession]
GO
/****** Object:  ForeignKey [FK_RFQSessionMarketMakerQuote]    Script Date: 01/23/2017 21:03:42 ******/
ALTER TABLE [dbo].[MarketMakerQuote]  WITH CHECK ADD  CONSTRAINT [FK_RFQSessionMarketMakerQuote] FOREIGN KEY([RFQId])
REFERENCES [dbo].[RFQSession] ([Id])
GO
ALTER TABLE [dbo].[MarketMakerQuote] CHECK CONSTRAINT [FK_RFQSessionMarketMakerQuote]
GO
/****** Object:  ForeignKey [FK_UserMarketMakerQuote]    Script Date: 01/23/2017 21:03:42 ******/
ALTER TABLE [dbo].[MarketMakerQuote]  WITH CHECK ADD  CONSTRAINT [FK_UserMarketMakerQuote] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MarketMakerQuote] CHECK CONSTRAINT [FK_UserMarketMakerQuote]
GO
