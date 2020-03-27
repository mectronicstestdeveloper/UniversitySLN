-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcProgram_Subject_Person_DEL
(
@Program_Subject_PersonID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Operation.Program_Subject_Person WHERE Program_Subject_PersonID =@Program_Subject_PersonID;
END
