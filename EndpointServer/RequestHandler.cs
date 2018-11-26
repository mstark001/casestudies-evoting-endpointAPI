using System;
using System.Collections.Generic;
using EndpointServer.Models;
using EndpointServer.Services;

namespace EndpointServer
{
    class RequestHandler
    {
        //Uses a queue (FIFO) system, NOT A STACK (LIFO) --- IMPORTANT
        private static EndpointRequestQueue _currentRequests = new EndpointRequestQueue();

        public static void Main(string[] args)
        {
            //We should give the user ther option the chance to
            //to close the server but for the sake of this, this is fine for my modelling
            while (true)
            {
                var current = _currentRequests.DequeueOrBlock();
      
                string resp = null;
                switch (current.GetRequestType())
                {
                    case RequestType.GetEndpoint:
                        resp = GetEndpoint(current);
                        break;

                    case RequestType.GetStandardOAuth:
                        resp = GetStandardOAuth(current);
                        break;

                    case RequestType.ValidateConsistuency:
                        resp = ValidateConsistuency(current);
                        break;
                    
                    case RequestType.GetSignupOAuth:
                        resp = GetSignupOAuth(current);
                        break;

                    case RequestType.RegisterNewUser:
                        resp = RegisterNewUser(current);
                        break;

                    case RequestType.RegisterAnnoymousUser:
                        resp = RegisterAnnoymousUser(current);
                        break;

                    default:
                        break;
                }
                current.SetResponse(resp);

            }
        }

        public static string ReceiveRequest(string receivedJson)
        {
            var req = JSONSeralize.Deserialize(receivedJson);

            _currentRequests.Enqueue(req);
            var response = req.GetResponseOrBlock();
            return response;
        }

        #region Private Helper Functions

        private static string GetEndpoint(EndpointRequest req)
        {
            string oauth = req.GetOAuth();
            string votingCode = req.GetVotingCode();
            OAuthDatabaseService oauthService = new OAuthDatabaseService();

            if (!oauthService.VerifyOAuthCode(oauth, votingCode))
                return "ERROR";

            //Validated
            EndpointDatabaseService endpointService = new EndpointDatabaseService();
            string endpoint = endpointService.GetEndpointFromUsercode(votingCode);
                      
            return endpoint; 
        }


        private static string GetStandardOAuth(EndpointRequest req)
        {
            string postcode = req.GetPostCode();
            string votingCode = req.GetVotingCode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            string oauth = oauthService.GetOAuthCode(votingCode, postcode);
            return oauth;
        }


        private static string GetSignupOAuth(EndpointRequest req)
        {
            string firstName = req.GetFirstName();
            string lastName = req.GetLastName();
            string postCode = req.GetPostCode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            string oauth = oauthService.GetSignupOAuthCode(firstName, lastName, postcode);
            return oauth;
        }

        private static string RegisterNewUser(EndpointRequest req)
        {

        }

        private static string RegisterAnnoymousUser(EndpointRequest req)
        {

        }

        private static string ValidateConsistuency(EndpointRequest req)
        {
            string oauth = req.GetOAuth();
            string votingCode = req.GetVotingCode();
            OAuthDatabaseService oauthService = new OAuthDatabaseService();

            if (!oauthService.VerifyOAuthCode(oauth, votingCode))
                return "ERROR";

            //Validated
            var postcode = req.GetPostCode();
            var coord = req.GetGeoCoordinate();

            ConsistuencyDatabaseService consistuencyService = new ConsistuencyDatabaseService();
            bool result = consistuencyService.ValidateCredentails(postcode, coord, votingCode);

            return result.ToString();
        }

        #endregion
    }
}
