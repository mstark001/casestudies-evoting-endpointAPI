using eVoting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Models
{
    public abstract class BaseVotingView : BaseView
    {
        private IVotingServerService _votingServerService;
        private IValueStoreService _valueStoreService;

        private Election _election;
        private List<Party> _partiesSelected;

        public BaseVotingView(IDependencyService dependencyService) : base(dependencyService)
        {
            _valueStoreService = dependencyService.Get<IValueStoreService>();
            _votingServerService = dependencyService.Get<IVotingServerService>();
        }

        public override void Setup()
        {
            _election = _valueStoreService.GetSelectedElection();
        }

        public override void Teardown()
        {
            _election = null;
            _valueStoreService.SetSelectedElection(null);
        }

        public void ReturnToVotingMenu()
        {
            App.NavigateToView(ViewType.VotingView);
        }

        public void SpoilBallot()
        {
            var vote = new Vote();
            vote.SetElectionId(_election.GetElectionId());
            vote.SetElectionType(_election.GetElectionType());

            var spoilParty = new Party();
            spoilParty.SetPartyName("SPOILT BALLOT");

            vote.SetPartiesVotedFor(new List<Party>() { spoilParty } );
            vote.SetVotingCode(_valueStoreService.GetVotingCode());

            _votingServerService.SubmitVote(vote);

            ReturnToVotingMenu();
        }

        public void SubmitVote()
        {
            var vote = new Vote();
            vote.SetElectionId(_election.GetElectionId());
            vote.SetElectionType(_election.GetElectionType());
            vote.SetPartiesVotedFor(_partiesSelected);
            vote.SetVotingCode(_valueStoreService.GetVotingCode());

            _votingServerService.SubmitVote(vote);

            ReturnToVotingMenu();
        }

        public List<Party> GetPartiesSelected()
        {
            return _partiesSelected;
        }

        public void SetPartiesSelected(List<Party> parties)
        {
            _partiesSelected = parties;
        }

        public abstract void SelectParty(Party party);

        public abstract void DeselectParty(Party party);


    }
}
