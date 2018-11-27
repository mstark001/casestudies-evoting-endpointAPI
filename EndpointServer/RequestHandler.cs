using System;
using System.Collections.Generic;
using EndpointServer.Models;
using EndpointServer.Models.RequestObjects;
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
                        var endpontReq = JSONSeralize.DeserializeGetEndpointRequest(current.GetJson());
                        resp = GetEndpoint(endpontReq);
                        break;

                    case RequestType.GetStandardOAuth:
                        var standardOauthRequest = JSONSeralize.DeserializeStandardOAuthRequest(current.GetJson());
                        resp = GetStandardOAuth(standardOauthRequest);
                        break;

                    case RequestType.ValidateConsistuency:
                        var validateConsistuency = JSONSeralize.DeserializeValidateConsistuency(current.GetJson());
                        resp = ValidateConsistuency(validateConsistuency);
                        break;
                    
                    case RequestType.GetSignupOAuth:
                        var signUpOathRequest = JSONSeralize.DeserializeSignUpOAthRequest(current.GetJson());
                        resp = GetSignupOAuth(signUpOathRequest);
                        break;

                    case RequestType.RegisterNewUser:
                        var registerNewuserRequest = JSONSeralize.DeserializeNewUser(current.GetJson());
                        resp = RegisterNewUser(registerNewuserRequest);
                        break;

                    case RequestType.RegisterAnnoymousUser:
                        var registerAnnoymousUserRequest = JSONSeralize.DeserializeAnnoymousUser(current.GetJson());
                        resp = RegisterAnnoymousUser(registerAnnoymousUserRequest);
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

        private static string GetEndpoint(GetEndpointRequest req)
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


        private static string GetStandardOAuth(StandardOAuthRequest req)
        {
            string postcode = req.GetPostcode();
            string votingCode = req.GetVotingcode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            string oauth = oauthService.GetOAuthCode(votingCode, postcode);
            return oauth;
        }


        private static string GetSignupOAuth(SignupOAuthRequest req)
        {
            string firstName = req.GetFirstName();
            string lastName = req.GetLastName();
            string postCode = req.GetPostcode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            string oauth = oauthService.GetSignupOAuthCode(firstName, lastName, postCode);
            return oauth;
        }

        private static string RegisterNewUser(RegisterNewUserRequest req)
        {
            string oauth = req.GetOAuth();
            string first = req.GetFirstName();
            string last = req.GetLastName();
            string postcode = req.GetPostcode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            if (!oauthService.VerifySignupOAuthCode(oauth, first, last, postcode))
                return "ERROR";

            User user = new User();
            user.SetAddress(req.GetAddress());
            user.SetCountry(req.GetCountry());
            user.SetDoB(req.GetDoB());
            user.SetFirstName(first);
            user.SetLastName(last);
            user.SetMiddleName(req.GetMiddleName());
            user.SetNationality(req.GetNationality());
            user.SetOAuthCoode(req.GetOAuth());
            user.SetPostCode(postcode);

            var registerUserService = new RegisterUserService();
            registerUserService.RegisterNewUser(user);

            return "done";
        }

        private static string RegisterAnnoymousUser(RegisterAnnoymousUserRequest req)
        {
            string oauth = req.GetOAuth();
            string first = req.GetGeneratedFirstName();
            string last = req.GetGeneratedLastName();
            string postcode = req.GetGeneratedPostcode();

            OAuthDatabaseService oauthService = new OAuthDatabaseService();
            if (!oauthService.VerifySignupOAuthCode(oauth, first, last, postcode))
                return "ERROR";

            var registerUserService = new RegisterUserService();
            registerUserService.RegisterNewAnnoymousUser(req.GetFormData(), req.GetAdditionalDetails());

            return "done";
        }

        private static string ValidateConsistuency(ValidateConsistunecyRequst req)
        {
            string oauth = req.GetOAuth();
            string votingCode = req.GetVotingCode();
            OAuthDatabaseService oauthService = new OAuthDatabaseService();

            if (!oauthService.VerifyOAuthCode(oauth, votingCode))
                return "ERROR";

            //Validated
            var postcode = req.GetPostcode();
            var coord = req.GetCoord();

            ConsistuencyDatabaseService consistuencyService = new ConsistuencyDatabaseService();
            bool result = consistuencyService.ValidateCredentails(postcode, coord, votingCode);

            return result.ToString();
        }

        #endregion
    }
}
