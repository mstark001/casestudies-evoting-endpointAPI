using System;
namespace EndpointServer.Models.RequestObjects
{
    public class RegisterAnnoymousUserRequest
    {
        private string _additionalDetails;
        private byte[] _formData;
        private string _oauth;

        private string _generatedFirstName;
        private string _generatedLastName;
        private string _generatedPostcode;

        public string GetAdditionalDetails()
        {
            return _additionalDetails;
        }

        public byte[] GetFormData()
        {
            return _formData;
        }

        public string GetOAuth()
        {
            return _oauth;
        }

        public string GetGeneratedFirstName()
        {
            return _generatedFirstName;
        }

        public string GetGeneratedLastName()
        {
            return _generatedLastName;
        }

        public string GetGeneratedPostcode()
        {
            return _generatedPostcode;
        }
    }
}
