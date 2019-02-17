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
    class JSONPasswordKepperLoader : IPasswordKepperLoader
    {
        public List<PasswordKeeper> Load()
        {
            return JsonConvert.DeserializeObject<List<PasswordKeeper>>(File.ReadAllText("PasswordKepper.json"));
        }
    }
}
