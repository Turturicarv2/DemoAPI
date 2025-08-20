CREATE PROCEDURE [dbo].[spPerson_GetFirstNames]
AS
begin
	SELECT FirstName FROM dbo.Person;
end