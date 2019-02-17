using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordBox.Models;

namespace PasswordBox.Infrasrtucture
{
    interface IAccountSaver
    {
        void Save(IEnumerable<Account> accounts);
    }
}
