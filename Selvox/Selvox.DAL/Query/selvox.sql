CREATE DATABASE Selvox

USE Selvox

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    [Password] VARCHAR(100) NOT NULL,
    UserType VARCHAR(20) NOT NULL
);

CREATE TABLE Jobs (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    [Description] TEXT,
    EmployerID INT,
    FOREIGN KEY (EmployerID) REFERENCES Users(Id)
);

CREATE TABLE Applications (
    Id INT PRIMARY KEY IDENTITY(1,1),
    JobID INT,
    UserID INT,
    [Status] VARCHAR(20) NOT NULL,
    FOREIGN KEY (JobID) REFERENCES Jobs(Id),
    FOREIGN KEY (UserID) REFERENCES Users(Id)
);

CREATE TABLE Reviews (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReviewerID INT,
    JobID INT,
    Rating INT,
    Comment TEXT,
    FOREIGN KEY (ReviewerID) REFERENCES Users(Id),
    FOREIGN KEY (JobID) REFERENCES Jobs(Id)
);

CREATE TABLE Skills (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Users_Skills (
    UserID INT,
    SkillID INT,
    FOREIGN KEY (UserID) REFERENCES Users(Id),
    FOREIGN KEY (SkillID) REFERENCES Skills(Id)
);

CREATE TABLE Experience (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Company VARCHAR(100) NOT NULL,
    Position VARCHAR(100) NOT NULL,
    [Description] TEXT,
    StartDate DATE,
    EndDate DATE,
);

CREATE TABLE User_Experience (
    UserID INT,
    ExperienceID INT,
    FOREIGN KEY (UserID) REFERENCES Users(Id),
    FOREIGN KEY (ExperienceID) REFERENCES Experience(Id)
);

CREATE TABLE Education (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Institution VARCHAR(100) NOT NULL,
    Degree VARCHAR(100),
    Major VARCHAR(100),
    StartDate DATE,
    EndDate DATE,
);

CREATE TABLE User_Education (
    UserID INT,
    EducationID INT,
    FOREIGN KEY (UserID) REFERENCES Users(Id),
    FOREIGN KEY (EducationID) REFERENCES Education(Id)
);


