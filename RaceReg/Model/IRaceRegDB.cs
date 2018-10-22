using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public interface IRaceRegDB
    {
        List<Affiliation> GetAffiliations();
        bool SaveAffiliation(int Id);
        bool SaveAffiliation();

        List<Participant> GetParticipants();
        bool SaveParticipant(int Id);
        bool SaveParticipant();
    }
}
