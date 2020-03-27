﻿CREATE TABLE [Administrative].[Program] (
    [ProgramID]   UNIQUEIDENTIFIER NOT NULL,
    [ProgramName] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_PROGRAMA] PRIMARY KEY CLUSTERED ([ProgramID] ASC)
);

