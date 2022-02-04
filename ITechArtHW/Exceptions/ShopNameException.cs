using System;

namespace ITechArtHW.Exceptions
{
    public class ShopNameException : Exception
    {
        public ShopNameException(string message) : base(message)
        {
        }
    }
}