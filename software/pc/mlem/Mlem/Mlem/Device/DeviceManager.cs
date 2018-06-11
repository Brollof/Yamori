using DevComponents.DotNetBar.Schedule;
using Mlem.Device.DeviceViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mlem.Device
{
    public enum DeviceType
    {
        [Description("Lampa")]
        LAMP = 0,

        [Description("Kabel")]
        CABLE,

        [Description("Kamień")]
        STONE,
    };

    public class DeviceManager
    {
        private static List<DeviceModel> devices = new List<DeviceModel>();

        internal static List<DeviceModel> Devices
        {
            get { return DeviceManager.devices; }
            set { DeviceManager.devices = value; }
        }
        
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static bool HasColor(DeviceType type)
        {
            if (type == DeviceType.LAMP)
                return true;

            return false;
        }

        public static eCalendarColor GetDefaultColor(DeviceType type)
        {
            return eCalendarColor.Steel;
        }

        public static List<String> GetNames()
        {
            List<string> names = devices.ConvertAll(dev => dev.Name);
            return names;
        }

        public static void AddDevice(string name, DeviceType type, int slot, eCalendarColor color)
        {
            DeviceModel device = new DeviceModel();
            device.Name = name;
            device.Type = type;
            device.Slot = slot;
            if (color == eCalendarColor.Automatic)
            {
                device.HasColor = false;
            }
            else
            {
                device.HasColor = true;
                device.Color = color;
            }
            devices.Add(device);
        }

        public static void RemoveDevice(string name)
        {
            devices.RemoveAll(dev => dev.Name == name);
        }

        public static void Print()
        {
            foreach(var dev in devices)
            {
                Console.WriteLine("Name: " + dev.Name);
                Console.WriteLine("Type: " + dev.Type.ToString());
                Console.WriteLine("Has color: " + dev.HasColor.ToString());
                Console.WriteLine("Color: " + dev.Color.ToString());
            }
        }

        public static bool CanAdd(string name)
        {
            return !devices.Any(dev => dev.Name == name);
        }
    }
}
