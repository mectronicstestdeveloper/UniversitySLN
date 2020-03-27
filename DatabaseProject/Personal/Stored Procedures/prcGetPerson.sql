-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Personal].[prcGetPerson]
(
@PersonID NVARCHAR(20)
)
AS
BEGIN

SELECT * FROM Personal.Person
JOIN Administrative.City ON City.CityID = Person.CityID
JOIN Administrative.PersonType ON PersonType.PersonTypeID = Person.PersonTypeID
WHERE PersonID = @PersonID;
END
