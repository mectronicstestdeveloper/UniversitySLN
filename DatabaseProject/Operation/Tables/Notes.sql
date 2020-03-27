CREATE TABLE [Operation].[Notes] (
    [NotesID]                  UNIQUEIDENTIFIER NOT NULL,
    [NotePeriod1]              DECIMAL (18)     NOT NULL,
    [NotePeriod2]              DECIMAL (18)     NOT NULL,
    [Program_Subject_PersonID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NotesID] ASC),
    CONSTRAINT [FK_ProgramSubjectPerson] FOREIGN KEY ([Program_Subject_PersonID]) REFERENCES [Operation].[Program_Subject_Person] ([Program_Subject_PersonID])
);

