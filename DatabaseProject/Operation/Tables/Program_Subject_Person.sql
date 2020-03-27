CREATE TABLE [Operation].[Program_Subject_Person] (
    [Program_Subject_PersonID] UNIQUEIDENTIFIER NOT NULL,
    [Program_SubjectID]        UNIQUEIDENTIFIER NOT NULL,
    [PersonID]                 NVARCHAR (20)    NOT NULL,
    [CurrentYear]              DATE             NOT NULL,
    [Semestre]                 CHAR (1)         NOT NULL,
    CONSTRAINT [PK_Program_Subject_Person] PRIMARY KEY CLUSTERED ([Program_Subject_PersonID] ASC),
    CONSTRAINT [FK_Person] FOREIGN KEY ([PersonID]) REFERENCES [Personal].[Person] ([PersonID]),
    CONSTRAINT [FK_ProgramSubject] FOREIGN KEY ([Program_SubjectID]) REFERENCES [Administrative].[Program_Subject] ([Program_SubjectID])
);

