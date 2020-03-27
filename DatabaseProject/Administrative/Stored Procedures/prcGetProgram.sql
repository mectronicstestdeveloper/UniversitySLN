-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcGetProgram
(
@ProgramID UNIQUEIDENTIFIER
)
AS
BEGIN

SELECT * FROM Administrative.Program
WHERE ProgramID = @ProgramID;
END
