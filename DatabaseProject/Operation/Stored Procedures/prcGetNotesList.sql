-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcGetNotesList

AS
BEGIN

SELECT * FROM Operation.Notes 
JOIN Operation.Program_Subject_Person ON Program_Subject_Person.Program_Subject_PersonID = Notes.Program_Subject_PersonID

END
