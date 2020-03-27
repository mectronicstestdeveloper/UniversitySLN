-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcNotes_ADD
(
@NotesID UNIQUEIDENTIFIER,
@Program_Subject_PersonID UNIQUEIDENTIFIER,
@NotePeriod1 DECIMAL(18,0),
@NotePeriod2 DECIMAL(18,0)
)
AS
BEGIN

INSERT INTO Operation.Notes
(
    NotesID,
	Program_Subject_PersonID,
	NotePeriod1,
	NotePeriod2
)
VALUES
(   @NotesID, 
	@Program_Subject_PersonID,
	@NotePeriod1,
	@NotePeriod2
    )

END
