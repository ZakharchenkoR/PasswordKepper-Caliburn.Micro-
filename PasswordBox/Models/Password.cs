using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBox.Models
{
    class Password:BaseNotify
    {
        private string webserwise;

        public string WebSerwise
        {
            get { return webserwise; }
            set { webserwise = value; Notify(); }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; Notify(); }
        }


        private string password;

        public string PassWor
        {
            get { return password; }
            set { password = value; Notify(); }
        }

        private string uri;

        public string Uri
        {
            get { return uri; }
            set { uri = value; Notify(); }
        }


    }
}
