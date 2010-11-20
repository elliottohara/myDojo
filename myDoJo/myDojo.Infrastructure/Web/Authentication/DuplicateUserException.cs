using System;

namespace myDojo.Infrastructure.Web
{
    public class DuplicateUserException : Exception
    {
        private readonly string _username;

        public DuplicateUserException(string username)
        {
            _username = username;
        }
        public override string Message
        {
            get { return _username + " already exists."; }
        }
    }
}