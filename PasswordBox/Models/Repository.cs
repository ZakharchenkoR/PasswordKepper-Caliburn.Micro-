using PasswordBox.Infrasrtucture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Models
{
    class Repository :  IRepository
    {
        ObservableCollection<Password> items;

        public void Create(Password item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Password item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Password> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Password item)
        {
            throw new NotImplementedException();
        }
    }
}
