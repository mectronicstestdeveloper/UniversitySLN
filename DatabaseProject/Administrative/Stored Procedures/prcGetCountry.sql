-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetCountry
(
@CountryID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.Country
WHERE CountryID = @CountryID;
END
