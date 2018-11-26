using eVoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Interfaces
{
    public interface IEndpointServerService
    {
        string GetLocalEndpoint(string postcode, string votingCode);
        bool RegisterNewUser(RegisterUser user);
        bool RegisterAnnoymousUser(AnnoymousRegisterUser user);
    }
}
