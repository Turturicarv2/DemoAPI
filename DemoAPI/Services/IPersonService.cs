
namespace DemoAPI.Services;

public interface IPersonService
{
    Task AddPersonAsync(string firstName, string lastName);
    Task DeletePersonAsync(int id);
    Task<IEnumerable<PersonModel>> GetAllPersonsAsync();
    Task<IEnumerable<string>> GetFirstNamesAsync();
    Task<PersonModel?> GetPersonByIdAsync(int id);
    Task UpdatePersonAsync(PersonModel person);
}