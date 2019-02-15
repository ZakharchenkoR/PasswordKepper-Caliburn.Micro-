using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Models
{
    class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }

        public static List<Account> GetAccounts()
        {
            return new List<Account>()
            {
                new Account{Login = "qwe",Password = "123",ID = 1},
                new Account{Login ="asd", Password = "321",ID=2}
            };
        }
    }
}
