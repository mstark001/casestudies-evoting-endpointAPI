using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Interfaces
{
    public interface ICoordinateServerService
    {
        string GetLocalRegionEndpointFrom(GeoCoordinate coord);


    }
}
