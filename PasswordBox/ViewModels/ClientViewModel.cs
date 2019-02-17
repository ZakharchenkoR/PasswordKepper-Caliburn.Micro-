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
        private IRepository passwordRepository;
        private IPasswordKeeperSaver passwordKeeperSaver;
        private IPasswordKepperLoader passwordKepperLoader;
        #region Properties
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

        private Password password;
        public Password SelectedPassword
        {
            get { return password; }
            set { password = value; Notify(); }
        }

        private string pas;
        public string Pass
        {
            get { return pas; }
            set { pas = value; Notify(); }
        }

        private string log;
        public string Log
        {
            get { return log; }
            set { log = value; Notify(); }
        }

        private string uri;
        public string URI
        {
            get { return uri; }
            set { uri = value; Notify(); }
        }

        private string webservis;

        public string WebServis
        {
            get { return webservis; }
            set { webservis = value; Notify(); }
        }

        #endregion


        #region Commands
        public ICommand CLoseCommand { get; set; }
        public ICommand AddPassCOmmand { get; set; }
        public ICommand DeleteCOmmand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand SaveUpdate { get; set; }
        public ICommand CopyPassword { get; set; }
        public ICommand CopyLogin { get; set; }
        #endregion

        public ClientViewModel(IPasswordKeeperSaver saver,IPasswordKepperLoader loader)
        {
            CLoseCommand = new RelayCommand(CloseApplication);
            passwordRepository = new Repository();
            LoadCommand = new RelayCommand(Load);
            AddPassCOmmand = new RelayCommand(AddPassword);
            Passwords = new ObservableCollection<Password>();
            DeleteCOmmand = new RelayCommand(Delete);
            SaveUpdate = new RelayCommand(Save);
            CopyPassword = new RelayCommand(CopyPass);
            CopyLogin = new RelayCommand(CopyLog);
            passwordKeeperSaver = saver;
            passwordKepperLoader = loader;
        }

        #region Methods

        private void CloseApplication(object a)
        {
            Application.Current.Shutdown();
        }

        public void CopyPass(object a)
        {
            Clipboard.SetText(SelectedPassword.PassWor);
        }

        public void CopyLog(object a)
        {
            Clipboard.SetText(SelectedPassword.Login);
        }

        private void Save(object a)
        {
            passwordKeepers = passwordKepperLoader.Load();
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords = this.Passwords;
                    passwordKeeperSaver.Save(passwordKeepers);
                    MessageBox.Show("Updates is saver");
                    break;
                }
            }
        }

        private void Delete(object a)
        {
            Passwords.Remove(SelectedPassword);
            Passwords = new ObservableCollection<Password>(Passwords);

            passwordKeepers = passwordKepperLoader.Load();
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords = this.Passwords;
                    passwordKeeperSaver.Save(passwordKeepers);
                    break;
                }
            }
        }

        private void Load(object a)
        {
            passwordKeepers = passwordKepperLoader.Load();
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if(singleton.ID == item.ID)
                {
                 
                    Passwords = item.Passwords;
                    break;
                }
            }
        }

        private void AddPassword(object a)
        {
            Password passw = new Password { WebSerwise = this.WebServis, Login = this.Log, PassWor = this.Pass, Uri = this.URI };
            Passwords.Add(passw);
            Passwords = new ObservableCollection<Password>(Passwords);
            passwordKeepers = passwordKepperLoader.Load();
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords.Add(passw);
                    passwordKeeperSaver.Save(passwordKeepers);
                    this.WebServis = String.Empty;
                    this.Log = String.Empty;
                    this.Pass = String.Empty;
                    this.URI = String.Empty;
                    break;
                }
            }
        }
        #endregion
    }
}
