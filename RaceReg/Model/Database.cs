using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public class Database : IRaceRegDB
    {
        public async Task<IEnumerable<Participant>> RefreshParticipants(ObservableCollection<Affiliation> affiliations)
        {
            //var getAffiliations = RefreshAffiliations() as Task<IEnumerable<Affiliation>>;
            //await Task.WhenAll(getAffiliations);
            //IEnumerable<Affiliation> affiliations = new ObservableCollection<Affiliation>(getAffiliations.Result);

            List<Participant> participants = new List<Participant>();
            string getParticipantsQuery = "SELECT * FROM " + Constants.PARTICIPANT + " WHERE active = 1;";

            using (var connection = new MySqlConnection(Constants.CONNECTION_STRING))
            {
                await connection.OpenAsync();
                using (var cmd = new MySqlCommand(getParticipantsQuery, connection))
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        Participant temp = new Participant();
                        temp.Id = reader.GetInt32(0);
                        temp.FirstName = reader.GetString(1);
                        temp.LastName = reader.GetString(2);
                        int affId = reader.GetInt32(3);
                        foreach (Affiliation tempAffiliation in affiliations)
                        {
                            if (tempAffiliation.Id == affId)
                            {
                                temp.Affiliation = tempAffiliation;
                                break;
                            }
                        }
                        temp.Gender = reader.GetString(4);
                        temp.BirthDate = reader.GetDateTime(5);
                        participants.Add(temp);
                    }
            }

            return participants;
        }

        public async Task<IEnumerable<Affiliation>> RefreshAffiliations()
        {
            List<Affiliation> affiliations = new List<Affiliation>();
            string getAffiliationsQuery = "SELECT * FROM " + Constants.AFFILIATION + " WHERE active = 1;";

            using (var connection1 = new MySqlConnection(Constants.CONNECTION_STRING))
            {
                await connection1.OpenAsync();
                using (var cmd = new MySqlCommand(getAffiliationsQuery, connection1))
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        Affiliation temp = new Affiliation();
                        temp.Id = reader.GetInt32(0);
                        temp.Name = reader.GetString(1);
                        temp.Abbreviation = reader.GetString(2);
                        affiliations.Add(temp);
                    }
            }

            return affiliations;
        }

        public async Task<string> Save(Participant updatedParticipant)
        {
            throw new NotImplementedException();
        }
    }
}
