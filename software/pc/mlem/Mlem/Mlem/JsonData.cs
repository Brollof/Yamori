using Mlem.Device;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    public static class JsonCreator
    {
        public static JArray ArrayFromList<T>(List<T> items)
        {
            JArray values = new JArray();

            foreach (T item in items)
            {
                values.Add(JObject.FromObject(item));
            }

            return values;
        }

        public static JProperty PropertyFromList<T>(string propName, List<T> items)
        {
            JArray array = JsonCreator.ArrayFromList(items);
            return new JProperty(propName, array);
        }

        private static JObject GetConfigJsonObj(int min, int max, List<LimitTempModel> limitTempModels)
        {
            JObject config = new JObject();
            JObject limits = new JObject();

            // filter models - remove not selected one
            limitTempModels.RemoveAll(model => !model.Selected);

            limits.Add(JsonCreator.PropertyFromList("Events", limitTempModels));
            limits.Add(new JProperty("Min", min));
            limits.Add(new JProperty("Max", max));

            config.Add("Limits", limits);

            return config;
        }

        public static string GetJson(List<DeviceConfig> devConfs, int min, int max, List<LimitTempModel> limitTempModels)
        {
            JObject data = new JObject();
            JObject devices = new JObject();
            JObject config = GetConfigJsonObj(min, max, limitTempModels);

            for (int i = 0; i < devConfs.Count; i++)
            {
                JObject content = new JObject();
                content.Add(JsonCreator.PropertyFromList("Events", devConfs[i].Events));
                content.Add("Slot", devConfs[i].Slot);
                content.Add("Color", JObject.FromObject(devConfs[i].Color));
                content.Add("Type", devConfs[i].Type);
                devices.Add(new JProperty(devConfs[i].Name, content));
            }

            data.Add("Devices", devices);
            data.Add("Config", config);

            Console.WriteLine(data);
            return JsonConvert.SerializeObject(data);
        }
    }
}
