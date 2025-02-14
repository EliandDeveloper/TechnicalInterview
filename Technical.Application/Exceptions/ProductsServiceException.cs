
using System;

namespace Technical.Application.Exceptions
{
    public class ProductsServiceException : Exception
    {
        public ProductsServiceException(string message) : base(message)
        {

        }
    }
}
