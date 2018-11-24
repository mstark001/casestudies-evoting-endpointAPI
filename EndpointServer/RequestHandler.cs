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
      
                EndpointResponse resp = null;
                switch (current.GetRequestType())
                {
                    case RequestType.GetEndpoint:
                        resp = GetEndpoint(current);
                        break;

                    case RequestType.GetOAuth:
                        resp = GetOAuth(current);
                        break;

                    case RequestType.ValidateConsistuency:
                        resp = ValidateConsistuency(current);
                        break;

                    default:
                        break;
                }
                current.SetResponse(resp);

            }
        }

        public static EndpointResponse ReceiveRequest(EndpointRequest req)
        {
            _currentRequests.Enqueue(req);
            var response = req.GetResponseOrBlock();
            return response;
        }

        #region Private Helper Functions

        private static EndpointResponse GetEndpoint(EndpointRequest req)
        {
            string oauth = req.GetOAuth();
            string votingCode = req.GetVotingCode();
            OAuthDatabaseService oauthService = new OAuthDatabaseService();

            if (!oauthService.VerifyOAuthCode(oauth, votingCode))
                return new EndpointResponse("ERROR");

            //Validated
            EndpointDatabaseService endpointService = new EndpointDatabaseService();
            string endpoint = endpointService.GetEndpointFromUsercode(votingCode);
                      
            return new EndpointResponse(endpoint); 
        }


        private static EndpointResponse GetOAuth(EndpointRequest req)
        {
            string postcode = req.GetPostCode();
            string votingCode = req.GetVotingCode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            string oauth = oauthService.GetOAuthCode(votingCode, postcode);
            return new EndpointResponse(oauth);
        }


        private static EndpointResponse ValidateConsistuency(EndpointRequest req)
        {
            string oauth = req.GetOAuth();
            string votingCode = req.GetVotingCode();
            OAuthDatabaseService oauthService = new OAuthDatabaseService();

            if (!oauthService.VerifyOAuthCode(oauth, votingCode))
                return new EndpointResponse("ERROR");

            //Validated
            var postcode = req.GetPostCode();
            var coord = req.GetGeoCoordinate();

            ConsistuencyDatabaseService consistuencyService = new ConsistuencyDatabaseService();
            bool result = consistuencyService.ValidateCredentails(postcode, coord, votingCode);

            return new EndpointResponse(result.ToString());
        }

        #endregion
    }
}
