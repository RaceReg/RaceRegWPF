using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RaceReg.Helpers;
using RaceReg.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RaceReg.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IUpdateParticipantService _updateParticipantService;
        private IDialogService _dialogService;

        public ObservableCollection<Participant> Participants
        {
            get;
            private set;
        }

        private Participant _selectedParticipant;
        public Participant SelectedParticipant
        {
            get
            {
                return _selectedParticipant;
            }
            set
            {
                if (_selectedParticipant == value)
                {
                    return;
                }

                _selectedParticipant = value;
                RaisePropertyChanged("SelectedParticipant");
            }
        }

        private RelayCommand _refreshParticipantCommand;
        public RelayCommand RefreshParticipantCommand
        {
            get
            {
                return _refreshParticipantCommand ?? (_refreshParticipantCommand = new RelayCommand(
                    async () =>
                    {
                        await Refresh();
                    }
                    ));
            }
        }

        private async Task Refresh()
        {
            Participants.Clear();

            var participants = await _updateParticipantService.Refresh();

            foreach(var participant in participants)
            {
                Participants.Add(participant);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IUpdateParticipantService updateParticipantService, 
            IDialogService dialogService)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _updateParticipantService = updateParticipantService;
            _dialogService = dialogService;

            Participants = new ObservableCollection<Participant>( _updateParticipantService.Refresh().Result);
        }

        //Default constructor
        public MainViewModel() : this(new UpdateParticipant(), new DialogService()) { }
    }
}