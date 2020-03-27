-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcRoom_DEL
(
@RoomID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.Room WHERE RoomID =@RoomID;
END
