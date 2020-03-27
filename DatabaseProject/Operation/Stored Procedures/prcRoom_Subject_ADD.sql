-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcRoom_Subject_ADD
(
@Room_SubjectID UNIQUEIDENTIFIER,
@RoomID UNIQUEIDENTIFIER,
@Program_Subject_PersonID UNIQUEIDENTIFIER
)
AS
BEGIN

INSERT INTO Operation.Room_Subject
(
    Room_SubjectID,
    RoomID,
	Program_Subject_PersonID
)
VALUES
(   @Room_SubjectID, -- Room_SubjectID - uniqueidentifier
    @RoomID,
	@Program_Subject_PersonID
    )

END
