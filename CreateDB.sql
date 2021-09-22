-- todo: make this idempotent

--drop DATABASE Travel

CREATE DATABASE Travel

USE Travel

CREATE TABLE [Country] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(255) NOT NULL,
    [Currency] VARCHAR(10) NOT NULL
)

INSERT INTO [Country] ([Name], [Currency]) VALUES
    ('Mexico', 'MXN'),
    ('Japan', 'JPY'),
    ('Austrailia', 'AUD'),
    ('Canada', 'CAD'),
    ('England', 'GBP'),
    ('France', 'EUR')

CREATE TABLE [Booking] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Destination] INT NOT NULL FOREIGN KEY REFERENCES Country(Id),
    [Duration] INT NOT NULL,
    [Username] VARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
)
