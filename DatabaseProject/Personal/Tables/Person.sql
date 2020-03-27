CREATE TABLE [Personal].[Person] (
    [PersonID]             NVARCHAR (20)    NOT NULL,
    [PersonName]           NVARCHAR (80)    NOT NULL,
    [PersonFirstLastName]  NVARCHAR (80)    NOT NULL,
    [PersonSecondLastName] NVARCHAR (80)    NOT NULL,
    [PersonSex]            CHAR (1)         NOT NULL,
    [CityID]               UNIQUEIDENTIFIER NOT NULL,
    [PersonAddress]        NVARCHAR (80)    NOT NULL,
    [PersonBirthDate]      DATE             NOT NULL,
    [PersonPhone]          NVARCHAR (20)    NOT NULL,
    [PersonTypeID]         UNIQUEIDENTIFIER NOT NULL,
    [PersonSingUp]         DATETIME         NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonID] ASC),
    CONSTRAINT [FK_City] FOREIGN KEY ([CityID]) REFERENCES [Administrative].[City] ([CityID]),
    CONSTRAINT [FK_PersonType] FOREIGN KEY ([PersonTypeID]) REFERENCES [Administrative].[PersonType] ([PersonTypeID])
);

