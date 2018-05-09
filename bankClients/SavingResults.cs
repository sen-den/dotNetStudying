using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace bankClients
{
    public class Results
    {
        public List<String> result = new List<string>();

        public String log(String info)
        {
            result.Add(info);
            return info;
        }

        public void save(String filename)
        {
            var jsonLog = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (var writer = new System.IO.StreamWriter(filename))
            {
                writer.Write(jsonLog);
            }
        }
    }
}