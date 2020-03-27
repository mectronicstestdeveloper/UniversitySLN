-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcPersonType_DEL
(
@PersonTypeID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.PersonType WHERE PersonTypeID =@PersonTypeID;
END
