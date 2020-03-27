-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_Subject_DEL
(
@Program_SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.Program_Subject WHERE Program_SubjectID =@Program_SubjectID;
END
