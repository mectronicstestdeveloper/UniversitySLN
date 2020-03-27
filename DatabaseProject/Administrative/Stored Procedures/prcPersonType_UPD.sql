
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Administrative].[prcPersonType_UPD]
(
@PersonTypeID UNIQUEIDENTIFIER,
@PersonTypeName NVARCHAR(50),
@PersonStudent bit
)
AS
BEGIN

UPDATE Administrative.PersonType SET 
PersonTypeName = @PersonTypeName,
PersonStudent = @PersonStudent
WHERE PersonTypeID = @PersonTypeID;

END
