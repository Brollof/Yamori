using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    class RootJson
    {
        public IO Heater { get; set; }
        public IO Lamp { get; set; }
    }

    class IO
    {
        public bool State { get; set; }
        public DateTime Time { get; set; }
    }
}
