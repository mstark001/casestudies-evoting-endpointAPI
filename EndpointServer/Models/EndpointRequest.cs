using System;
namespace EndpointServer.Models
{
    public class EndpointRequest
    {
        private RequestType _type;
        private string _oauth;
        private GeoCoordinate _geo;

        private string _votingCode;

        private string _firstName;
        private string _lastName;
        private string _postcode;



        private byte[] _anonData;
        private string _anonAdditionalDetails;


        private string _jsonResponse;

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

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public GeoCoordinate GetGeoCoordinate()
        {
            return _geo;
        }

        public string GetResponseOrBlock()
        {
            while (_jsonResponse == null) {}
            //wait

            return _jsonResponse;
        }

        //Setters
        public void SetResponse(string response)
        {
            _jsonResponse = response;
        }

    }
}
