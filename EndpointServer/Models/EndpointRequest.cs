using System;
namespace EndpointServer.Models
{
    public class EndpointRequest
    {
        private RequestType _type;
        private string _oauth;
        private string _postcode;
        private string _votingCode;
        private GeoCoordinate _geo;

        private EndpointResponse _response;

        //Getters
        public RequestType GetRequestType()
        {
            return _type;
        }

        public string GetOAuth()
        {
            return _oauth;
        }

        public string GetPostCode()
        {
            return _postcode;
        }

        public string GetVotingCode()
        {
            return _votingCode;
        }

        public GeoCoordinate GetGeoCoordinate()
        {
            return _geo;
        }

        public EndpointResponse GetResponseOrBlock()
        {
            while (_response == null) {}
            //wait

            return _response;
        }

        //Setters
        public void SetResponse(EndpointResponse response)
        {
            _response = response;
        }

    }
}
