-- Create database and switch context to it
USE master;
GO
DROP DATABASE IF EXISTS Music;
GO
CREATE DATABASE Music;
GO
USE Music;

-- Create Tables
CREATE TABLE Artist (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE PERSON (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL
);

CREATE TABLE ArtistPerson (
    PersonId INT NOT NULL,
    ArtistId INT NOT NULL
);

CREATE TABLE ArtistTrack (
    TrackId INT NOT NULL,
    ArtistId INT NOT NULL
);

CREATE TABLE Album (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL,
    ArtistId int NOT NULL
);

CREATE TABLE Track (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NOT NULL,
    AlbumId int NOT NULL,
    PrimaryArtistId int NOT NULL,
    WriterPersonId int NOT NULL
);

-- Create Restraints
ALTER TABLE Track 
    ADD CONSTRAINT FK_Track_Album_AlbumID FOREIGN KEY (AlbumID) REFERENCES Album(Id);
ALTER TABLE Track 
    ADD CONSTRAINT FK_Track_Artist_PrimaryArtistId FOREIGN KEY (PrimaryArtistId) REFERENCES Artist(Id);
ALTER TABLE Track 
    ADD CONSTRAINT FK_Track_Person_WriterPersonId FOREIGN KEY (WriterPersonId) REFERENCES Person(Id);

ALTER TABLE Album
    ADD CONSTRAINT FK_Album_Artist_ArtistID FOREIGN KEY (ArtistID) REFERENCES Artist(Id);

ALTER TABLE ArtistTrack
    ADD CONSTRAINT FK_ArtistTrack_Artist_ArtistId FOREIGN KEY (ArtistId) REFERENCES Artist(Id);
ALTER TABLE ArtistTrack
    ADD CONSTRAINT FK_ArtistTrack_Track_TrackId FOREIGN KEY (TrackId) REFERENCES Track(Id);
ALTER TABLE ArtistTrack
    ADD CONSTRAINT PK_ArtistTrack PRIMARY KEY (ArtistId, TrackId);

ALTER TABLE ArtistPerson
    ADD CONSTRAINT FK_ArtistPerson_Artist_ArtistId FOREIGN KEY (ArtistId) REFERENCES Artist(Id);
ALTER TABLE ArtistPerson
    ADD CONSTRAINT FK_ArtistPerson_Person_PersonId FOREIGN KEY (PersonId) REFERENCES Person(Id);
ALTER TABLE ArtistPerson
    ADD CONSTRAINT PK_ArtistPerson PRIMARY KEY (ArtistId, PersonId);

-- Insert Data
INSERT INTO Person ([Name]) VALUES
    ('Beyoncé Knowles'),
    ('Joshua Coleman'),
    ('Sia Furler'),
    ('Knowles'),
    ('Brian Soko'),
    ('Jerome Harmon'),
    ('Shawn Carter'),
    ('Andre Eric Proctor'),
    ('Rasool Díaz'),
    ('Timothy Mosley'),
    ('Noel Fisher'),
    ('Pharrell Williams'),
    ('Frank Ocean');

-- SELECT * FROM Person;

INSERT INTO Artist ([Name]) VALUES
    ('Frank Ocean'),
    ('Jay-Z'),
    ('Beyoncé');

INSERT INTO ArtistPerson (PersonId, ArtistId) VALUES
    (13, 1),
    (7, 2),
    (1, 3);

-- SELECT * FROM Person
-- LEFT OUTER JOIN ArtistPerson ON ArtistPerson.PersonId = Person.Id
-- LEFT OUTER JOIN Artist ON ArtistPerson.ArtistId = Artist.Id;

INSERT INTO Album ([Name]) VALUES
    ('Lemonade'),
    ('Blonde'),
    ('Beyoncé');

INSERT INTO Track ([Name], AlbumId, PrimaryArtistId, WriterPersonId) VALUES 
    ('Pretty Hurts', 3, ),
    ();