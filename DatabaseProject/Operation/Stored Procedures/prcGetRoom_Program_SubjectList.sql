-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [Operation].[prcGetRoom_Program_SubjectList]

AS
BEGIN

SELECT * FROM Operation.Room_Subject 
JOIN Administrative.Room ON Room.RoomID = Room_Subject.RoomID
JOIN Operation.Program_Subject_Person ON Program_Subject_Person.Program_Subject_PersonID = Room_Subject.Program_Subject_PersonID

END
