using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public class UpdateParticipant : UpdateParticipantService
    {
        public async Task<IEnumerable<Participant>> Refresh()
        {
            //Create a database connection
            MySqlConnection connection = null;
            connection = new MySqlConnection(Constants.CONNECTION_STRING);
            connection.Open();

            List<Affiliation> affiliations = new List<Affiliation>();

            string getAffiliationsQuery = "SELECT * FROM " + Constants.AFFILIATION + " WHERE active = 1;";
            var cmd = new MySqlCommand(getAffiliationsQuery, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Affiliation temp = new Affiliation();
                temp.Id = reader.GetInt32(0);
                temp.Name = reader.GetString(1);
                temp.Abbreviation = reader.GetString(2);
                affiliations.Add(temp);
            }

            string getParticipantsQuery = "SELECT * FROM " + Constants.PARTICIPANT + " WHERE active = 1;";
            var cmd = new MySqlCommand(getParticipantsQuery, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Participant temp = new Participant();
                temp.Id = reader.GetInt32(0);
                temp.FirstName = reader.GetString(1);
                temp.LastName = reader.GetString(2);
                int affId = reader.GetInt32(3);

                temp.Gender = reader.GetString(4);

            }
        }

        public async Task<string> Save(Participant updatedParticipant)
        {
            throw new NotImplementedException();
        }
    }
}
