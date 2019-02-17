using Newtonsoft.Json;
using PasswordBox.Infrasrtucture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Models
{
    class JSONIDLoader : IDLoader
    {
        public int Load()
        {
            return  JsonConvert.DeserializeObject<int>(File.ReadAllText("data.json"));
        }
    }
}
