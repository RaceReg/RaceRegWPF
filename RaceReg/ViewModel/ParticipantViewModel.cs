using RaceReg.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.ViewModel
{
    class ParticipantViewModel
    {
        public Participant participant;
        public ObservableCollection<Affiliation> affiliations;

        public ParticipantViewModel(MainViewModel mainViewModel)
        {
            affiliations = mainViewModel.Affiliations;
        }
    }
}
