using System;
namespace EndpointServer.Models
{
    public class EndpointRequest
    {
        private RequestType _type;
        private string _oauth;
        private string _json;
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

        public string GetJson()
        {
            return _json;
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
