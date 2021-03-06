USE [master]
GO
/****** Object:  Database [App]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE DATABASE [App]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'App', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\App.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'App_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\App_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [App] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [App].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [App] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [App] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [App] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [App] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [App] SET ARITHABORT OFF 
GO
ALTER DATABASE [App] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [App] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [App] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [App] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [App] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [App] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [App] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [App] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [App] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [App] SET  DISABLE_BROKER 
GO
ALTER DATABASE [App] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [App] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [App] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [App] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [App] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [App] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [App] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [App] SET RECOVERY FULL 
GO
ALTER DATABASE [App] SET  MULTI_USER 
GO
ALTER DATABASE [App] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [App] SET DB_CHAINING OFF 
GO
ALTER DATABASE [App] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [App] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [App] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'App', N'ON'
GO
ALTER DATABASE [App] SET QUERY_STORE = OFF
GO
USE [App]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[NameOfIdentifier] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Roles] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[CompID] [int] IDENTITY(1,1) NOT NULL,
	[CompName] [nvarchar](max) NULL,
	[Compphone] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
	[Creationdate] [datetime2](7) NOT NULL,
	[Activationdate] [datetime2](7) NOT NULL,
	[CompType] [nvarchar](max) NULL,
	[RelType] [nvarchar](max) NULL,
	[SalesOrderModelSOID] [int] NULL,
 CONSTRAINT [PK_CustomerMaster] PRIMARY KEY CLUSTERED 
(
	[CompID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategoryMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategoryMaster](
	[CatgID] [int] IDENTITY(1,1) NOT NULL,
	[CatgName] [nvarchar](max) NULL,
 CONSTRAINT [PK_ItemCategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CatgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ProductCode] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[MenuFacturerCode] [nvarchar](max) NULL,
	[CatagoryCode] [int] NOT NULL,
	[TradePrice] [real] NOT NULL,
	[ManufactureDiscount] [real] NOT NULL,
	[ProductLicenceNumber] [nvarchar](max) NULL,
	[SGST] [real] NOT NULL,
	[CGST] [real] NOT NULL,
	[HSNCode] [int] NOT NULL,
	[PurchaseOrderModelPOID] [int] NULL,
	[SalesOrderModelSOID] [int] NULL,
 CONSTRAINT [PK_ItemMaster] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseLineMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseLineMaster](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[SourceNumber] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ProductID] [nvarchar](max) NULL,
	[ProductQty] [int] NOT NULL,
	[ProducrPrice] [real] NOT NULL,
	[DocLineNumber] [int] NOT NULL,
	[SGST] [int] NOT NULL,
	[CGST] [int] NOT NULL,
	[QuantityToPost] [int] NOT NULL,
	[PostedQty] [int] NOT NULL,
 CONSTRAINT [PK_PurchaseLineMaster] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderMaster](
	[POID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[PostingDate] [datetime2](7) NOT NULL,
	[DocumentDate] [datetime2](7) NOT NULL,
	[VendorOrderNumber] [nvarchar](max) NULL,
	[VendorInvoiceNumber] [nvarchar](max) NULL,
	[CreatedByUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_PurchaseOrderMaster] PRIMARY KEY CLUSTERED 
(
	[POID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesLineMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesLineMaster](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[SourceNumber] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ProductID] [nvarchar](max) NULL,
	[ProductQty] [int] NOT NULL,
	[ProducrPrice] [real] NOT NULL,
	[DocLineNumber] [int] NOT NULL,
	[SGST] [int] NOT NULL,
	[CGST] [int] NOT NULL,
	[QuantityToPost] [int] NOT NULL,
	[PostedQty] [int] NOT NULL,
 CONSTRAINT [PK_SalesLineMaster] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrderMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderMaster](
	[SOID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[PostingDate] [datetime2](7) NOT NULL,
	[DocumentDate] [datetime2](7) NOT NULL,
	[SalesOrderNumber] [nvarchar](max) NULL,
	[CreatedByUser] [nvarchar](max) NULL,
 CONSTRAINT [PK_SalesOrderMaster] PRIMARY KEY CLUSTERED 
(
	[SOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorMaster]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorMaster](
	[CompID] [int] IDENTITY(1,1) NOT NULL,
	[CompName] [nvarchar](max) NULL,
	[Compphone] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
	[Creationdate] [datetime2](7) NOT NULL,
	[Activationdate] [datetime2](7) NOT NULL,
	[CompType] [nvarchar](max) NULL,
	[RelType] [nvarchar](max) NULL,
	[PurchaseOrderModelPOID] [int] NULL,
 CONSTRAINT [PK_VendorMaster] PRIMARY KEY CLUSTERED 
(
	[CompID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerMaster_SalesOrderModelSOID]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerMaster_SalesOrderModelSOID] ON [dbo].[CustomerMaster]
(
	[SalesOrderModelSOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemMaster_CatagoryCode]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemMaster_CatagoryCode] ON [dbo].[ItemMaster]
(
	[CatagoryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemMaster_PurchaseOrderModelPOID]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemMaster_PurchaseOrderModelPOID] ON [dbo].[ItemMaster]
(
	[PurchaseOrderModelPOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemMaster_SalesOrderModelSOID]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_ItemMaster_SalesOrderModelSOID] ON [dbo].[ItemMaster]
(
	[SalesOrderModelSOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseLineMaster_SourceNumber]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseLineMaster_SourceNumber] ON [dbo].[PurchaseLineMaster]
(
	[SourceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesLineMaster_SourceNumber]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesLineMaster_SourceNumber] ON [dbo].[SalesLineMaster]
(
	[SourceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VendorMaster_PurchaseOrderModelPOID]    Script Date: 01-12-2021 02:10:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_VendorMaster_PurchaseOrderModelPOID] ON [dbo].[VendorMaster]
(
	[PurchaseOrderModelPOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VendorMaster] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Creationdate]
GO
ALTER TABLE [dbo].[VendorMaster] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Activationdate]
GO
ALTER TABLE [dbo].[CustomerMaster]  WITH CHECK ADD  CONSTRAINT [FK_CustomerMaster_SalesOrderMaster_SalesOrderModelSOID] FOREIGN KEY([SalesOrderModelSOID])
REFERENCES [dbo].[SalesOrderMaster] ([SOID])
GO
ALTER TABLE [dbo].[CustomerMaster] CHECK CONSTRAINT [FK_CustomerMaster_SalesOrderMaster_SalesOrderModelSOID]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_ItemCategoryMaster_CatagoryCode] FOREIGN KEY([CatagoryCode])
REFERENCES [dbo].[ItemCategoryMaster] ([CatgID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_ItemCategoryMaster_CatagoryCode]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_PurchaseOrderMaster_PurchaseOrderModelPOID] FOREIGN KEY([PurchaseOrderModelPOID])
REFERENCES [dbo].[PurchaseOrderMaster] ([POID])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_PurchaseOrderMaster_PurchaseOrderModelPOID]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_SalesOrderMaster_SalesOrderModelSOID] FOREIGN KEY([SalesOrderModelSOID])
REFERENCES [dbo].[SalesOrderMaster] ([SOID])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_SalesOrderMaster_SalesOrderModelSOID]
GO
ALTER TABLE [dbo].[PurchaseLineMaster]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseLineMaster_PurchaseOrderMaster_SourceNumber] FOREIGN KEY([SourceNumber])
REFERENCES [dbo].[PurchaseOrderMaster] ([POID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseLineMaster] CHECK CONSTRAINT [FK_PurchaseLineMaster_PurchaseOrderMaster_SourceNumber]
GO
ALTER TABLE [dbo].[SalesLineMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesLineMaster_SalesOrderMaster_SourceNumber] FOREIGN KEY([SourceNumber])
REFERENCES [dbo].[SalesOrderMaster] ([SOID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesLineMaster] CHECK CONSTRAINT [FK_SalesLineMaster_SalesOrderMaster_SourceNumber]
GO
ALTER TABLE [dbo].[VendorMaster]  WITH CHECK ADD  CONSTRAINT [FK_VendorMaster_PurchaseOrderMaster_PurchaseOrderModelPOID] FOREIGN KEY([PurchaseOrderModelPOID])
REFERENCES [dbo].[PurchaseOrderMaster] ([POID])
GO
ALTER TABLE [dbo].[VendorMaster] CHECK CONSTRAINT [FK_VendorMaster_PurchaseOrderMaster_PurchaseOrderModelPOID]
GO
/****** Object:  StoredProcedure [dbo].[CustomersAddorEdit]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[CustomersAddorEdit]
	-- Add the parameters for the stored procedure here
					@CompID int,
                    @CompName  NVARCHAR(max),
                    @Compphone NVARCHAR(max),
                    @Owner NVARCHAR(max),
                    @Creationdate Datetime2,
                    @Activationdate Datetime2,
                    @CompType NVARCHAR(max),
                   @RelType NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @CompID= 0
	BEGIN
	SET IDENTITY_INSERT CustomerMaster ON
		INSERT INTO CustomerMaster(CompID,CompName,Compphone,Owner,Creationdate,Activationdate,CompType,RelType)
		VALUES(@CompID,@CompName,@Compphone,@Owner,@Creationdate,@Activationdate,@CompType,@RelType)
	END
	ELSE 
	BEGIN
		UPDATE CustomerMaster
		SET

		CompName=@CompName,
		Compphone= @Compphone,
		Owner =@Owner,
		Creationdate =@Creationdate,
		Activationdate =@Activationdate,
		CompType =@CompType,
		RelType =@RelType
		WHERE CompID=@CompID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CustomersDislplySelected]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE  [dbo].[CustomersDislplySelected]
	-- Add the parameters for the stored procedure here
	@CompID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM customermaster WHERE CompID=@CompID;
END
GO
/****** Object:  StoredProcedure [dbo].[CutomersAll]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[CutomersAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM CustomerMaster;
END
GO
/****** Object:  StoredProcedure [dbo].[getPOID]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[getPOID] 
	-- Add the parameters for the stored procedure 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
    POID
FROM
   PurchaseOrderMaster
ORDER BY
   POID DESC
OFFSET 0 ROWS 
FETCH FIRST 1 ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[ItemAddorEdit]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[ItemAddorEdit]
	-- Add the parameters for the stored procedure here
					@ProductCode INT,
                    @ProductName  NVARCHAR(max),
                    @MenuFacturerCode NVARCHAR(max),
                    @CatagoryCode NVARCHAR(max),
                    @TradePrice real,
                    @ManufactureDiscount real,
                    @ProductLicenceNumber NVARCHAR(max),
                    @SGST real,
                    @CGST real,
                    @HSNCode INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @ProductCode= 0
	BEGIN
		INSERT INTO ItemMaster(ProductName,MenuFacturerCode,CatagoryCode,TradePrice,ManufactureDiscount,ProductLicenceNumber,SGST,CGST,HSNCode)
		VALUES(@ProductName,@MenuFacturerCode,@CatagoryCode,@TradePrice,@ManufactureDiscount,@ProductLicenceNumber,@SGST,@CGST,@HSNCode)
	END
	ELSE 
	BEGIN
		UPDATE ItemMaster
		SET

		ProductName=@ProductName,
		MenuFacturerCode= @MenuFacturerCode,
		CatagoryCode =@CatagoryCode,
		TradePrice = @TradePrice,
		ManufactureDiscount = @ManufactureDiscount,
		ProductLicenceNumber = @ProductLicenceNumber,
		SGST = @SGST,
		CGST =@CGST,
		HSNCode = @HSNCode
		WHERE ProductCode=@ProductCode
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ItemDislplyAll]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE  [dbo].[ItemDislplyAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *,(1-ItemMaster.ManufactureDiscount/100)*(ItemMaster.TradePrice)as 'Net Price' FROM ItemMaster inner join ItemCategoryMaster on ItemCategoryMaster.CatgID = ItemMaster.CatagoryCode;
END
GO
/****** Object:  StoredProcedure [dbo].[ItemDislplySelected]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE  [dbo].[ItemDislplySelected]
	-- Add the parameters for the stored procedure here
	@ProductCode INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM ItemMaster WHERE ProductCode=@ProductCode ;
END
GO
/****** Object:  StoredProcedure [dbo].[PurchaseOrderAddorEdit]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[PurchaseOrderAddorEdit]
	-- Add the parameters for the stored procedure here
					@POID INT,
					@VendorID NVARCHAR(max),
					@CreationDate  Datetime2,
					@PostingDate  Datetime2, 
					@DocumentDate  Datetime2,
					@VendorOrderNumber  NVARCHAR(max),
					@VendorInvoiceNumber  NVARCHAR(max),
					@CreatedByUser  NVARCHAR(max),
					@id int output

					
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @POID= 0
	BEGIN
		INSERT INTO PurchaseOrderMaster(POID,VendorID,CreationDate,PostingDate,DocumentDate,VendorOrderNumber,VendorInvoiceNumber,CreatedByUser)
		VALUES(@POID,@VendorID,@CreationDate,@PostingDate,@DocumentDate,@VendorOrderNumber,@VendorInvoiceNumber,@CreatedByUser)
		 SET @id=SCOPE_IDENTITY()
      RETURN  @id
	END
	ELSE 
	BEGIN
		UPDATE PurchaseOrderMaster
		SET

		
		VendorID= @VendorID,
		CreationDate =@CreationDate,
		PostingDate = @PostingDate,
		DocumentDate = @DocumentDate,
		VendorOrderNumber = @VendorOrderNumber,
		VendorInvoiceNumber = @VendorInvoiceNumber,
		CreatedByUser =@CreatedByUser
		WHERE POID=@POID

	END
END
GO
/****** Object:  StoredProcedure [dbo].[VendorAddorEdit]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VendorAddorEdit]
	-- Add the parameters for the stored procedure here
					@CompID INT,
                    @CompName  NVARCHAR(max),
                    @Compphone NVARCHAR(max),
                    @Owner NVARCHAR(max),
                    @Creationdate Datetime2 ,
                    @Activationdate Datetime2,
                    @CompType NVARCHAR(max),
					@RelType  NVARCHAR(max)
                   
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @CompID= 0
	BEGIN
		INSERT INTO VendorMaster(CompName,Compphone,Owner,Creationdate,Activationdate,CompType,RelType)
		VALUES(@CompName,@Compphone,@Owner,@Creationdate,@Activationdate,@CompType,@RelType)
	END
	ELSE 
	BEGIN
		UPDATE VendorMaster
		SET
		CompName=@CompName,
		Compphone= @Compphone,
		Owner =@Owner,
		Creationdate = @Creationdate,
		Activationdate = @Activationdate,
		CompType = @CompType,
		RelType = @RelType
		WHERE CompID=@CompID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[vendorAll]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[vendorAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM VendorMaster;
END
GO
/****** Object:  StoredProcedure [dbo].[VendorDislplySelected]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[VendorDislplySelected]
	-- Add the parameters for the stored procedure here
	@CompID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM VendorMaster WHERE CompID=@CompID;
END
GO
/****** Object:  StoredProcedure [dbo].[ViewAllPO]    Script Date: 01-12-2021 02:10:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[ViewAllPO] 
	-- Add the parameters for the stored procedure 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
    *
FROM
   PurchaseOrderMaster;
END
GO
USE [master]
GO
ALTER DATABASE [App] SET  READ_WRITE 
GO
