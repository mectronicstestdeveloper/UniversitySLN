-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcRoom_Subject_DEL
(
@Room_SubjectID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Operation.Room_Subject WHERE Room_SubjectID =@Room_SubjectID;
END
