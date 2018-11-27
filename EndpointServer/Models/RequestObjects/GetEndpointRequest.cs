using System;
namespace EndpointServer.Models.RequestObjects
{
    public class GetEndpointRequest
    {
        private string _oauth;
        private string _votingCode;

        public string GetOAuth()
        {
            return _oauth;
        }

        public string GetVotingCode()
        {
            return _votingCode;
        }
    }
}
