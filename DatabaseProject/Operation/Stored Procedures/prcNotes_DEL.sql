-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE Operation.prcNotes_DEL
(
@NotesID UNIQUEIDENTIFIER
)
AS
BEGIN

DELETE FROM Operation.Notes WHERE NotesID =@NotesID;
END
