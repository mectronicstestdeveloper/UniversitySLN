-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Operation].[prcProgram_Subject_Person_ADD]
(
@Program_Subject_PersonID UNIQUEIDENTIFIER,
@PersonID NVARCHAR(20),
@Program_SubjectID UNIQUEIDENTIFIER,
@CurrentYear DATE,
@Semestre CHAR(1)
)
AS
BEGIN

INSERT INTO Operation.Program_Subject_Person
(
    Program_Subject_PersonID,
    PersonID,
	Program_SubjectID,
	CurrentYear,
	Semestre
)
VALUES
(   @Program_Subject_PersonID, -- Program_Subject_PersonID - uniqueidentifier
    @PersonID,
	@Program_SubjectID,
	@CurrentYear,
	@Semestre
    )

END
