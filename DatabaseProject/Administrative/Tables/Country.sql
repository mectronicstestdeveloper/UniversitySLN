CREATE TABLE [Administrative].[Country] (
    [CountryID]   UNIQUEIDENTIFIER NOT NULL,
    [CountryName] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_PAIS] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

