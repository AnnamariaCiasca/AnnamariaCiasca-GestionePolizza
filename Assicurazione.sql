USE [master]
GO
/****** Object:  Database [Assicurazione]    Script Date: 9/3/2021 2:52:29 PM ******/
CREATE DATABASE [Assicurazione]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assicurazione', FILENAME = N'C:\Users\annamaria.ciasca\Assicurazione.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assicurazione_log', FILENAME = N'C:\Users\annamaria.ciasca\Assicurazione_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Assicurazione] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assicurazione].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assicurazione] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assicurazione] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assicurazione] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assicurazione] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assicurazione] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assicurazione] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Assicurazione] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assicurazione] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assicurazione] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assicurazione] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assicurazione] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assicurazione] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assicurazione] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assicurazione] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assicurazione] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Assicurazione] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assicurazione] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assicurazione] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assicurazione] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assicurazione] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assicurazione] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Assicurazione] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assicurazione] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assicurazione] SET  MULTI_USER 
GO
ALTER DATABASE [Assicurazione] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assicurazione] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assicurazione] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assicurazione] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assicurazione] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assicurazione] SET QUERY_STORE = OFF
GO
USE [Assicurazione]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Assicurazione]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/3/2021 2:52:29 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/3/2021 2:52:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](20) NULL,
	[Code] [varchar](16) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 9/3/2021 2:52:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
	[MonthlyRate] [decimal](18, 2) NOT NULL,
	[PolicyType] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210903085208_FirstMigration', N'5.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210903090231_SecondMigration', N'5.0.9')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Code]) VALUES (1, N'Maria', N'Verdi', N'VRDMRA7891LH2D67')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Code]) VALUES (2, N'Luca', N'Rossi', N'RSSLCA45H67LK097')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Code]) VALUES (3, N'Annamaria', N'Ciasca', N'CSCNMR96HTYUXCD1')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Policies] ON 

INSERT [dbo].[Policies] ([Id], [Number], [ExpirationDate], [MonthlyRate], [PolicyType], [CustomerId]) VALUES (1, 1872, CAST(N'2026-07-07T00:00:00.0000000' AS DateTime2), CAST(80.00 AS Decimal(18, 2)), 1, 2)
INSERT [dbo].[Policies] ([Id], [Number], [ExpirationDate], [MonthlyRate], [PolicyType], [CustomerId]) VALUES (2, 1234, CAST(N'2023-02-02T00:00:00.0000000' AS DateTime2), CAST(70.00 AS Decimal(18, 2)), 2, 3)
INSERT [dbo].[Policies] ([Id], [Number], [ExpirationDate], [MonthlyRate], [PolicyType], [CustomerId]) VALUES (3, 6789, CAST(N'2022-01-09T00:00:00.0000000' AS DateTime2), CAST(100.00 AS Decimal(18, 2)), 3, 1)
SET IDENTITY_INSERT [dbo].[Policies] OFF
GO
/****** Object:  Index [IX_Policies_CustomerId]    Script Date: 9/3/2021 2:52:29 PM ******/
CREATE NONCLUSTERED INDEX [IX_Policies_CustomerId] ON [dbo].[Policies]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Policies]  WITH CHECK ADD  CONSTRAINT [FK_Policies_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Policies] CHECK CONSTRAINT [FK_Policies_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [Assicurazione] SET  READ_WRITE 
GO
