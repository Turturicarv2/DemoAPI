using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class PersonData : IPersonData
{
    private readonly ISqlDataAccess _access;

    public PersonData(ISqlDataAccess access)
    {
        _access = access;
    }

    public Task<IEnumerable<PersonModel>> GetPersons() =>
        _access.LoadData<PersonModel, dynamic>("dbo.spPerson_GetAll", new { });

    public async Task<PersonModel?> GetPerson(int id)
    {
        var result = await _access.LoadData<PersonModel, dynamic>("spPerson_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task<IEnumerable<String>> GetFirstNames() =>
        _access.LoadData<String, dynamic>("dbo.spPerson_GetFirstNames", new { });

    public Task InsertPerson(String FirstName, String LastName) =>
        _access.SaveData("spPerson_Insert", new {FirstName, LastName});

    public Task UpdatePerson(PersonModel person) =>
        _access.SaveData("spPerson_Update", person);

    public Task DeletePerson(int id) =>
        _access.SaveData("spPerson_Delete", new { Id = id });
}
