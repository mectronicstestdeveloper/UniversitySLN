-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcSubject_ADD
(
@SubjectID UNIQUEIDENTIFIER,
@SubjectName NVARCHAR(50)
)
AS
BEGIN

INSERT INTO Administrative.Subject
(
    SubjectID,
    SubjectName
)
VALUES
(   @SubjectID, -- SubjectID - uniqueidentifier
    @SubjectName
    )

END
