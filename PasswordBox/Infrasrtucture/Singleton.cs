using PasswordBox.Models;
using PasswordBox.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Infrasrtucture
{
    class Singleton
    {

        public int ID { get; set; } 

        private Singleton() { }
        static Singleton instance;
        public static Singleton GetInstance()
        {
            return instance ?? (instance = new Singleton());
        }
    }
}
