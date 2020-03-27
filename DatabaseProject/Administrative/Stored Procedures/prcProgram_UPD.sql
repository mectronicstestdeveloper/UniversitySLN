-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_UPD
(
@ProgramID UNIQUEIDENTIFIER,
@ProgramName NVARCHAR(50)
)
AS
BEGIN

UPDATE Administrative.Program SET 
ProgramName = @ProgramName
WHERE ProgramID = @ProgramID;

END
