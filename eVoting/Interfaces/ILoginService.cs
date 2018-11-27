using System;
using eVoting.Models;

namespace eVoting.Interfaces
{
    public interface ILoginService
    {
        bool Login(string postcode, string votingCode);
        bool RegisterNewUser(RegisterUser user);
        bool RegisterAnnoymousUser(AnnoymousRegisterUser user);
        bool Logout();
    }
}
