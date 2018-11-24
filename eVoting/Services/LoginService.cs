using System;
using eVoting.Interfaces;

namespace eVoting.Services
{
    public class LoginService : ILoginService
    {
        IEndpointServerService _endpointServerService;
        IVotingServerService _votingServerService;

        public LoginService(IEndpointServerService endpointServerService, IVotingServerService votingServerService)
        {
            _endpointServerService = endpointServerService;
            _votingServerService = votingServerService;
        }

        public bool Login(string postcode, string votingCode)
        {
            var endpoint = _endpointServerService.GetLocalEndpoint(postcode, votingCode);
            _votingServerService.Authenticate(postcode, votingCode, endpoint);
            return true;
        }

        
    }
}
