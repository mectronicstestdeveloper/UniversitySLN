-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetPersonType
(
@PersonTypeID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.PersonType
WHERE PersonTypeID = @PersonTypeID;
END
