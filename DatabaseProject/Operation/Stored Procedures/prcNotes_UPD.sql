-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcNotes_UPD
(
@NotesID UNIQUEIDENTIFIER,
@Program_Subject_PersonID UNIQUEIDENTIFIER,
@NotePeriod1 DECIMAL(18,0),
@NotePeriod2 DECIMAL(18,0)
)
AS
BEGIN

UPDATE Operation.Notes SET 
Program_Subject_PersonID = @Program_Subject_PersonID,
NotePeriod1=@NotePeriod1,
NotePeriod2 =@NotePeriod2
WHERE NotesID = @NotesID;

END
