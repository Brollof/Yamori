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

        public static string GetJson(List<Event> heater, List<Lamp> lamps, List<LampConfig> lampConfig)
        {
            JObject data = new JObject();
            JObject events = new JObject();
            JObject config = new JObject();

            // Heater
            events.Add(JsonCreator.PropertyFromList("Heater", heater));

            // Lamps
            JObject lampsRoot = new JObject();
            foreach (var lamp in lamps)
            {
                lampsRoot.Add(JsonCreator.PropertyFromList(lamp.Name, lamp.Events));
            }

            events.Add(new JProperty("Lamps", lampsRoot));

            // Config
            config.Add(JsonCreator.PropertyFromList("Lamps", lampConfig));

            data.Add("Events", events);
            data.Add("Config", config);

            Console.WriteLine(data);
            return JsonConvert.SerializeObject(data);
        }
    }
}
