CREATE PROCEDURE [dbo].[spPerson_Insert]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
begin
	INSERT INTO dbo.Person (FirstName, LastName)
	values (@FirstName, @LastName);
end