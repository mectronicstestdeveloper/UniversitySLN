CREATE TABLE [Administrative].[City] (
    [CityID]              UNIQUEIDENTIFIER NOT NULL,
    [CityName]            NVARCHAR (50)    NOT NULL,
    [GeographicalStateID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CIUDAD] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [FK_GeographicalState] FOREIGN KEY ([GeographicalStateID]) REFERENCES [Administrative].[GeographicalState] ([GeographicalStateID])
);

