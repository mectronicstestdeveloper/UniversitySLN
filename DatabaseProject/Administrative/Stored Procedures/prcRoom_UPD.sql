-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcRoom_UPD
(
@RoomID UNIQUEIDENTIFIER,
@RoomName NVARCHAR(50)
)
AS
BEGIN

UPDATE Administrative.Room SET 
RoomName = @RoomName
WHERE RoomID = @RoomID;

END
