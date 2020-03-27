-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Operation].[prcGetProgram_Subject_PersonList]

AS
BEGIN

SELECT * FROM Operation.Program_Subject_Person 
JOIN Personal.Person ON Person.PersonID = Program_Subject_Person.PersonID
JOIN Administrative.Program_Subject ON Program_Subject.Program_SubjectID = Program_Subject_Person.Program_SubjectID

END
