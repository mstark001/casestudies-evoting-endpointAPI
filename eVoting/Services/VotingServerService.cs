using eVoting.Interfaces;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Services
{
    public class VotingServerService : IVotingServerService
    {
        private string _localServerEndpoint;
        private ICoordinateServerService _coordServerService;

        public VotingServerService(GeoCoordinate coord, ICoordinateServerService coordServerService)
        {
            _coordServerService = coordServerService;

            var endpoint = _coordServerService.GetLocalRegionEndpointFrom(coord);
            SetLocalEndpoint(endpoint);
        }

        public string GetLocalServerEndpoint()
        {
            return _localServerEndpoint;
        }


        public List<string> GetCurrentElections()
        {
            //using the endpoint, get current elections from server for this region
            return new List<string>();
        }


        #region Private Helper Functions

        private string GetLocalEndpointFromCoord(GeoCoordinate coord)
        {
            //Connect to some server somewhere, using cord
            return "Some endpoint";
        }

        private void SetLocalEndpoint(string endpoint)
        {
            _localServerEndpoint = endpoint;
        }


        #endregion
    }
}
