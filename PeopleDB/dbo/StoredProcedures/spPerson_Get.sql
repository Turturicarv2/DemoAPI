CREATE PROCEDURE [dbo].[spPerson_Get]
	@Id int
AS
begin
	SELECT * FROM dbo.Person
	WHERE Id = @Id;
end