-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcCity_ADD
(
@CityID UNIQUEIDENTIFIER,
@CityName NVARCHAR(50),
@GeographicalStateID UNIQUEIDENTIFIER
)
AS
BEGIN

INSERT INTO Administrative.City
(
    CityID,
    CityName,
    GeographicalStateID
)
VALUES
(   @CityID, -- CityID - uniqueidentifier
    @CityName,
    @GeographicalStateID  -- GeographicalStateID - uniqueidentifier
    )

END
