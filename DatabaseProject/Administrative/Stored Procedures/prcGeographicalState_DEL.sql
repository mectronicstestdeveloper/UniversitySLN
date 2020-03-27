-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGeographicalState_DEL
(
@GeographicalStateID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.GeographicalState WHERE GeographicalStateID =@GeographicalStateID;
END
