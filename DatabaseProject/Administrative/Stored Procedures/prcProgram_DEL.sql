-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_DEL
(
@ProgramID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Administrative.Program WHERE ProgramID =@ProgramID;
END
