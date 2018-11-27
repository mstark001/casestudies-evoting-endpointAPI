using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public class Party
    {
        private string _partyName;
        private string _partyId;
        private Candidate _candidate;
        private byte[] _partyLogo;

        //Getters
        public string GetPartyName()
        {
            return _partyName;
        }

        public string GetPartyId()
        {
            return _partyId;
        }

        public Candidate GetCandidate()
        {
            return _candidate;
        }

        public byte[] GetpartyLogo()
        {
            return _partyLogo;
        }

        //Setters
        public void SetPartyName(string partyName)
        {
            _partyName = partyName;
        }

        public void SetPartyId(string partyId)
        {
            _partyId = partyId;
        }

        public void SetCandidate(Candidate candidate)
        {
            _candidate = candidate;
        }

        public void SetPartyLogo(byte[] logo)
        {
            _partyLogo = logo;
        }


    }
}
