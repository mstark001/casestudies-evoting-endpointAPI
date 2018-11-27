
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
        void RegisterOAuthCodeAgainstSignUp(string oauth, string firstName, string lastname, string postCode);
        void RecordNewUser(User user);
        void RecordNewAnnoymousRequestUser(byte[] data, string additionalDetails);
        string GetRegisterRequestFromOAuth(string ouath);
        string GetConsistuencyFromPostCode(string postcode);
    }
}
