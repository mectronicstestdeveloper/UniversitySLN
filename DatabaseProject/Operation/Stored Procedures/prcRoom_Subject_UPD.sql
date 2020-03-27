-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcRoom_Subject_UPD
(
@Room_SubjectID UNIQUEIDENTIFIER,
@RoomID UNIQUEIDENTIFIER,
@Program_Subject_PersonID UNIQUEIDENTIFIER
)
AS
BEGIN

UPDATE Operation.Room_Subject SET 
RoomID = @RoomID,
Program_Subject_PersonID = @Program_Subject_PersonID
WHERE Room_SubjectID = @Room_SubjectID;

END
