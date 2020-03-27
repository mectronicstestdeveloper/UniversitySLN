-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcSubject_DEL
(
@SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.Subject WHERE SubjectID =@SubjectID;
END
