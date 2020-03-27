-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetGeographicalStateList

AS
BEGIN

SELECT * FROM Administrative.GeographicalState 
JOIN Administrative.Country ON Country.CountryID = GeographicalState.CountryID

END
