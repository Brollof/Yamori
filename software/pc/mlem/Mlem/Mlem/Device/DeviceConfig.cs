using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem.Device
{
    public class DeviceConfig
    {
        private List<Event> events;
        private string name;
        private RGB color;
        private int slot;
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public List<Event> Events
        {
            get { return events; }
            set { events = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public RGB Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        public DeviceConfig() { }
        public DeviceConfig(string name) { this.name = name; }

    }
}
