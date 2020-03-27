-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcCity_UPD
(
@CityID UNIQUEIDENTIFIER,
@CityName NVARCHAR(50),
@GeographicalStateID UNIQUEIDENTIFIER
)
AS
BEGIN

UPDATE Administrative.City SET 
CityName = @CityName,
GeographicalStateID = @GeographicalStateID
WHERE CityID = @CityID;

END
