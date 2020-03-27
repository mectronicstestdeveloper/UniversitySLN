CREATE TABLE [Operation].[Room_Subject] (
    [Room_SubjectID]           UNIQUEIDENTIFIER NOT NULL,
    [RoomID]                   UNIQUEIDENTIFIER NOT NULL,
    [Program_Subject_PersonID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Room_Subject] PRIMARY KEY CLUSTERED ([Room_SubjectID] ASC),
    CONSTRAINT [FK_ProgramSubjectPersonRoom] FOREIGN KEY ([Program_Subject_PersonID]) REFERENCES [Operation].[Program_Subject_Person] ([Program_Subject_PersonID]),
    CONSTRAINT [FK_Room] FOREIGN KEY ([RoomID]) REFERENCES [Administrative].[Room] ([RoomID])
);

