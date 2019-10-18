using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unleash_the_giraffe
{
    class Json
    {
        public static T LoadExternal<T>(string path) where T : class
        {
            var fileData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(fileData);
        }

        public static T LoadFromJson<T>(string json) where T : class => JsonConvert.DeserializeObject<T>(json);

        public static void Save<T>(T item, string path) where T : class
        {
            var json = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
