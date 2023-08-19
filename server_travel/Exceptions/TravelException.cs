namespace server_travel.Exceptions
{
    public class TravelException:Exception
    {

        public TravelException()
        {

        }
        public TravelException(string message) : base(message)
        {

        }
        public TravelException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
