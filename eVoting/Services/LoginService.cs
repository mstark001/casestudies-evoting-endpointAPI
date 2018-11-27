using System;
using eVoting.Interfaces;
using eVoting.Models;

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

        public bool Logout()
        {
            _votingServerService.Dethenticate();
            return true;
        }

        public bool RegisterNewUser(RegisterUser user)
        {
            return _endpointServerService.RegisterNewUser(user);
        }

        public bool RegisterAnnoymousUser(AnnoymousRegisterUser user)
        {
            return _endpointServerService.RegisterAnnoymousUser(user);
        }

        
    }
}
