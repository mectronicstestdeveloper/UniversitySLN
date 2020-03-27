-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGeographicalState_UPD
(
@GeographicalStateID UNIQUEIDENTIFIER,
@GeographicalStateName NVARCHAR(50),
@CountryID UNIQUEIDENTIFIER
)
AS
BEGIN

UPDATE Administrative.GeographicalState SET 
GeographicalStateName = @GeographicalStateName,
CountryID =  @CountryID
WHERE GeographicalStateID = @GeographicalStateID;

END
