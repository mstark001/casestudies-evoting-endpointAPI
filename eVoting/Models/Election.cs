using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public class Election
    {
        private string _electionId;
        private string _electionName;
        private List<Party> _parties;
        private Country _country;
        private CountingType _voteType;

        private ElectionType _electionType;
        
        public ElectionType GetElectionType()
        {
            return _electionType;
        }

        public string GetElectionId()
        {
            return _electionId;
        }

 
    }
}
