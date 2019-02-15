using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Models
{
    class PasswordKeeper
    {
        public int ID { get; set; }
        public ObservableCollection<Password> Passwords {get;set;}

        public PasswordKeeper()
        {
            Passwords = new ObservableCollection<Password>();
        }

        public static List<PasswordKeeper> GetPasswordKeepers()
        {
            return new List<PasswordKeeper>()
            {
                new PasswordKeeper{ID = 1},
                new PasswordKeeper{ID = 2}
            };
        }
    }
}
