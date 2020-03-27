-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Personal.prcGetPersonList

AS
BEGIN

SELECT * FROM Personal.Person 
JOIN Administrative.City ON City.CityID = Person.CityID
JOIN Administrative.PersonType ON PersonType.PersonTypeID = Person.PersonTypeID
END
