-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_Subject_ADD
(
@Program_SubjectID UNIQUEIDENTIFIER,
@ProgramID UNIQUEIDENTIFIER,
@SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

INSERT INTO Administrative.Program_Subject
(
    Program_SubjectID,
    ProgramID,
	SubjectID
)
VALUES
(   @Program_SubjectID, -- Program_SubjectID - uniqueidentifier
    @ProgramID,
	@SubjectID
    )

END
