using eVoting.Interfaces;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Services
{
    public class CoordinateServerService : ICoordinateServerService
    {
        private static string BASESERVERADDRESS = "www.someaddress.com";

        private string _userId;
        private string _userSecret;

        private string _oAuthToken;

        public CoordinateServerService(string userId, string userSecret)
        {
            SetUserId(userId);
            SetUserSecret(userSecret);

            RequestOuathToken();
        }

        public string GetLocalRegionEndpointFrom(GeoCoordinate coord)
        {
            //use oauth and geo coordinate to validate the person's location 
            return "www.evoting.com?region=someregionid";
        }


        #region Private Helper Functions 

        private void RequestOuathToken()
        {
            //use user identifcation to get an oauth token
            SetOAuthToken("some token");
        }

        private void SetUserId(string userId)
        {
            _userId = userId;
        }

        private void SetOAuthToken(string token)
        {
            _oAuthToken = token;
        }

        private void SetUserSecret(string userSecret)
        {
            _userSecret = userSecret;
        }


        private string GetBaseServerName()
        {
            return BASESERVERADDRESS;
        }


        #endregion

    }
}
