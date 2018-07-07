USE [master]
GO
/****** Object:  Database [NetworkMarketingDB]    Script Date: 12.09.2017 09:53:42 ******/
CREATE DATABASE [NetworkMarketingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NetworkMarketing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NetworkMarketing.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NetworkMarketing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\NetworkMarketing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NetworkMarketingDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NetworkMarketingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NetworkMarketingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NetworkMarketingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NetworkMarketingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NetworkMarketingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NetworkMarketingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NetworkMarketingDB] SET  MULTI_USER 
GO
ALTER DATABASE [NetworkMarketingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NetworkMarketingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NetworkMarketingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NetworkMarketingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NetworkMarketingDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NetworkMarketingDB', N'ON'
GO
ALTER DATABASE [NetworkMarketingDB] SET QUERY_STORE = OFF
GO
USE [NetworkMarketingDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [NetworkMarketingDB]
GO
/****** Object:  Schema [nm]    Script Date: 12.09.2017 09:53:42 ******/
CREATE SCHEMA [nm]
GO
/****** Object:  Table [nm].[AddressInfos]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[AddressInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[DistributorId] [int] NOT NULL,
 CONSTRAINT [PK_AddressInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[Bonuses]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[Bonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistributorId] [int] NOT NULL,
	[CalculationDate] [date] NOT NULL,
	[Amount] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_Bonuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[ContactInfos]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[ContactInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Comment] [nvarchar](100) NOT NULL,
	[DistributorId] [int] NOT NULL,
 CONSTRAINT [PK_ContactInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[Distributors]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[Distributors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[GenderId] [tinyint] NOT NULL,
	[ProfileImage] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Distributors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [nm].[Genders]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[Genders](
	[Id] [tinyint] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[InfoTypes]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[InfoTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_HelperTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[PersonalInfos]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[PersonalInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocTypeId] [int] NOT NULL,
	[DocSeries] [nvarchar](10) NULL,
	[DocNumber] [nvarchar](10) NULL,
	[DocIssueDate] [date] NOT NULL,
	[DocDeadline] [date] NOT NULL,
	[PersonalNumber] [nvarchar](50) NOT NULL,
	[IssuingAgency] [nvarchar](100) NULL,
	[DistributorId] [int] NOT NULL,
 CONSTRAINT [PK_PersonalInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[ProductFlows]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[ProductFlows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistributorId] [int] NOT NULL,
	[SellingDate] [date] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_ProductsFlow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [nm].[Products]    Script Date: 12.09.2017 09:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [nm].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [nm].[AddressInfos] ON 
GO
INSERT [nm].[AddressInfos] ([Id], [TypeId], [Address], [DistributorId]) VALUES (12, 8, N'ვარკეთილი 3 -ის II მკ.რ', 10)
GO
INSERT [nm].[AddressInfos] ([Id], [TypeId], [Address], [DistributorId]) VALUES (13, 8, N'სამგორის დასახლება', 11)
GO
INSERT [nm].[AddressInfos] ([Id], [TypeId], [Address], [DistributorId]) VALUES (14, 8, N'24რწე წერწერწერწ', 12)
GO
INSERT [nm].[AddressInfos] ([Id], [TypeId], [Address], [DistributorId]) VALUES (15, 8, N'წრე წერწე რწერ', 13)
GO
SET IDENTITY_INSERT [nm].[AddressInfos] OFF
GO
SET IDENTITY_INSERT [nm].[ContactInfos] ON 
GO
INSERT [nm].[ContactInfos] ([Id], [TypeId], [Comment], [DistributorId]) VALUES (11, 4, N'574731774', 10)
GO
INSERT [nm].[ContactInfos] ([Id], [TypeId], [Comment], [DistributorId]) VALUES (12, 4, N'541145441', 11)
GO
INSERT [nm].[ContactInfos] ([Id], [TypeId], [Comment], [DistributorId]) VALUES (13, 3, N'2423424', 12)
GO
INSERT [nm].[ContactInfos] ([Id], [TypeId], [Comment], [DistributorId]) VALUES (14, 4, N'2423424234', 13)
GO
SET IDENTITY_INSERT [nm].[ContactInfos] OFF
GO
SET IDENTITY_INSERT [nm].[Distributors] ON 
GO
INSERT [nm].[Distributors] ([Id], [FirstName], [LastName], [BirthDate], [GenderId], [ProfileImage], [ParentId]) VALUES (10, N'ვასო', N'ბერუაშვილი', CAST(N'1994-05-08' AS Date), 1, NULL, NULL)
GO
INSERT [nm].[Distributors] ([Id], [FirstName], [LastName], [BirthDate], [GenderId], [ProfileImage], [ParentId]) VALUES (11, N'გიორგი', N'ჟულაკაშვილი', CAST(N'1994-01-07' AS Date), 1, NULL, 10)
GO
INSERT [nm].[Distributors] ([Id], [FirstName], [LastName], [BirthDate], [GenderId], [ProfileImage], [ParentId]) VALUES (12, N'ლექსო', N'ციციშვილი', CAST(N'1994-03-13' AS Date), 1, NULL, 10)
GO
INSERT [nm].[Distributors] ([Id], [FirstName], [LastName], [BirthDate], [GenderId], [ProfileImage], [ParentId]) VALUES (13, N'ლაშა', N'ყაჭეიშვილი', CAST(N'1994-06-10' AS Date), 1, NULL, 10)
GO
SET IDENTITY_INSERT [nm].[Distributors] OFF
GO
INSERT [nm].[Genders] ([Id], [Name]) VALUES (1, N'მამრობითი')
GO
INSERT [nm].[Genders] ([Id], [Name]) VALUES (2, N'მდედრობითი')
GO
SET IDENTITY_INSERT [nm].[InfoTypes] ON 
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (1, 1, N'პირადობის მოწმობა')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (2, 1, N'პასპორტი')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (3, 2, N'ტელეფონი')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (4, 2, N'მობილური')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (5, 2, N'ელ. ფოსტა')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (6, 2, N'ფაქსი')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (7, 3, N'ფაქტიური')
GO
INSERT [nm].[InfoTypes] ([Id], [TypeId], [Name]) VALUES (8, 3, N'რეგისტრაციის')
GO
SET IDENTITY_INSERT [nm].[InfoTypes] OFF
GO
SET IDENTITY_INSERT [nm].[PersonalInfos] ON 
GO
INSERT [nm].[PersonalInfos] ([Id], [DocTypeId], [DocSeries], [DocNumber], [DocIssueDate], [DocDeadline], [PersonalNumber], [IssuingAgency], [DistributorId]) VALUES (14, 1, NULL, NULL, CAST(N'2016-07-12' AS Date), CAST(N'2019-07-11' AS Date), N'12345678910', N'იუსტიციის სამინისტრო', 10)
GO
INSERT [nm].[PersonalInfos] ([Id], [DocTypeId], [DocSeries], [DocNumber], [DocIssueDate], [DocDeadline], [PersonalNumber], [IssuingAgency], [DistributorId]) VALUES (15, 1, NULL, NULL, CAST(N'2015-04-07' AS Date), CAST(N'2020-04-08' AS Date), N'01025241254', N'იუსტიციის სამინისტრო', 11)
GO
INSERT [nm].[PersonalInfos] ([Id], [DocTypeId], [DocSeries], [DocNumber], [DocIssueDate], [DocDeadline], [PersonalNumber], [IssuingAgency], [DistributorId]) VALUES (16, 1, NULL, NULL, CAST(N'2017-09-12' AS Date), CAST(N'2017-09-12' AS Date), N'23423432', N'23234234', 12)
GO
INSERT [nm].[PersonalInfos] ([Id], [DocTypeId], [DocSeries], [DocNumber], [DocIssueDate], [DocDeadline], [PersonalNumber], [IssuingAgency], [DistributorId]) VALUES (17, 1, NULL, NULL, CAST(N'2017-09-12' AS Date), CAST(N'2017-09-12' AS Date), N'13123133121', N'324242342', 13)
GO
SET IDENTITY_INSERT [nm].[PersonalInfos] OFF
GO
SET IDENTITY_INSERT [nm].[Products] ON 
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (1, N'001', N'პური', CAST(0.80 AS Decimal(16, 2)))
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (2, N'002', N'მაკარონი', CAST(1.00 AS Decimal(16, 2)))
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (3, N'003', N'ზეთი', CAST(2.40 AS Decimal(16, 2)))
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (4, N'004', N'ლუდი', CAST(1.30 AS Decimal(16, 2)))
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (5, N'005', N'ვაშლი', CAST(0.70 AS Decimal(16, 2)))
GO
INSERT [nm].[Products] ([Id], [Code], [Name], [UnitPrice]) VALUES (9, N'006', N'ლიმონათი', CAST(1.80 AS Decimal(16, 2)))
GO
SET IDENTITY_INSERT [nm].[Products] OFF
GO
/****** Object:  Index [IX_AddressInfos_DistributorId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_AddressInfos_DistributorId] ON [nm].[AddressInfos]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AddressInfos_TypeId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_AddressInfos_TypeId] ON [nm].[AddressInfos]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bonuses_CalculationDate]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_Bonuses_CalculationDate] ON [nm].[Bonuses]
(
	[CalculationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bonuses_DistributorId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_Bonuses_DistributorId] ON [nm].[Bonuses]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactInfos_DistributorId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_ContactInfos_DistributorId] ON [nm].[ContactInfos]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactInfos_TypeId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_ContactInfos_TypeId] ON [nm].[ContactInfos]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Distributors_ParentId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_Distributors_ParentId] ON [nm].[Distributors]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InfoTypes_TypeId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_InfoTypes_TypeId] ON [nm].[InfoTypes]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalInfos_DistributorId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalInfos_DistributorId] ON [nm].[PersonalInfos]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalInfos_DocTypeId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalInfos_DocTypeId] ON [nm].[PersonalInfos]
(
	[DocTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductFlows_DistributorId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_ProductFlows_DistributorId] ON [nm].[ProductFlows]
(
	[DistributorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductFlows_ProductId]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_ProductFlows_ProductId] ON [nm].[ProductFlows]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductFlows_SellingDate]    Script Date: 12.09.2017 09:53:42 ******/
CREATE NONCLUSTERED INDEX [IX_ProductFlows_SellingDate] ON [nm].[ProductFlows]
(
	[SellingDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [nm].[AddressInfos]  WITH CHECK ADD  CONSTRAINT [FK_AddressInfos_Distributors] FOREIGN KEY([DistributorId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[AddressInfos] CHECK CONSTRAINT [FK_AddressInfos_Distributors]
GO
ALTER TABLE [nm].[AddressInfos]  WITH CHECK ADD  CONSTRAINT [FK_AddressInfos_HelperTypes] FOREIGN KEY([TypeId])
REFERENCES [nm].[InfoTypes] ([Id])
GO
ALTER TABLE [nm].[AddressInfos] CHECK CONSTRAINT [FK_AddressInfos_HelperTypes]
GO
ALTER TABLE [nm].[Bonuses]  WITH CHECK ADD  CONSTRAINT [FK_Bonuses_Distributors] FOREIGN KEY([DistributorId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[Bonuses] CHECK CONSTRAINT [FK_Bonuses_Distributors]
GO
ALTER TABLE [nm].[ContactInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactInfos_Distributors] FOREIGN KEY([DistributorId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[ContactInfos] CHECK CONSTRAINT [FK_ContactInfos_Distributors]
GO
ALTER TABLE [nm].[ContactInfos]  WITH CHECK ADD  CONSTRAINT [FK_ContactInfos_HelperTypes] FOREIGN KEY([TypeId])
REFERENCES [nm].[InfoTypes] ([Id])
GO
ALTER TABLE [nm].[ContactInfos] CHECK CONSTRAINT [FK_ContactInfos_HelperTypes]
GO
ALTER TABLE [nm].[Distributors]  WITH CHECK ADD  CONSTRAINT [FK_Distributors_Distributors] FOREIGN KEY([ParentId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[Distributors] CHECK CONSTRAINT [FK_Distributors_Distributors]
GO
ALTER TABLE [nm].[Distributors]  WITH CHECK ADD  CONSTRAINT [FK_Distributors_Genders] FOREIGN KEY([GenderId])
REFERENCES [nm].[Genders] ([Id])
GO
ALTER TABLE [nm].[Distributors] CHECK CONSTRAINT [FK_Distributors_Genders]
GO
ALTER TABLE [nm].[PersonalInfos]  WITH CHECK ADD  CONSTRAINT [FK_PersonalInfos_Distributors] FOREIGN KEY([DistributorId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[PersonalInfos] CHECK CONSTRAINT [FK_PersonalInfos_Distributors]
GO
ALTER TABLE [nm].[PersonalInfos]  WITH CHECK ADD  CONSTRAINT [FK_PersonalInfos_HelperTypes] FOREIGN KEY([DocTypeId])
REFERENCES [nm].[InfoTypes] ([Id])
GO
ALTER TABLE [nm].[PersonalInfos] CHECK CONSTRAINT [FK_PersonalInfos_HelperTypes]
GO
ALTER TABLE [nm].[ProductFlows]  WITH CHECK ADD  CONSTRAINT [FK_ProductsFlow_Distributors] FOREIGN KEY([DistributorId])
REFERENCES [nm].[Distributors] ([Id])
GO
ALTER TABLE [nm].[ProductFlows] CHECK CONSTRAINT [FK_ProductsFlow_Distributors]
GO
ALTER TABLE [nm].[ProductFlows]  WITH CHECK ADD  CONSTRAINT [FK_ProductsFlow_Products] FOREIGN KEY([ProductId])
REFERENCES [nm].[Products] ([Id])
GO
ALTER TABLE [nm].[ProductFlows] CHECK CONSTRAINT [FK_ProductsFlow_Products]
GO
USE [master]
GO
ALTER DATABASE [NetworkMarketingDB] SET  READ_WRITE 
GO
