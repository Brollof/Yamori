using DevComponents.DotNetBar.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem.Device.DeviceViewModel
{
    class DeviceModel
    {
        private DeviceType type;
        private string name;
        private eCalendarColor color;
        private bool hasColor;
        private int slot;

        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        public DeviceType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public eCalendarColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool HasColor
        {
            get { return hasColor; }
            set { hasColor = value; }
        }

        public DeviceModel() { }
        public DeviceModel(DeviceType type) { this.type = type; }
    }
}
