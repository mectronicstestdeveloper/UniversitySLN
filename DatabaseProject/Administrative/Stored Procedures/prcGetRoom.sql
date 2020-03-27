-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetRoom
(
@RoomID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.Room
WHERE RoomID = @RoomID;
END
