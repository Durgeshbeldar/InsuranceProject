namespace DsInsurance.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string entity, string field) : base($"{entity} with the specified {field} already exists.") { }
    }

}
