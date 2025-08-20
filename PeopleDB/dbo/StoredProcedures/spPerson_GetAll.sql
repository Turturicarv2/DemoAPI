CREATE PROCEDURE [dbo].[spPerson_GetAll]
AS
begin
	SELECT * FROM dbo.[Person];
end