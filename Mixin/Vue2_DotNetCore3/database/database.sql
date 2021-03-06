USE [master]
GO
/****** Object:  Database [StudentManangeSystem]    Script Date: 2020/7/27 10:50:21 ******/
CREATE DATABASE [StudentManangeSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentManangeSystem', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentManangeSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentManangeSystem_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentManangeSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManangeSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentManangeSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManangeSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentManangeSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentManangeSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentManangeSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentManangeSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentManangeSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentManangeSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentManangeSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentManangeSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentManangeSystem', N'ON'
GO
USE [StudentManangeSystem]
GO
/****** Object:  Table [dbo].[class]    Script Date: 2020/7/27 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[class](
	[id] [int] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permission]    Script Date: 2020/7/27 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permission](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_permission] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student_detail]    Script Date: 2020/7/27 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_detail](
	[user_id] [int] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[gender] [bit] NOT NULL,
	[phone] [nvarchar](11) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[img_url] [nvarchar](max) NOT NULL,
	[class_id] [int] NOT NULL,
	[teacher_user_id] [int] NOT NULL,
 CONSTRAINT [PK_student_detail] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teacher_detail]    Script Date: 2020/7/27 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_detail](
	[user_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_teacher_detail] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2020/7/27 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[permission_code] [int] NOT NULL,
	[isEnable] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[student_detail]  WITH CHECK ADD  CONSTRAINT [FK_student_detail_class] FOREIGN KEY([class_id])
REFERENCES [dbo].[class] ([id])
GO
ALTER TABLE [dbo].[student_detail] CHECK CONSTRAINT [FK_student_detail_class]
GO
ALTER TABLE [dbo].[student_detail]  WITH CHECK ADD  CONSTRAINT [FK_student_detail_student_detail] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[student_detail] CHECK CONSTRAINT [FK_student_detail_student_detail]
GO
ALTER TABLE [dbo].[student_detail]  WITH CHECK ADD  CONSTRAINT [FK_student_detail_teacher_detail] FOREIGN KEY([teacher_user_id])
REFERENCES [dbo].[teacher_detail] ([user_id])
GO
ALTER TABLE [dbo].[student_detail] CHECK CONSTRAINT [FK_student_detail_teacher_detail]
GO
ALTER TABLE [dbo].[teacher_detail]  WITH CHECK ADD  CONSTRAINT [FK_teacher_detail_teacher_detail] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[teacher_detail] CHECK CONSTRAINT [FK_teacher_detail_teacher_detail]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_permission] FOREIGN KEY([permission_code])
REFERENCES [dbo].[permission] ([code])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_permission]
GO
USE [master]
GO
ALTER DATABASE [StudentManangeSystem] SET  READ_WRITE 
GO
