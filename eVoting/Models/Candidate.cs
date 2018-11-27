using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public class Candidate
    {
        private string _candidateName;
        private string _candidateAddress;
        private byte[] _candidatePicture;
        private string _partyId;

        //Getters
        public string GetCandidateName()
        {
            return _candidateName;
        }

        public string GetCandidateAddress()
        {
            return _candidateAddress;
        }

        public byte[] GetCandidatePicture()
        {
            return _candidatePicture;
        }

        public string GetPartyId()
        {
            return _partyId;
        }

        //Setters
        public void SetCandidateName(string name)
        {
            _candidateName = name;
        }

        public void SetCandidateAddress(string add)
        {
            _candidateAddress = add;
        }

        public void SetCandidatePicture(byte[] picture)
        {
            _candidatePicture = picture;
        }

        public void SetPartyId(string id)
        {
            _partyId = id;
        }
    }
}
