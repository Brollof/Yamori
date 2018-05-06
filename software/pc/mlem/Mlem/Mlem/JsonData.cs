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
        public static JArray ArrayFromList(List<Event> events)
        {
            JArray values = new JArray();

            foreach (Event ev in events)
            {
                values.Add(JObject.FromObject(ev));
            }

            return values;
        }

        public static JProperty PropertyFromList(string propName, List<Event> events)
        {
            JArray array = JsonCreator.ArrayFromList(events);
            return new JProperty(propName, array);
        }

        public static string GetJson(List<Event> heater, List<Lamp> lamps)
        {
            // Heater
            JObject data = new JObject();
            data.Add(JsonCreator.PropertyFromList("Heater", heater));

            // Lamps
            JObject lampsRoot = new JObject();
            foreach(var lamp in lamps)
            {
                lampsRoot.Add(JsonCreator.PropertyFromList(lamp.Name, lamp.Events));
            }

            data.Add(new JProperty("Lamps", lampsRoot));

            return JsonConvert.SerializeObject(data);
        }
    }
}
