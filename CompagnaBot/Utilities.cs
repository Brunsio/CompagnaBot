using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace CompagnaBot
{
    public class Utilities
    {

        private static Dictionary<string, string> alerts;

            static Utilities()
            {
            string json = File.ReadAllText("SystemLang/Config.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string,string>>();
            }

        public static string GetAlert(string key)
        {

            if (alerts.ContainsKey(key)) return alerts[key];
            return "";

        }

    }
}
