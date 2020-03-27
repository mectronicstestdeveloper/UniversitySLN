
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Administrative].[prcPersonType_ADD]
(
@PersonTypeID UNIQUEIDENTIFIER,
@PersonTypeName NVARCHAR(50),
@PersonStudent BIT
)
AS
BEGIN

INSERT INTO Administrative.PersonType
(
    PersonTypeID,
    PersonTypeName,
	PersonStudent
)
VALUES
(   @PersonTypeID, -- PersonTypeID - uniqueidentifier
    @PersonTypeName,
	@PersonStudent
    )

END
