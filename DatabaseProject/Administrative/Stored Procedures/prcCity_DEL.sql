-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcCity_DEL
(
@CityID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.City WHERE CityID =@CityID;
END
