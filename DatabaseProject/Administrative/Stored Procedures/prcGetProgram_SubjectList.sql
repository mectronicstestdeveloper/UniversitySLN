-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetProgram_SubjectList

AS
BEGIN

SELECT * FROM Administrative.Program_Subject 
JOIN Administrative.Program ON Program.ProgramID = Program_Subject.ProgramID
JOIN Administrative.Subject ON Subject.SubjectID = Program_Subject.SubjectID

END
