using DataAccess.UnitOfWork;
using DemoAPI.Services.Exceptions;

namespace DemoAPI.Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _uow;

    public PersonService(IUnitOfWork unitOfWork)
    {
        _uow = unitOfWork;
    }

    public async Task<IEnumerable<PersonModel>> GetAllPersonsAsync()
    {
        try
        {
            return await _uow.Persons.GetPersons();
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("Error retrieving all persons", ex);
        }
    }

    public async Task<PersonModel?> GetPersonByIdAsync(int id)
    {
        try
        {
            return await _uow.Persons.GetPerson(id);
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("Error retrieving person by id", ex);
        }
    }

    public async Task<IEnumerable<string>> GetFirstNamesAsync()
    {
        try
        {
            return await _uow.Persons.GetFirstNames();
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("Error retrieving persons first names", ex);
        }
    }
    public async Task AddPersonAsync(string firstName, string lastName)
    {
        try
        {
            await _uow.Persons.InsertPerson(firstName, lastName);
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("Error Adding a person", ex);
        }
    }
    public async Task UpdatePersonAsync(PersonModel person)
    {
        try
        {
            await _uow.Persons.UpdatePerson(person);
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("", ex);
        }
    }
    public async Task DeletePersonAsync(int id)
    {
        try
        {
            await _uow.Persons.DeletePerson(id);
        }
        catch (Exception ex)
        {
            throw new PersonServiceException("", ex);
        }
    }
}
