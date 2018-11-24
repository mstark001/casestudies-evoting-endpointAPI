using eVoting.Interfaces;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Services
{
    public class EndpointServerService : IEndpointServerService
    {
        private static string BASESERVERADDRESS = "www.someaddress.com";

        private IGeoLocationService _geoLocationService;

        public EndpointServerService(IGeoLocationService geoLocation)
        {
            _geoLocationService = geoLocation;
        }

        public string GetLocalEndpoint(string postcode, string votingCode)
        {
            var oauth = GetOuathToken(postcode, votingCode);
            var location = _geoLocationService.GetCurrentLocation();


            //use oauth and location to validate the person's location 

            if (ValidatePersonIsInCorrectConsituency(oauth, location, postcode, votingCode))
            {
                //after all this, call to the server now to find out the endpoint for a given location
                return GetLocalEndpointFromServer(oauth, location, postcode, votingCode);
            }

            return null;
        }


        #region Private Helper Functions 

        private string GetLocalEndpointFromServer(string oauth, GeoCoordinate location, string postcode, string votingCode)
        {
            //call to server with this information
            return "www.someuniqueaddress.com";
        }

        private bool ValidatePersonIsInCorrectConsituency(string oauth, GeoCoordinate location, string postcode, string votingCode)
        {
            //This will call to the server to ensure that this location is in this postcode, and that
            //this individual person is actually allowed to vote in this consintuency 
            return true;
        }

        private string GetOuathToken(string postcode, string votingCode)
        {
            //use postcode and votingCode to get an oauth token
            return "some token";
        }


        private string GetBaseServerName()
        {
            return BASESERVERADDRESS;
        }


        #endregion

    }
}
