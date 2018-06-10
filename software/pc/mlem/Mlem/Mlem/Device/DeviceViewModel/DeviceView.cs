using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem.Device.DeviceViewModel
{
    class DeviceView
    {
        private DeviceModel model;

        internal DeviceModel Model
        {
            get { return model; }
            set { model = value; }
        }

    }
}
