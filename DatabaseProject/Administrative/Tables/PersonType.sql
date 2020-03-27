CREATE TABLE [Administrative].[PersonType] (
    [PersonTypeID]   UNIQUEIDENTIFIER NOT NULL,
    [PersonTypeName] NVARCHAR (50)    NOT NULL,
    [PersonStudent]  BIT              NOT NULL,
    CONSTRAINT [PK_PERSONTYPE] PRIMARY KEY CLUSTERED ([PersonTypeID] ASC)
);

