-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetSubject
(
@SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.Subject
WHERE SubjectID = @SubjectID;
END
