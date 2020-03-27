-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcCountry_UPD
(
@CountryID UNIQUEIDENTIFIER,
@CountryName NVARCHAR(50)
)
AS
BEGIN

UPDATE Administrative.Country SET 
CountryName = @CountryName
WHERE CountryID = @CountryID;

END
