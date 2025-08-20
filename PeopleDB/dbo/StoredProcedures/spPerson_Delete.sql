CREATE PROCEDURE [dbo].[spPerson_Delete]
	@Id int
AS
begin
	DELETE FROM dbo.Person
	WHERE Id = @Id;
end