using eVoting.Interfaces;
using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Services
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException() : base() 
        {
        } 
    }

    public class VotingServerService : IVotingServerService
    {
        private string _localServerEndpoint;
        private bool _loggedIn = false;

        private IEndpointServerService _coordServerService;

        public VotingServerService(IEndpointServerService coordServerService)
        {
            _coordServerService = coordServerService;
        }

        public void SetLocalServerEndpoint(string endpoint)
        {
            _localServerEndpoint = endpoint;
        }

        public void SetLoggedIn(bool loggedIn)
        {
            _loggedIn = loggedIn;
        }


        public List<Election> GetCurrentElections()
        {
            if (!VerifyRequest())
                throw new NotAuthenticatedException();

            //using the endpoint, get current elections from server for this region
            return new List<Election>();
        }


        #region Private Helper Functions

        private bool VerifyRequest()
        {
            if (!_loggedIn)
                return false;

            if (_localServerEndpoint == null)
                return false;

            if (_localServerEndpoint == "")
                return false;

            return true;
        }

        #endregion
    }
}
