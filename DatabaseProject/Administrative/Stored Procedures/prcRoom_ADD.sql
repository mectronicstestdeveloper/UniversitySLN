-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcRoom_ADD
(
@RoomID UNIQUEIDENTIFIER,
@RoomName NVARCHAR(50)
)
AS
BEGIN

INSERT INTO Administrative.Room
(
    RoomID,
    RoomName
)
VALUES
(   @RoomID, -- RoomID - uniqueidentifier
    @RoomName
    )

END
