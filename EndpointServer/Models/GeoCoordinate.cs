using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndpointServer.Models
{
    public class GeoCoordinate
    {
        private double _lat = 0.0;
        private double _long = 0.0;

        public GeoCoordinate()
        {
        }

        public GeoCoordinate(double lat, double longi)
        {
            SetLatitude(lat);
            SetLongitude(longi);
        }

        public double GetLatitude()
        {
            return _lat;
        }

        public double GetLongitude()
        {
            return _lat;
        }

        public void SetLatitude(double lat)
        {
            _lat = lat;
        }

        public void SetLongitude(double longi)
        {
            _long = longi;
        }

    }
}
