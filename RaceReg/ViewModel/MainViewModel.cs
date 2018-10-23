using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RaceReg.Helpers;
using RaceReg.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private IRaceRegDB _database;
        private IDialogService _dialogService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IRaceRegDB RaceRegDB,
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

            ChildViewModels = new ObservableCollection<ChildControl>();

            _database = RaceRegDB;
            _dialogService = dialogService;

            QueryDatabase();
        }

        public async void QueryDatabase()
        {
            var getAffiliations = await _database.RefreshAffiliations().ConfigureAwait(true);
            Affiliations = new ObservableCollection<Affiliation>(getAffiliations);

            var getParticipants = await _database.RefreshParticipants().ConfigureAwait(true);
            Participants = new ObservableCollection<Participant>(getParticipants);
        }

        //Default constructor
        public MainViewModel() : this(new Database(), new DialogService()) { }

        private ObservableCollection<ChildControl> childViewModels;
        public ObservableCollection<ChildControl> ChildViewModels
        {
            get
            {
                return childViewModels;
            }
            set
            {
                Set(ref childViewModels, value);
            }
        }

        private ChildControl selectedChildViewModel;
        public ChildControl SelectedChildViewModel
        {
            get
            {
                return selectedChildViewModel;
            }
            set
            {
                Set(ref selectedChildViewModel, value);
            }
        }

        private RelayCommand addParticipantView;
        public RelayCommand AddParticipantView => addParticipantView ?? (addParticipantView = new RelayCommand(
            () =>
            {
                ParticipantViewModel participantEditorViewModel = new ParticipantViewModel();
                participantEditorViewModel.Affiliations = this.Affiliations;
                ChildViewModels.Add(new ChildControl("Participant Editor", participantEditorViewModel));
                SelectedChildViewModel = ChildViewModels.Last();
            }
            ));

        public ObservableCollection<Affiliation> Affiliations
        {
            get;
            set;
        }


        public ObservableCollection<Participant> Participants
        {
            get;
            set;
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
     

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if(EqualityComparer<T>.Default.Equals(field, value))
        //    {
        //        return false;
        //    }
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}