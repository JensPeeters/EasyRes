using System;

namespace Business_layer.Exceptions
{
    public class RestaurantVolzetException : Exception
    {
        public RestaurantVolzetException()
        {

        }
        public RestaurantVolzetException(string message) : base(message)
        {
        }
        public RestaurantVolzetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
