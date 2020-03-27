CREATE TABLE [Administrative].[GeographicalState] (
    [GeographicalStateID]   UNIQUEIDENTIFIER NOT NULL,
    [GeographicalStateName] NVARCHAR (50)    NOT NULL,
    [CountryID]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_DEPARTAMENTO] PRIMARY KEY CLUSTERED ([GeographicalStateID] ASC),
    CONSTRAINT [FK_Country] FOREIGN KEY ([CountryID]) REFERENCES [Administrative].[Country] ([CountryID])
);

