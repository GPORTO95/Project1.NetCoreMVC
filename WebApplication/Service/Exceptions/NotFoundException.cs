using System;

namespace WebApplication.Service.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
