CREATE TABLE [Administrative].[Program_Subject] (
    [Program_SubjectID] UNIQUEIDENTIFIER NOT NULL,
    [ProgramID]         UNIQUEIDENTIFIER NOT NULL,
    [SubjectID]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_PROGRAMA_MATERIA] PRIMARY KEY CLUSTERED ([Program_SubjectID] ASC),
    CONSTRAINT [FK_Program] FOREIGN KEY ([ProgramID]) REFERENCES [Administrative].[Program] ([ProgramID]),
    CONSTRAINT [FK_Subject] FOREIGN KEY ([SubjectID]) REFERENCES [Administrative].[Subject] ([SubjectID])
);

