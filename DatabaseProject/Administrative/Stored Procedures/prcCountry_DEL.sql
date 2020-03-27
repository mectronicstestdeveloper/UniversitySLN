-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Administrative].[prcCountry_DEL]
(
@CountryID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.Country WHERE CountryID = @CountryID

END
