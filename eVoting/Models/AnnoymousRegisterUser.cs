using System;
namespace eVoting.Models
{
    public class AnnoymousRegisterUser
    {
        private string _additionalDetails;
        private byte[] _form;

        //Getters
        public string GetAdditionalDetails()
        {
            return _additionalDetails;
        }

        public byte[] GetForm()
        {
            return _form;
        }


        //Setters
        public void SetAdditionalDetails(string details)
        {
            _additionalDetails = details;
        }

        public void SetForm(byte[] form)
        {
            _form = form;
        }


    }
}
