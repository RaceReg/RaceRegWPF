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
        public Dictionary<string, string> errors = new Dictionary<string, string>();

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;

        public enum GenderType { Male, Female, Other };
        public IEnumerable<GenderType> GenderTypes
        {
            get
            {
                return Enum.GetValues(typeof(GenderType)).Cast<GenderType>().ToList<GenderType>();
            }
        }

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

        //VALIDATION
        private bool isValid;
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
                RaisePropertyChanged(nameof(IsValid));
            }
        }

        private void setValid()
        {
            bool fN = ValidateFirstName();
            bool lN = ValidateLastName();
            bool aG = ValidateBirthDate();
            bool gD = ValidateGender();


            IsValid = fN && lN && aG && gD;
        }

        private bool ValidateFirstName()
        {
            if (FirstName == null || FirstName.Equals(String.Empty) || FirstName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(FirstName)] = "First name must contain no spaces, and cannot be empty.";
                return false;
            }
            else
            {
                errors[nameof(FirstName)] = null;
                return true;
            }
        }

        private bool ValidateLastName()
        {
            if (LastName == null || LastName.Equals(String.Empty) || LastName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(LastName)] = "Last name must contain no spaces, and cannot be empty.";
                return false;
            }
            else
            {
                errors[nameof(LastName)] = null;
                return true;
            }
        }

        private bool ValidateBirthDate()
        {
            //if (Age < 1 || Age > 150)
            //{
            //    errors[nameof(Age)] = "Age must be between 1 and 150.";
            //    return false;
            //}
            //else
            //{
            //    errors[nameof(Age)] = null;
            //    return true;
            //}

            return true;
        }

        private bool ValidateGender()
        {
            if (!Enum.IsDefined(typeof(GenderType), Gender))
            {
                errors[nameof(Gender)] = "Gender must be Male, Female or Other.";
                return false;
            }
            else
            {
                errors[nameof(Gender)] = null;
                return true;
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
