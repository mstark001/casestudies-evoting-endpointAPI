using System;
namespace EndpointServer.Models.RequestObjects
{
    public class RegisterNewUserRequest
    {
        private Country _country;
        private string _nationality;
        private DateTime _dob;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _postCode;
        private Address _address;
        private string _oAuth;

        public Country GetCountry()
        {
            return _country;
        }

        public string GetOAuth()
        {
            return _oAuth;
        }

        public string GetNationality()
        {
            return _nationality;
        }

        public DateTime GetDoB()
        {
            return _dob;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetMiddleName()
        {
            return _middleName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetPostcode()
        {
            return _postCode;
        }

        public Address GetAddress()
        {
            return _address;
        }
    }
}
