using System;
namespace EndpointServer.Models.RequestObjects
{
    public class ValidateConsistunecyRequst
    {
        private string _oauth;
        private string _votingCode;
        private string _postCode;
        private GeoCoordinate _coord;

        public string GetOAuth()
        {
            return _oauth;
        }

        public string GetVotingCode()
        {
            return _votingCode;
        }

        public string GetPostcode()
        {
            return _postCode;
        }

        public GeoCoordinate GetCoord()
        {
            return _coord;
        }

    }
}
