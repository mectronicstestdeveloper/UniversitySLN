-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcSubject_UPD
(
@SubjectID UNIQUEIDENTIFIER,
@SubjectName NVARCHAR(50)
)
AS
BEGIN

UPDATE Administrative.Subject SET 
SubjectName = @SubjectName
WHERE SubjectID = @SubjectID;

END
