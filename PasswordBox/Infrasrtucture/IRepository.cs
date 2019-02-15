using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordBox.Models;

namespace PasswordBox.Infrasrtucture
{
    interface IRepository
    {
        IEnumerable<Password> GetAll();
        void Create(Password item);
        void Update(Password item);
        void Delete(Password item);
    }
}
