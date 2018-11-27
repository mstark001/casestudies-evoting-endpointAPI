using eVoting.Exceptions;
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
        private string _oAuthToken;

        private IEndpointServerService _coordServerService;
        private IValueStoreService _valueStoreService;

        public VotingServerService(IEndpointServerService coordServerService, IValueStoreService valueStoreService)
        {
            _coordServerService = coordServerService;
            _valueStoreService = valueStoreService;
        }

        public void Authenticate(string postcode, string votingCode, string endpoint)
        {
            if (!SetupOuathToken(postcode, votingCode))         
                throw new NotAuthenticatedException();

            SetLocalServerEndpoint(endpoint);
            _valueStoreService.SetLoggedIn(true);
            _valueStoreService.SetVotingCode(votingCode);
        }

        public void Dethenticate()
        {
            _oAuthToken = null;
            SetLocalServerEndpoint(null);

            _valueStoreService.SetLoggedIn(false);
            _valueStoreService.SetVotingCode(null);
        }


        public List<Election> GetCurrentElections()
        {
            if (!VerifyRequest())
                throw new NotAuthenticatedException();

            //using the endpoint, get current elections from server for this region
            return new List<Election>();
        }


        #region Private Helper Functions

        private void SetLocalServerEndpoint(string endpoint)
        {
            _localServerEndpoint = endpoint;
        }

        private bool SetupOuathToken(string postcode, string votingCode)
        {
            //use postcode and votingCode to get an oauth token
            _oAuthToken = "some token";
            return true;
        }

        private bool VerifyRequest()
        {
            if (!_valueStoreService.GetLoggedIn())
                return false;

            if (_localServerEndpoint == null)
                return false;

            if (_localServerEndpoint == "")
                return false;

            if (_oAuthToken == null)
                return false;

            if (_oAuthToken == "")
                return false;

            return true;
        }

        #endregion
    }
}
