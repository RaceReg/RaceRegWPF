using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public interface IRaceRegDB
    {
        Task<IEnumerable<Participant>> RefreshAffiliations();
        Task<string> Save(Participant updatedParticipant);
    }
}
