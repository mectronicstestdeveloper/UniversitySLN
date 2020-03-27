-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Personal.prcPerson_DEL
(
@PersonID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Personal.Person WHERE PersonID =@PersonID;
END
