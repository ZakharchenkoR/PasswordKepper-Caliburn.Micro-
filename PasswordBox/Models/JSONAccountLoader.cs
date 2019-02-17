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
    class JSONAccountLoader : IAccountLoader
    {
        public List<Account> Load()
        {
            return JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText("Passwords.json")); ;
        }
    }
}
