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
        void Authenticate(string postcode, string votingCode, string endpoint);
        List<Election> GetCurrentElections();
        void Dethenticate();
        bool SubmitVote(Vote vote);
    }
}
