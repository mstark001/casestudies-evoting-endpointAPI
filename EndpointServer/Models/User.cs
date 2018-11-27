using System;
namespace EndpointServer.Models
{
    public class User
    {
        private string _votingCode;

        private string _oauthCode;
        private string _registeredConsituency;


        private Country _country;
        private string _nationality;
        private DateTime _dob;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _postCode;
        private Address _address;

        public string GetPostcode()
        {
            return _postCode;
        }


        public void SetVotingCode(string votingCode)
        {
            _votingCode = votingCode;
        }

        public void SetOAuthCoode(string oauth)
        {
            _oauthCode = oauth;
        }

        public void SetRegisteredConsituency(string cons)
        {
            _registeredConsituency = cons;
        }

        public void SetCountry(Country country)
        {
            _country = country;
        }

        public void SetNationality(string nationality)
        {
            _nationality = nationality;
        }

        public void SetDoB(DateTime date)
        {
            _dob = date;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public void SetMiddleName(string middleName)
        {
            _middleName = middleName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public void SetPostCode(string postcode)
        {
            _postCode = postcode;
        }

        public void SetAddress(Address add)
        {
            _address = add;
        }



    }
}
