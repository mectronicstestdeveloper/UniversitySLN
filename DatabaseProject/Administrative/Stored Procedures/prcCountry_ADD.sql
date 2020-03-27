-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcCountry_ADD
(
@CountryID UNIQUEIDENTIFIER,
@CountryName NVARCHAR(50)
)
AS
BEGIN

INSERT INTO Administrative.Country
(
    CountryID,
    CountryName
)
VALUES
(   @CountryID, -- CountryID - uniqueidentifier
    @CountryName
    )

END
