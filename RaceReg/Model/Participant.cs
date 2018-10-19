using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public class Participant : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Affiliation _affiliation;
        private string _gender;
        private DateTime _birthDate;

        public int Id {
            get
            {
                return _id;
            }
            set
            {
                if(_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.Equals(_firstName, value))
                {
                    return;
                }

                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.Equals(_lastName, value))
                {
                    return;
                }

                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public Affiliation Affiliation
        {
            get
            {
                return _affiliation;
            }
            set
            {
                if (_affiliation == value)
                {
                    return;
                }

                _affiliation = value;
                RaisePropertyChanged("Affiliation");
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (string.Equals(_gender, value))
                {
                    return;
                }

                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (_birthDate == value)
                {
                    return;
                }

                _birthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
