-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetCity
(
@CityID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.City
JOIN Administrative.GeographicalState ON GeographicalState.GeographicalStateID = City.GeographicalStateID
WHERE CityID = @CityID;
END
