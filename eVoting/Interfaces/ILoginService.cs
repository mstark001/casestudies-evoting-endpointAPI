using System;
namespace eVoting.Interfaces
{
    public interface ILoginService
    {
        bool Login(string postcode, string votingCode);
    }
}
