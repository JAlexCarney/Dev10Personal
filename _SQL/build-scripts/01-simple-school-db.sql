USE Master;
GO

CREATE DATABASE SimpleSchool;
GO

USE SimpleSchool;
GO

CREATE TABLE GradeType (
    GradeTypeID int identity(1,1) primary key,
    GradeTypeName varchar(25) not null
)
GO

CREATE TABLE GradeItem (
    GradeItemID int identity(1,1) primary key,
    GradeTypeID int foreign key references GradeType(GradeTypeID) not null,
    PointsPossible decimal(5,2) not null default 0,
    [Description] varchar(255) not null
)
GO

CREATE TABLE [Subject] (
    SubjectID int identity(1,1) primary key,
    SubjectName varchar(50) not null
)
GO

CREATE TABLE Course (
    CourseID int identity(1,1) primary key,
    SubjectID int foreign key references [Subject](SubjectID) not null,
    CourseName varchar(50) not null,
    CreditHours decimal(3,2) not null default 0
)
GO

CREATE TABLE [Period] (
    PeriodID int identity(1,1) primary key,
    PeriodName varchar(50) not null,
    StartTime time(7) not null,
    EndTime time(7) not null
)
GO

CREATE TABLE Semester (
    SemesterID int identity(1,1) primary key,
    StartDate date not null,
    EndDate date not null,
    [Description] varchar(50) null
)
GO

CREATE TABLE Building (
    BuildingID int identity(1,1) primary key,
    BuildingName varchar(50) not null
)
GO

CREATE TABLE Room (
    RoomID int identity(1,1) primary key,
    BuildingID int foreign key references [Building](BuildingID) not null,
    RoomNumber int not null default(0),
    [Description] varchar(50) null
)
GO

CREATE TABLE Teacher (
    TeacherID int identity(1,1) primary key,
    FirstName varchar(50) not null,
    LastName varchar(50) not null
)
GO

CREATE TABLE Student (
    StudentID int identity(1,1) primary key,
    FirstName varchar(50) not null,
    LastName varchar(50) not null,
    ClassYear char(4) not null
)
GO

CREATE TABLE Section (
    SectionID int identity(1,1) primary key,
    CourseID int foreign key references [Course](CourseID) not null,
    TeacherID int foreign key references [Teacher](TeacherID) not null,
    SemesterID int foreign key references [Semester](SemesterID) not null,
    PeriodID int foreign key references [Period](PeriodID) not null,
    RoomID int foreign key references [Room](RoomID) not null
)
GO

CREATE TABLE SectionRoster (
    SectionRosterID int identity(1,1) primary key,
    SectionID int foreign key references [Section](SectionID) not null,
    StudentID int foreign key references [Student](StudentID) not null,
    CurrentGrade decimal(5,2) null
)
GO

CREATE TABLE Grade (
    GradeID int identity(1,1) primary key,
    SectionRosterID int foreign key references [SectionRoster](SectionRosterID) not null,
    GradeItemID int foreign key references [GradeItem](GradeItemID) not null,
    Score decimal(5,2) null
)
GO