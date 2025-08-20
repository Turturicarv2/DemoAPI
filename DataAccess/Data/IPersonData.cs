using DataAccess.Models;

namespace DataAccess.Data;
public interface IPersonData
{
    Task DeletePerson(int id);
    Task<PersonModel?> GetPerson(int id);
    Task<IEnumerable<PersonModel>> GetPersons();
    Task<IEnumerable<String>> GetFirstNames();
    Task InsertPerson(String FirstName, String LastName);
    Task UpdatePerson(PersonModel person);
}