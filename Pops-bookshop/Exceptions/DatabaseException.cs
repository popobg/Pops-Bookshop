namespace Pops_bookshop.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException()
            : base("The database is temporary unavailable. Please, try again later.")
        {
        }

        public DatabaseException(string message)
    : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
