using System;
using EndpointServer.Models;

namespace EndpointServer.Services
{
    public static class JSONSeralize
    {
        public static EndpointRequest Deserialize(string json)
        {
            //do a thing to deseralize the json
            return new EndpointRequest();
        }

        public static string Serialize(EndpointResponse resp)
        {
            //do a thing to serizlise
            return "";
        }
    }
}
