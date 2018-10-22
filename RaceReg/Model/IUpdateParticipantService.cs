using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceReg.Model
{
    public interface IUpdateParticipantService
    {
        Task<IEnumerable<Participant>> Refresh();
        Task<string> Save(Participant updatedParticipant);
    }
}
