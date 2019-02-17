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
    class JSONAccountSaver : IAccountSaver
    {
        public void Save(IEnumerable<Account> accounts)
        {
            string passwords = JsonConvert.SerializeObject(accounts);
            File.WriteAllText("Passwords.json", passwords, Encoding.Default);
        }
    }
}
