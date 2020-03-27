-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Administrative.prcProgram_ADD
(
@ProgramID UNIQUEIDENTIFIER,
@ProgramName NVARCHAR(50)
)
AS
BEGIN

INSERT INTO Administrative.Program
(
    ProgramID,
    ProgramName
)
VALUES
(   @ProgramID, -- ProgramID - uniqueidentifier
    @ProgramName
    )

END
