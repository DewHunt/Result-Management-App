USE [master]
GO
/****** Object:  Database [ResultManagementSystemDB]    Script Date: 10-Oct-20 20:48:34 ******/
CREATE DATABASE [ResultManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResultManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ResultManagementSystemDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ResultManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ResultManagementSystemDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ResultManagementSystemDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResultManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResultManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResultManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResultManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ResultManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResultManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ResultManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [ResultManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResultManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResultManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResultManagementSystemDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ResultManagementSystemDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ResultManagementSystemDB', N'ON'
GO
ALTER DATABASE [ResultManagementSystemDB] SET QUERY_STORE = OFF
GO
USE [ResultManagementSystemDB]
GO
/****** Object:  Table [dbo].[tbl_classes]    Script Date: 10-Oct-20 20:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NULL,
	[order_by] [int] NULL,
 CONSTRAINT [PK_tbl_classes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_results]    Script Date: 10-Oct-20 20:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_results](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[subject_id] [int] NULL,
	[marks] [int] NULL,
 CONSTRAINT [PK_tbl_results] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_students]    Script Date: 10-Oct-20 20:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_id] [int] NULL,
	[roll] [nvarchar](50) NULL,
	[name] [nvarchar](250) NULL,
	[phone] [nvarchar](15) NULL,
	[order_by] [int] NULL,
 CONSTRAINT [PK_tbl_students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_subjects]    Script Date: 10-Oct-20 20:48:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NULL,
	[order_by] [int] NULL,
 CONSTRAINT [PK_tbl_subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_classes] ON 

INSERT [dbo].[tbl_classes] ([id], [name], [order_by]) VALUES (1, N'Five', 1)
INSERT [dbo].[tbl_classes] ([id], [name], [order_by]) VALUES (2, N'Six', 2)
INSERT [dbo].[tbl_classes] ([id], [name], [order_by]) VALUES (3, N'Seven', 3)
INSERT [dbo].[tbl_classes] ([id], [name], [order_by]) VALUES (4, N'Eight', 4)
SET IDENTITY_INSERT [dbo].[tbl_classes] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_results] ON 

INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (1, 1, 1, 70)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (2, 4, 1, 78)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (3, 4, 2, 83)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (4, 4, 4, 96)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (5, 1, 2, 65)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (6, 1, 4, 68)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (7, 2, 1, 50)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (8, 2, 2, 20)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (9, 2, 4, 25)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (10, 3, 1, 69)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (11, 3, 2, 72)
INSERT [dbo].[tbl_results] ([id], [student_id], [subject_id], [marks]) VALUES (12, 3, 4, 80)
SET IDENTITY_INSERT [dbo].[tbl_results] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_students] ON 

INSERT [dbo].[tbl_students] ([id], [class_id], [roll], [name], [phone], [order_by]) VALUES (1, 1, N'1', N'Salman', N'01317243494', 1)
INSERT [dbo].[tbl_students] ([id], [class_id], [roll], [name], [phone], [order_by]) VALUES (2, 1, N'2', N'Salman Khan', N'01317243494', 1)
INSERT [dbo].[tbl_students] ([id], [class_id], [roll], [name], [phone], [order_by]) VALUES (3, 1, N'3', N'Sabbir Ahmed', N'01317243494', 1)
INSERT [dbo].[tbl_students] ([id], [class_id], [roll], [name], [phone], [order_by]) VALUES (4, 4, N'1', N'Dew Hunt', N'01317243494', 1)
SET IDENTITY_INSERT [dbo].[tbl_students] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_subjects] ON 

INSERT [dbo].[tbl_subjects] ([id], [name], [order_by]) VALUES (1, N'Bangla', 1)
INSERT [dbo].[tbl_subjects] ([id], [name], [order_by]) VALUES (2, N'English', 2)
INSERT [dbo].[tbl_subjects] ([id], [name], [order_by]) VALUES (4, N'Math', 3)
SET IDENTITY_INSERT [dbo].[tbl_subjects] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbl_classes]    Script Date: 10-Oct-20 20:48:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_classes] ON [dbo].[tbl_classes]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ResultManagementSystemDB] SET  READ_WRITE 
GO
