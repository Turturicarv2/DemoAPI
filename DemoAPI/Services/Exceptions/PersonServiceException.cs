namespace DemoAPI.Services.Exceptions;

[Serializable]
internal class PersonServiceException : Exception
{
    public PersonServiceException()
    {
    }

    public PersonServiceException(string? message) : base(message)
    {
    }

    public PersonServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}