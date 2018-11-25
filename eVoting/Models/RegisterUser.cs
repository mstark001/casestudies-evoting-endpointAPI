using System;
namespace eVoting.Models
{
    public class RegisterUser
    {
        private Country _country;
        private string _nationality;
        private DateTime _dob;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _governmentId;
        private Address _address;

        //Setters
        public void SetCountry(Country country)
        {
            _country = country;
        }

        public void SetNationality(string nationality)
        {
            _nationality = nationality;
        }

        public void SetDateOfBirth(DateTime date)
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

        public void SetGovernmentId(string governmentId)
        {
            _governmentId = governmentId;
        }

        public void SetAddress(Address address)
        {
            _address = address;
        }


        //Getters
        public Country GetCountry()
        {
            return _country;
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

        public string GetSurname()
        {
            return _lastName;
        }

        public string GetGovernmentId()
        {
            return _governmentId;
        }

        public Address GetAddress()
        {
            return _address;
        }

    }
}
