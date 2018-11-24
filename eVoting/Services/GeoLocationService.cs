using System;
using eVoting.Interfaces;
using eVoting.Models;

namespace eVoting.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        public GeoLocationService()
        {
        }

        public GeoCoordinate GetCurrentLocation()
        {
            //Use something to get current location, likely GPS module or IP address tracking.

            var geo = new GeoCoordinate();
            geo.SetLatitude(53.3797045);
            geo.SetLongitude(-1.4655254);

            return geo;
        }
    }
}
