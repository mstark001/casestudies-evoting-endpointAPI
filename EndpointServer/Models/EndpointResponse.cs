using System;
namespace EndpointServer.Models
{
    public class EndpointResponse
    {
        private string _response;

        public EndpointResponse(string response)
        {
            _response = response;
        }

        public string GetResponse()
        {
            return _response;
        }

    }
}
