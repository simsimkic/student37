using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Database.Sequencer
{
    public class LongSequencer : ISequencer<long>
    {
        private long _nextId;
        public long GenerateId() => ++_nextId;
        public void Initialize(long initId) => _nextId = initId;
    }
}
