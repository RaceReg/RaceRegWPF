using RaceReg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestDatabase : IRaceRegDB
    {
        public TestDatabase()
        {

        }

        public async Task<IEnumerable<Affiliation>> RefreshAffiliations()
        {
            Random rnd = new Random();

            List<Affiliation> affiliations = new List<Affiliation>();

            Affiliation temp = new Affiliation();

            for(int i = 0; i < 6; i++)
            {
                temp.Abbreviation = 'a' +  'b' + 'c' + "";
            }

            return affiliations;
        }

        public async Task<IEnumerable<Participant>> RefreshParticipants()
        {
            throw new NotImplementedException();
            //temp.FirstName = rnd.Next(65, 122) + rnd.Next(65, 122) + rnd.Next(65, 122) + "";
            //temp.LastName = rnd.Next(65, 122) + rnd.Next(65, 122) + rnd.Next(65, 122) + "";
            //temp.Gender = (Participant.GenderType)rnd.Next(1, 3);
            //temp.BirthDate = DateTime.Today.AddDays(rnd.Next(1, 10));
        }

        public Task<string> Save(Participant updatedParticipant)
        {
            throw new NotImplementedException();
        }
    }
}
