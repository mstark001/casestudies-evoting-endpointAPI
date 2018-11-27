using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public class Vote
    {
        private string _electionId;
        private ElectionType _type;
        private string _votingCode;
        private string _oauth;
        private List<Party> _partiesVotedFor = new List<Party>();

        public void SetElectionId(string electionId)
        {
            _electionId = electionId;
        }

        public void SetElectionType(ElectionType type)
        {
            _type = type;
        }

        public void SetVotingCode(string code)
        {
            _votingCode = code;
        }

        public void SetOAuth(string oauth)
        {
            _oauth = oauth;
        }

        public void SetPartiesVotedFor(List<Party> parties)
        {
            _partiesVotedFor = parties;
        }
    }
}
