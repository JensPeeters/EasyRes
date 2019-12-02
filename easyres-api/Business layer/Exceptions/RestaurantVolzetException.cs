using System;
using System.Collections.Generic;
using System.Text;

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
