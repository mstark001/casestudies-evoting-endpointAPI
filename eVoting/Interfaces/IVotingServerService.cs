using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVoting.Models;

namespace eVoting.Interfaces
{
    public interface IVotingServerService
    {
        void SetLocalServerEndpoint(string endpoint);
        void SetLoggedIn(bool loggedIn);
        List<Election> GetCurrentElections();
            
    }
}
