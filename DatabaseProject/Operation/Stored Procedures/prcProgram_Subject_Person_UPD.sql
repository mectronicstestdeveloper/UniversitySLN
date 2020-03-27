-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Operation].[prcProgram_Subject_Person_UPD]
(
@Program_Subject_PersonID UNIQUEIDENTIFIER,
@PersonID NVARCHAR(20),
@Program_SubjectID UNIQUEIDENTIFIER,
@CurrentYear DATE,
@Semestre CHAR(1)
)
AS
BEGIN

UPDATE Operation.Program_Subject_Person SET 
PersonID = @PersonID,
Program_SubjectID = @Program_SubjectID,
CurrentYear=@CurrentYear,
Semestre =@Semestre
WHERE Program_Subject_PersonID = @Program_Subject_PersonID;

END
