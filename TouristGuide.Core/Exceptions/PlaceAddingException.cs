namespace TouristGuide.Core.Exceptions
{
    public class PlaceAddingException : ApplicationException
    {
        public PlaceAddingException()
        {
                
        }

        public PlaceAddingException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
