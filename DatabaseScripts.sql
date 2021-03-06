USE [master]
GO
/****** Object:  Database [MyProject]    Script Date: 12/27/2016 12:24:17 AM ******/
CREATE DATABASE [MyProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyProject', FILENAME = N'C:\Users\MrWEED\MyProject.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyProject_log', FILENAME = N'C:\Users\MrWEED\MyProject_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyProject] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyProject] SET  MULTI_USER 
GO
ALTER DATABASE [MyProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyProject] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MyProject]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/27/2016 12:24:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BloodGroup]    Script Date: 12/27/2016 12:24:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BloodGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroup] [varchar](8) NOT NULL,
 CONSTRAINT [PK_BloodGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 12/27/2016 12:24:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Donor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](150) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NOT NULL,
	[GenderId] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[BloodGroupId] [int] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [varchar](300) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Pass] [varchar](100) NOT NULL,
	[NoOfDonation] [int] NOT NULL,
	[LastDonationDate] [varchar](50) NULL,
 CONSTRAINT [PK_Donors1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DonorGender]    Script Date: 12/27/2016 12:24:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DonorGender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NeedBloodRequestTable]    Script Date: 12/27/2016 12:24:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NeedBloodRequestTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[AreaId] [int] NOT NULL,
	[BloodGroupId] [int] NOT NULL,
	[Address] [varchar](200) NULL,
	[GenderId] [int] NOT NULL,
	[Disease] [varchar](50) NULL,
	[Age] [int] NOT NULL,
	[RequestDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NeedBloodRequestTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id], [Area]) VALUES (4, N'Dhaka')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (5, N'Manikganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (6, N'Faridpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (7, N'Gazipur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (9, N'Jamalpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (10, N'Kishoreganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (11, N'Madaripur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (12, N'Munshiganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (13, N'Mymensingh')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (14, N'Narayanganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (15, N'Narsingdhi')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (16, N'Netrokona')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (17, N'Rajbari')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (18, N'Sharitpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (19, N'Sherpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (20, N'Tangail')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (21, N'Bandarban')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (22, N'Brahmanbaria')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (23, N'Chandpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (24, N'Chittagong')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (25, N'Comilla')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (26, N'Coxs Bazar')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (27, N'Feni')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (28, N'KhagraChhari')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (29, N'Lakshmipur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (30, N'Noakhali')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (31, N'Rangamati')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (32, N'Barguna')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (33, N'Barisal')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (34, N'Bhola')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (35, N'Jhalokati')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (36, N'Patuakhali')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (37, N'Pirojpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (38, N'Bagerhat')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (39, N'Chuadanga')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (40, N'Jessore')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (41, N'Jhenaidah')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (42, N'Khulna')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (43, N'Kushtia')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (44, N'Magura')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (45, N'Meherpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (46, N'Narail')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (47, N'Satkhira')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (48, N'Bogura')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (49, N'Chapainababganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (50, N'Jaypurhat')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (51, N'Pabna')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (52, N'Naogaon')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (53, N'Natore')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (54, N'Rajshahi')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (55, N'Sirajganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (56, N'Dinajpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (57, N'Gaibandha')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (58, N'Kurigram')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (59, N'Lalmonirhat')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (60, N'Nilphamari')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (61, N'Panchagarh')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (62, N'Rangpur')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (63, N'Thakurgaon')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (64, N'Habiganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (65, N'Maulvibazar')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (66, N'Sunamganj')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (67, N'Sylhet')
INSERT [dbo].[Area] ([Id], [Area]) VALUES (68, N'Gopalganj')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[BloodGroup] ON 

INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (1, N'A(+ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (2, N'A(-ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (3, N'B(+ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (4, N'B(-ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (5, N'AB(+ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (6, N'AB(-ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (7, N'O(+ve)')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (8, N'O(-ve)')
SET IDENTITY_INSERT [dbo].[BloodGroup] OFF
SET IDENTITY_INSERT [dbo].[Donor] ON 

INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (4005, N'PingPong', N'Kowshik', N'', N'Das', 1, 24, 1, N'01956258555', N'Shukrabad, Dhanmondi', 24, N'987654321', 3, N'12/10/2015')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (5005, N'borat.hossain', N'Md.', N'Borat', N'Hossain', 1, 24, 1, N'01534870605', N'Dhaka', 4, N'2497', 2, N'07/12/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (6005, N'MrWEED', N'Akmal', N'', N'Hossain', 1, 25, 7, N'01680358860', N'Dhanmondi, Dhaka', 5, N'2494', 10, N'07/11/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (7005, N'chandni', N'Kazi', N'Zannatun', N'Nessa', 2, 23, 3, N'01627914527', N'West Rajabazar, Tejgaon, Dhaka-1215', 4, N'2241', 4, N'08/09/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (7006, N'mou2214', N'Arifa', N'Afroze', N'Mousumi', 2, 24, 3, N'01625728505', N'Shukrabad, tejgaon, Dhaka-1215', 4, N'2214', 3, N'07/13/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (7007, N'k.das', N'Kowshik', N'', N'Das', 1, 27, 3, N'01685101763', N'21, Shukrabad, Tejgaon, Dhaka-1215', 4, N'2248', 7, N'12/05/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (8005, N'moon.cse', N'Nazmun', N'Nessa', N'Moon', 2, 35, 1, N'01713191187', N'Dhaka', 4, N'mooncse', 4, N'07/12/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (8006, N'fahim.faisal', N'Fahim', N'', N'Hasan', 1, 35, 1, N'01534870604', N'Barangail, Manikganj', 5, N'fahim', 4, N'07/12/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (9005, N'faruq220', N'Faruq', N'', N'Hossain', 1, 24, 3, N'01534785869', N'Dhaka', 5, N'123456789', 0, N'07/26/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (10005, N'akmal420', N'Adnan', N'', N'Ahmed', 1, 26, 4, N'01675656465', N'Faridpur', 6, N'123456789', 2, N'09/20/2015')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (11005, N'saiful.cse', N'Saiful', N'', N'Islam', 1, 28, 7, N'01989089279', N'Gazipur', 4, N'123456', 0, N'07/26/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (11006, N'fahad.faisal', N'Fahad', N'Ahmed', N'Faisal', 1, 35, 1, N'01536789635', N'Dhaka', 4, N'123456', 2, N'06/14/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (11007, N'fahad.faisal.cse', N'Fahad', N'Ahmed', N'Faisal', 1, 35, 5, N'01680358861', N'Dhaka', 4, N'123456', 1, N'12/12/2016')
INSERT [dbo].[Donor] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [GenderId], [Age], [BloodGroupId], [Phone], [Address], [AreaId], [Pass], [NoOfDonation], [LastDonationDate]) VALUES (12005, N'halim2040', N'Halim', N'', N'Hasan', 1, 25, 5, N'01680358862', N'Dhaka', 4, N'1234', 2, N'10/10/2016')
SET IDENTITY_INSERT [dbo].[Donor] OFF
SET IDENTITY_INSERT [dbo].[DonorGender] ON 

INSERT [dbo].[DonorGender] ([Id], [Gender]) VALUES (1, N'Male')
INSERT [dbo].[DonorGender] ([Id], [Gender]) VALUES (2, N'Female')
SET IDENTITY_INSERT [dbo].[DonorGender] OFF
SET IDENTITY_INSERT [dbo].[NeedBloodRequestTable] ON 

INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (1006, N'Abdur Rahim Mandal', N'01956258555', 4, 7, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Heart Dialysis', 48, N'12/25/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (2006, N'Abdul Halim', N'01680358860', 4, 1, N'Dhaka', 1, N'Surgery', 68, N'12/25/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (2007, N'Abdul Halim Patwary', N'01956258555', 5, 7, N'Manikganj', 1, N'Surgery', 65, N'12/25/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (3006, N'Abdur Rahim Mandal', N'01956258555', 4, 8, N'Dhaka', 1, N'Surgery', 65, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (3007, N'Abdur Rahim Mandal', N'01956258555', 5, 7, N'Manikganj', 1, N'Surgery', 65, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (4006, N'Aminul Islam', N'01680358860', 4, 1, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 24, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (4007, N'Abdur Rahim Mandal', N'01680358860', 4, 5, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 65, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (4008, N'Sajib Kumar Mitra', N'01680358860', 4, 3, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 35, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (4009, N'Abdur Rahim Mandal', N'01956258555', 4, 6, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 65, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (4010, N'Aminul Islam', N'01956258555', 4, 3, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 35, N'12/26/2016')
INSERT [dbo].[NeedBloodRequestTable] ([Id], [Name], [Phone], [AreaId], [BloodGroupId], [Address], [GenderId], [Disease], [Age], [RequestDate]) VALUES (5006, N'Abdur Rahim Mandal', N'01956258555', 4, 3, N'Lab Aid, Dhanmondi, Dhaka', 1, N'Surgery', 45, N'12/26/2016')
SET IDENTITY_INSERT [dbo].[NeedBloodRequestTable] OFF
ALTER TABLE [dbo].[NeedBloodRequestTable] ADD  CONSTRAINT [DF_NeedBloodRequestTable_RequestDate]  DEFAULT (CONVERT([varchar](50),getdate(),(101))) FOR [RequestDate]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_Area]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_BloodGroup] FOREIGN KEY([BloodGroupId])
REFERENCES [dbo].[BloodGroup] ([Id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_BloodGroup]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_DonorGender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[DonorGender] ([Id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_DonorGender]
GO
ALTER TABLE [dbo].[NeedBloodRequestTable]  WITH CHECK ADD  CONSTRAINT [FK_NeedBloodRequestTable_Area] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[NeedBloodRequestTable] CHECK CONSTRAINT [FK_NeedBloodRequestTable_Area]
GO
ALTER TABLE [dbo].[NeedBloodRequestTable]  WITH CHECK ADD  CONSTRAINT [FK_NeedBloodRequestTable_BloodGroup] FOREIGN KEY([BloodGroupId])
REFERENCES [dbo].[BloodGroup] ([Id])
GO
ALTER TABLE [dbo].[NeedBloodRequestTable] CHECK CONSTRAINT [FK_NeedBloodRequestTable_BloodGroup]
GO
ALTER TABLE [dbo].[NeedBloodRequestTable]  WITH CHECK ADD  CONSTRAINT [FK_NeedBloodRequestTable_DonorGender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[DonorGender] ([Id])
GO
ALTER TABLE [dbo].[NeedBloodRequestTable] CHECK CONSTRAINT [FK_NeedBloodRequestTable_DonorGender]
GO
USE [master]
GO
ALTER DATABASE [MyProject] SET  READ_WRITE 
GO
