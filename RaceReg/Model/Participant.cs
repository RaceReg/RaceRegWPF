using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public class Participant
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Affiliation _affiliation;
        private string _gender;
        private DateTime _birthDate;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Affiliation Affiliation { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
