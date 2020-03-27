-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_Subject_UPD
(
@Program_SubjectID UNIQUEIDENTIFIER,
@ProgramID UNIQUEIDENTIFIER,
@SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

UPDATE Administrative.Program_Subject SET 
ProgramID = @ProgramID,
SubjectID = @SubjectID
WHERE Program_SubjectID = @Program_SubjectID;

END
