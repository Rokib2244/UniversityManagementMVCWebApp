USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 21-Jun-17 11:36:04 AM ******/
CREATE DATABASE [UniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocateClassRoom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[CourseID] [int] NULL,
	[RoomID] [int] NOT NULL,
	[Day] [varchar](4) NULL,
	[FromTime] [varchar](20) NULL,
	[ToTime] [varchar](20) NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseEnroll]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseEnroll](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[CourseID] [int] NOT NULL,
	[CourseGrade] [varchar](50) NULL,
 CONSTRAINT [PK_CourseEnroll] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveClassRoom]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveClassRoom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_SaveClassRoom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveCourse]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveCourse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[SemesterID] [int] NOT NULL,
	[Assigned] [varchar](10) NOT NULL,
	[TeacherID] [int] NULL,
 CONSTRAINT [PK_SaveCourse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveDepartment]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SaveDepartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveStudent]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveStudent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](700) NOT NULL,
	[RegistrationNo] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_SaveStudent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveTeacher]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveTeacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNumber] [varchar](100) NOT NULL,
	[DesignationID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[TotalCredit] [decimal](18, 2) NOT NULL,
	[RemainingCredit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SaveTeacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Semester] [int] NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ClassRoomAllocationAndClassSchedule]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClassRoomAllocationAndClassSchedule]
AS
select c.Code,c.Name as CourseName,b.Name as RoomName,a.Day,a.FromTime,a.ToTime,a.DepartmentID from AllocateClassRoom as a
inner join SaveClassRoom as b
on a.RoomID=b.ID
right join SaveCourse as c
on a.CourseID=c.ID;

