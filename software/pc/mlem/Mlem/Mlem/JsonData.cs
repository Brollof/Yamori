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
        public IList<Lamp> Lamps { get; set; }
    }

    class IO
    {
        public bool State { get; set; }
        public DateTime Time { get; set; }
    }

    class Lamp : IO
    {
        public string Name { get; set; }
    }

    static class JsonCreator
    {
        public static string Create(IO heater, List<Lamp> lamps)
        {
            return "a";
        }
    }
}
