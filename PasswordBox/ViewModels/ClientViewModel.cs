using Infrastructure;
using PasswordBox.Infrasrtucture;
using PasswordBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordBox.ViewModels
{
    class ClientViewModel:BaseNotify
    {

        private ObservableCollection<Password> passwords;
        public ObservableCollection<Password> Passwords
        {
            get { return passwords; }
            set { passwords = value; Notify(); }
        }


        private List<PasswordKeeper> passwordKeepers;
        public List<PasswordKeeper> PasswordKeepers
        {
            get { return passwordKeepers; }
            set { passwordKeepers = value; }
        }

     
        IRepository passwordRepository;

        #region Commands
        public ICommand CLoseCommand { get; set; }
        public ICommand AddPassCOmmand { get; set; }
        public ICommand LoadCommand { get; set; }
        #endregion

        public ClientViewModel()
        {
            passwordKeepers = PasswordKeeper.GetPasswordKeepers();
            CLoseCommand = new RelayCommand(CloseApplication);
            passwordRepository = new Repository();
            LoadCommand = new RelayCommand(Load);
            AddPassCOmmand = new RelayCommand(AddPassword);
            Passwords = new ObservableCollection<Password>();
        }

        public void CloseApplication(object a)
        {
            Application.Current.Shutdown();
        }

        public void Load(object a)
        {
            Singleton singleton = Singleton.GetInstance();
            passwordKeepers = PasswordKeeper.GetPasswordKeepers();
            foreach (var item in passwordKeepers)
            {
                if(singleton.ID == item.ID)
                {
                    Passwords = item.Passwords;
                    MessageBox.Show(item.ID.ToString());
                    break;
                }
            }
        }

        public void AddPassword(object a)
        {
            MessageBox.Show("SSS");
             Passwords.Add(new Password { WebSerwise = "Google", PassWor = "123" ,Uri = "https://pbs.twimg.com/profile_images/1045580248467886080/_uwwJdr3_400x400.jpg"});
            Passwords = new System.Collections.ObjectModel.ObservableCollection<Password>(Passwords);
        }
    }
}
