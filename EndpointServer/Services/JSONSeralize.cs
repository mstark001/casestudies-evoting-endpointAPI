using System;
using EndpointServer.Models;
using EndpointServer.Models.RequestObjects;

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



        //Should use termplating for this but canb't because it's a diagram model!
        public static GetEndpointRequest DeserializeGetEndpointRequest(string json)
        {
            //do a thing to deseralize the json
            return new GetEndpointRequest();
        }

        public static RegisterAnnoymousUserRequest DeserializeAnnoymousUser(string json)
        {
            //do a thing to deseralize the json
            return new RegisterAnnoymousUserRequest();
        }

        public static RegisterNewUserRequest DeserializeNewUser(string json)
        {
            //do a thing to deseralize the json
            return new RegisterNewUserRequest();
        }

        public static SignupOAuthRequest DeserializeSignUpOAthRequest(string json)
        {
            //do a thing to deseralize the json
            return new SignupOAuthRequest();
        }

        public static StandardOAuthRequest DeserializeStandardOAuthRequest(string json)
        {
            //do a thing to deseralize the json
            return new StandardOAuthRequest();
        }

        public static ValidateConsistunecyRequst DeserializeValidateConsistuency(string json)
        {
            //do a thing to deseralize the json
            return new ValidateConsistunecyRequst();
        }
    }
}
