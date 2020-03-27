-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGeographicalState_ADD
(
@GeographicalStateID UNIQUEIDENTIFIER,
@GeographicalStateName NVARCHAR(50),
@CountryID UNIQUEIDENTIFIER
)
AS
BEGIN

INSERT INTO Administrative.GeographicalState
(
    GeographicalStateID,
    GeographicalStateName,
	CountryID
)
VALUES
(   @GeographicalStateID, -- GeographicalStateID - uniqueidentifier
    @GeographicalStateName,
	@CountryID
    )

END
