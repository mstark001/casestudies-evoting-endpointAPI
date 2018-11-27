using System;
namespace EndpointServer.Models.RequestObjects
{
    public class SignupOAuthRequest
    {
        private string _firstName;
        private string _lastName;
        private string _postCode;

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetPostcode()
        {
            return _postCode;
        }
    }
}
