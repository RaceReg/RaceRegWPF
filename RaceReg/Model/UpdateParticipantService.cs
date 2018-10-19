using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    interface UpdateParticipantService
    {
        Task<IEnumerable<Participant>> Refresh();
        Task<string> Save(Participant updatedParticipant);
    }
}
