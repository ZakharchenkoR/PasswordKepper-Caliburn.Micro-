using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordBox.Models;

namespace PasswordBox.Infrasrtucture
{
    interface IPasswordKeeperSaver
    {
        void Save(IEnumerable<PasswordKeeper> passwords);
    }
}
