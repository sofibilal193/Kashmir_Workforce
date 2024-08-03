namespace KC.API.Data.Extensions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object id)
            : base($"{entityName} with Id {id} was not found.")
        {
        }
    }

}