GO
/****** Object:  View [dbo].[StudentCourseAssign]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[StudentCourseAssign] as 
select d.ID as DepartmentID,s.ID,s.RegistrationNo,s.Name,s.Email,d.Name as DepartmentName from SaveStudent as s 
inner join SaveDepartment as d on
s.DepartmentId=d.ID





GO
/****** Object:  View [dbo].[StudentCourseWiseView]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCourseWiseView]
AS
SELECT        s.StudentID, s.CourseGrade, c.Code, c.Name
FROM            dbo.CourseEnroll AS s LEFT OUTER JOIN
                         dbo.SaveCourse AS c ON s.CourseID = c.ID



GO
/****** Object:  View [dbo].[StudentResultView]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[StudentResultView] as
select s.StudentID,s.Name,s.Email,s.DepartmentName,s.CourseID,c.Name as CourseName
from CourseEnroll as s left join SaveCourse as c on
s.CourseID=c.ID



GO
/****** Object:  View [dbo].[ViewCourseStatics]    Script Date: 21-Jun-17 11:36:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewCourseStatics]
AS
SELECT c.Code,c.Name,c.DepartmentID,s.Semester,c.Assigned,c.TeacherID from SaveCourse as c
inner join Semesters as s
on c.SemesterID=s.ID


GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([ID], [DepartmentID], [CourseID], [RoomID], [Day], [FromTime], [ToTime]) VALUES (1, 1, NULL, 6, NULL, NULL, NULL)
INSERT [dbo].[AllocateClassRoom] ([ID], [DepartmentID], [CourseID], [RoomID], [Day], [FromTime], [ToTime]) VALUES (2, 3, NULL, 21, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[CourseEnroll] ON 

INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (7, 2, N'Mahadi', N'mahadi@mail.com', CAST(0xE63C0B00 AS Date), N'Chemistry', 12, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (8, 5, N'Masud', N'masud@gmail.com', CAST(0xE63C0B00 AS Date), N'Computer Science And Engineering', 9, N'C')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (9, 5, N'Masud', N'masud@gmail.com', CAST(0xE53C0B00 AS Date), N'Computer Science And Engineering', 10, N'C')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (10, 12, N'Jamal', N'jamal@mail.com', CAST(0xE83C0B00 AS Date), N'Mathematics', 8, N'B+')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (11, 3, N'Jabbar', N'jabbar@mail.com', CAST(0xE93C0B00 AS Date), N'Chemistry', 15, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (12, 8, N'Rokib', N'rokib@gmail.com', CAST(0xE83C0B00 AS Date), N'Computer Science And Engineering', 9, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (13, 8, N'Rokib', N'rokib@gmail.com', CAST(0xE93C0B00 AS Date), N'Computer Science And Engineering', 10, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (14, 8, N'Rokib', N'rokib@gmail.com', CAST(0xEE3C0B00 AS Date), N'Computer Science And Engineering', 19, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (15, 4, N'sowkat', N'sowkat@mail.com', CAST(0xED3C0B00 AS Date), N'Chemistry', 12, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (16, 8, N'Rokib', N'rokib@gmail.com', CAST(0xE63C0B00 AS Date), N'Computer Science And Engineering', 18, N'A+')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (17, 9, N'Fahad', N'fahad@mail.com', CAST(0xED3C0B00 AS Date), N'Computer Science And Engineering', 18, N'Not graded yet')
INSERT [dbo].[CourseEnroll] ([ID], [StudentID], [Name], [Email], [Date], [DepartmentName], [CourseID], [CourseGrade]) VALUES (18, 9, N'Fahad', N'fahad@mail.com', CAST(0xF23C0B00 AS Date), N'Computer Science And Engineering', 19, N'Not graded yet')
SET IDENTITY_INSERT [dbo].[CourseEnroll] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (3, N'Lecturer')
INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (4, N'Assistant Professor')
INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (5, N'Research Instructor')
INSERT [dbo].[Designation] ([ID], [Designation]) VALUES (6, N'Visiting Professor')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[SaveClassRoom] ON 

INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (1, N'101', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (2, N'102', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (3, N'103', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (4, N'104', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (6, N'105', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (7, N'201', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (8, N'202', 1)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (9, N'101', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (10, N'102', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (11, N'103', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (12, N'104', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (13, N'105', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (14, N'201', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (15, N'202', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (16, N'203', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (17, N'204', 2)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (19, N'101', 3)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (20, N'102', 3)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (21, N'201', 3)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (22, N'202', 3)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (23, N'203', 3)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (24, N'101', 4)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (25, N'102', 4)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (26, N'201', 4)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (27, N'205', 4)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (28, N'101', 5)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (29, N'103', 5)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (30, N'105', 5)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (31, N'205', 5)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (32, N'207', 5)
INSERT [dbo].[SaveClassRoom] ([ID], [Name], [DepartmentID]) VALUES (33, N'206', 5)
SET IDENTITY_INSERT [dbo].[SaveClassRoom] OFF
SET IDENTITY_INSERT [dbo].[SaveCourse] ON 

INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (2, N'APEC-611', N'Digital Electronics', CAST(3.00 AS Decimal(18, 2)), N'digital electronics', 1, 5, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (3, N'APEC-711', N'Digital Electronics-2', CAST(3.00 AS Decimal(18, 2)), N'uuuuuu', 1, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (4, N'APEC-712', N'Microwave', CAST(4.00 AS Decimal(18, 2)), N'Microwave Engineering', 1, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (5, N'APEC-216', N'Economics', CAST(2.00 AS Decimal(18, 2)), N'Economics', 1, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (8, N'MATH-238', N'Geometry', CAST(4.00 AS Decimal(18, 2)), N'Advance Geometry', 3, 2, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (9, N'CSE-3201', N'Algorithm', CAST(3.00 AS Decimal(18, 2)), N'Data Structures & Algorithm', 2, 4, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (10, N'CSE-3501', N'Microprocessor', CAST(3.00 AS Decimal(18, 2)), N'Microprocessor', 2, 5, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (12, N'CHEM-101', N'Organic Chemistry', CAST(4.00 AS Decimal(18, 2)), N'Organic chemistry', 4, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (15, N'CHEM-102', N'Organic Chemistry Lab', CAST(2.00 AS Decimal(18, 2)), N'Organic chemistry Lab', 4, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (16, N'ENG-2001', N'Creative Writing: Fiction', CAST(3.00 AS Decimal(18, 2)), N'Writing Fiction', 8, 3, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (18, N'CSE-1001', N'C Programming', CAST(3.00 AS Decimal(18, 2)), N'C Programming', 2, 1, N'False', NULL)
INSERT [dbo].[SaveCourse] ([ID], [Code], [Name], [Credit], [Description], [DepartmentID], [SemesterID], [Assigned], [TeacherID]) VALUES (19, N'CSE-2001', N'Object Oriented Programming I', CAST(3.00 AS Decimal(18, 2)), N'Object Oriented Programming', 2, 3, N'False', NULL)
SET IDENTITY_INSERT [dbo].[SaveCourse] OFF
SET IDENTITY_INSERT [dbo].[SaveDepartment] ON 

INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (1, N'EEE', N'Electrical and Electronics Engineering')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (2, N'CSE', N'Computer Science And Engineering')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (3, N'MATH', N'Mathematics')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (4, N'CHEM', N'Chemistry')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (5, N'PHY', N'Physics')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (8, N'ELL', N'English Language & Literature')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (9, N'SE', N'Software Engineering')
INSERT [dbo].[SaveDepartment] ([ID], [Code], [Name]) VALUES (10, N'AE', N'Aerospace Engineering')
SET IDENTITY_INSERT [dbo].[SaveDepartment] OFF
SET IDENTITY_INSERT [dbo].[SaveStudent] ON 

INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (1, N'Banzir', N'banzir@mail.com', N'012839232732', CAST(0xEB3C0B00 AS Date), N'CTG', N'CHEM-2017-001', 4)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (2, N'Mahadi', N'mahadi@mail.com', N'02323234834', CAST(0xE43C0B00 AS Date), N'DHK', N'CHEM-2017-002', 4)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (3, N'Jabbar', N'jabbar@mail.com', N'02738446343', CAST(0xF0390B00 AS Date), N'CTG', N'CHEM-2015-001', 4)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (4, N'sowkat', N'sowkat@mail.com', N'01234568989', CAST(0x313A0B00 AS Date), N'ctg', N'CHEM-2015-002', 4)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (5, N'Masud', N'masud@gmail.com', N'02393728734', CAST(0xF23C0B00 AS Date), N'ctg', N'CSE-2017-001', 2)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (8, N'Rokib', N'rokib@gmail.com', N'565656565656', CAST(0xF23C0B00 AS Date), N'ctg', N'CSE-2017-002', 2)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (9, N'Fahad', N'fahad@mail.com', N'677654545', CAST(0xEC3C0B00 AS Date), N'ctg', N'CSE-2017-003', 2)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (10, N'Morshed', N'morshed@mail.com', N'1211212121221', CAST(0xE83C0B00 AS Date), N'ctg', N'ELL-2017-001', 8)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (12, N'Jamal', N'jamal@mail.com', N'45454545454', CAST(0xF23C0B00 AS Date), N'ctg', N'MATH-2017-001', 3)
INSERT [dbo].[SaveStudent] ([ID], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (14, N'Jamil', N'jamil@gmail.com', N'93430422332', CAST(0xEC3C0B00 AS Date), N'ctg', N'EEE-2017-001', 1)
SET IDENTITY_INSERT [dbo].[SaveStudent] OFF
SET IDENTITY_INSERT [dbo].[SaveTeacher] ON 

INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (1, N'Jannatul Waheda', N'Chittagong', N'jannatulwores@gmail.com', N'01832384793', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (2, N'Judith Schneider', N'2088 Forest Avenue', N'judith@gmail.com', N'3038044961', 1, 1, CAST(8.00 AS Decimal(18, 2)), CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (3, N'Mike Greenlee', N'2077 Par Drive', N'jannatulwos@gmail.com', N'2159850443', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (4, N'Sowkat Hossain', N'Anderkilla', N'sowkat@gmail.com', N'01832384799', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (5, N'Mehdi', N'Halishohor', N'mehdi@gmail.com', N'30380449610', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (6, N'Walter Winkler', N'4646 Edgewood Avenue', N'walter@gmail.com', N'01832384797', 1, 1, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (7, N'Ashish Ciran', N'Wells', N'jannatres@gmail.com', N'30380449614', 2, 5, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (8, N'Pinto Ahmed', N'Chittagong', N'pinto@gmail.com', N'0123569875', 2, 3, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (9, N'Md Aminul Islam', N'Chittagong', N'aminul@mail.com', N'01234566', 2, 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (10, N'Robert Junior', N'Virginia', N'robert@mail.com', N'0123456645', 4, 8, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (11, N'Masud', N'Ctg', N'masud@mail.com', N'012222222', 1, 2, CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([ID], [Name], [Address], [Email], [ContactNumber], [DesignationID], [DepartmentID], [TotalCredit], [RemainingCredit]) VALUES (12, N'Rokib', N'Ctg', N'rokib@mail.com', N'012222256', 5, 8, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SaveTeacher] OFF
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (1, 1)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (2, 2)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (3, 3)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (4, 4)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (5, 5)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (6, 6)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (7, 7)
INSERT [dbo].[Semesters] ([ID], [Semester]) VALUES (8, 8)
SET IDENTITY_INSERT [dbo].[Semesters] OFF
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveClassRoom] FOREIGN KEY([RoomID])
REFERENCES [dbo].[SaveClassRoom] ([ID])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveClassRoom]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveCourse] FOREIGN KEY([CourseID])
REFERENCES [dbo].[SaveCourse] ([ID])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveCourse]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveDepartment] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[SaveDepartment] ([ID])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_SaveClassRoom_SaveDepartment] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[SaveDepartment] ([ID])
GO
ALTER TABLE [dbo].[SaveClassRoom] CHECK CONSTRAINT [FK_SaveClassRoom_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveCourse]  WITH CHECK ADD  CONSTRAINT [FK_SaveCourse_SaveDepartment] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[SaveDepartment] ([ID])
GO
ALTER TABLE [dbo].[SaveCourse] CHECK CONSTRAINT [FK_SaveCourse_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveCourse]  WITH CHECK ADD  CONSTRAINT [FK_SaveCourse_Semesters] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semesters] ([ID])
GO
ALTER TABLE [dbo].[SaveCourse] CHECK CONSTRAINT [FK_SaveCourse_Semesters]
GO
ALTER TABLE [dbo].[SaveStudent]  WITH CHECK ADD  CONSTRAINT [FK_SaveStudent_SaveStudent] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([ID])
GO
ALTER TABLE [dbo].[SaveStudent] CHECK CONSTRAINT [FK_SaveStudent_SaveStudent]
GO
ALTER TABLE [dbo].[SaveTeacher]  WITH CHECK ADD  CONSTRAINT [FK_SaveTeacher_Designation] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[Designation] ([ID])
GO
ALTER TABLE [dbo].[SaveTeacher] CHECK CONSTRAINT [FK_SaveTeacher_Designation]
GO
ALTER TABLE [dbo].[SaveTeacher]  WITH CHECK ADD  CONSTRAINT [FK_SaveTeacher_SaveTeacher] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[SaveDepartment] ([ID])
GO
ALTER TABLE [dbo].[SaveTeacher] CHECK CONSTRAINT [FK_SaveTeacher_SaveTeacher]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 136
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseWiseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseWiseView'
GO
USE [master]
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE 
GO
