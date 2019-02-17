using PasswordBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Infrasrtucture
{
    interface IAccountLoader
    {
        List<Account> Load();
    }
}
