namespace LatihanASPNetCore.Core
{
    public class InternalServerErrorException : Exception 
    {
        public InternalServerErrorException(string message) : base(message)
        {

        }
    }

    public class NotFoundException : Exception 
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
