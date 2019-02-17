using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PasswordBox.Infrasrtucture;

namespace PasswordBox.Models
{
    class JSONPasswordKepperSaver : IPasswordKeeperSaver
    {
        public void Save(IEnumerable<PasswordKeeper> passwords)
        {
            string content = JsonConvert.SerializeObject(passwords);
            File.WriteAllText("PasswordKepper.json", content, Encoding.Default);
        }
    }
}
