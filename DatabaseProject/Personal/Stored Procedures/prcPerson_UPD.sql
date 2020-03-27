-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Personal].[prcPerson_UPD]
(
@PersonID NVARCHAR(20),
@CityID UNIQUEIDENTIFIER,
@PersonTypeID UNIQUEIDENTIFIER,
@PersonName NVARCHAR(80),
@PersonFirstLastName NVARCHAR(80),
@PersonSecondLastName NVARCHAR(80),
@PersonAddress NVARCHAR(80),
@PersonPhone NVARCHAR(20),
@PersonSex CHAR(1),
@PersonBirthDate DATE,
@PersonSingUp DATETIME
)
AS
BEGIN

UPDATE Personal.Person SET 

CityID=@CityID,
PersonTypeID=@PersonTypeID,
PersonName=@PersonName,
PersonFirstLastName=@PersonFirstLastName,
PersonSecondLastName=@PersonSecondLastName,
PersonAddress=@PersonAddress,
PersonPhone=@PersonPhone,
PersonSex=@PersonSex,
PersonBirthDate=@PersonBirthDate,
PersonSingUp =@PersonSingUp
WHERE PersonID = @PersonID;

END
