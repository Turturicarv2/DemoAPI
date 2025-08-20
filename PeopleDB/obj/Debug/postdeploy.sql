IF NOT EXISTS (SELECT 1 FROM dbo.Person)
begin
	INSERT INTO dbo.Person (FirstName, LastName)
	VALUES ('Tim', 'Corey'),
	('Sue', 'Storm'),
	('Jim', 'Smith'),
	('Mary', 'Jones');
end
GO
