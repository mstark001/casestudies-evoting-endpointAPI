
using System;
using EndpointServer.Models;

namespace EndpointServer.Interfaces
{
    public interface IDatabaseService
    {
        void Connect();
        void Discoonect();
        User GetUserFromUserCode(string votingCode);
        string GetEndpointFromUserCode(string votingCode);
        string GetOAuthCodeFromUserCode(string votingCode);
        string GetConsistuencyFromUserCode(string votingCode);
        void RegisterOAuthCodeAgainstUserCode(string oauth, string userCode);
    }
}
