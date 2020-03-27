
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Personal].[prcPerson_ADD]
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

INSERT INTO Personal.Person
(
PersonID,
CityID,
PersonTypeID,
PersonName,
PersonFirstLastName,
PersonSecondLastName,
PersonAddress,
PersonPhone,
PersonSex,
PersonBirthDate,
PersonSingUp 
)
VALUES
(  
@PersonID,
@CityID,
@PersonTypeID,
@PersonName,
@PersonFirstLastName,
@PersonSecondLastName,
@PersonAddress,
@PersonPhone,
@PersonSex,
@PersonBirthDate,
@PersonSingUp 
    )

END
