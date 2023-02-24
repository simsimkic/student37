using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.DB
{
    class Config
    {
        private Config()
        {
            if (!File.Exists(@"./../../config.ini")) File.Create(@"./../../config.ini");
            string[] lines = File.ReadAllLines(@"./../../config.ini");
            foreach (string line in lines)
            {
                string[] tokens = line.Split('=');
                GetType().GetProperty(tokens[0]).SetValue(this, bool.Parse(tokens[1]));
            }
        }
        public static Config Instance { get; } = new Config();

        public bool HelpEnabled { get; set; }

        ~Config()
        {
            string[] cfg = { "HelpEnabled=" + HelpEnabled };
            File.WriteAllLines(@"./../../config.ini", cfg);
        }

    }
}
