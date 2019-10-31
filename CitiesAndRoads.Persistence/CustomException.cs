using System;

namespace CitiesAndRoads.Persistence
{
    public class CustomException : Exception
    {
        public CustomException()
        {

        }

        public CustomException(string message)
            : base(message)
        {

        }
    }
}
