-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcGetProgram_Subject_Person
(
@Program_Subject_PersonID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Operation.Program_Subject_Person
JOIN Personal.Person ON Person.PersonID = Program_Subject_Person.PersonID
JOIN Operation.Program_Subject ON Administrative.Program_SubjectID = Program_Subject_Person.Program_SubjectID
WHERE Program_Subject_PersonID = @Program_Subject_PersonID;
END
