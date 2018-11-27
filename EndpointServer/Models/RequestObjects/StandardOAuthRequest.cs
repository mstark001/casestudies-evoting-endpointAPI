using System;
namespace EndpointServer.Models.RequestObjects
{
    public class StandardOAuthRequest
    {
        private string _postCode;
        private string _votingCode;

        public string GetPostcode()
        {
            return _postCode;
        }

        public string GetVotingcode()
        {
            return _votingCode;
        }
    }
}
