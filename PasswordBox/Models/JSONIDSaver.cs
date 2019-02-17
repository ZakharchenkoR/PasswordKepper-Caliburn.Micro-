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
    class JSONIDSaver : IIDSaver
    {
        public void Save(int id)
        {
            string account_id = JsonConvert.SerializeObject(id);
            File.WriteAllText("data.json", account_id, Encoding.Default);
        }
    }
}
