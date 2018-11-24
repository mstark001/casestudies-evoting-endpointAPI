using System;
using eVoting.Models;

namespace eVoting.Interfaces
{
    public interface IGeoLocationService
    {
        GeoCoordinate GetCurrentLocation();
    }
}
