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
        private string _governmentId;
        private Address _address;
    }
}
