using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Sequencer
{
    public interface ISequencer<T>
    {
        void Initialize(T initId);
        T GenerateId();
    }
}
