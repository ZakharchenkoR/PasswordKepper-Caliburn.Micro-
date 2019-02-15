using Infrastructure;
using Newtonsoft.Json;
using PasswordBox.Infrasrtucture;
using PasswordBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordBox.ViewModels
{
    class ClientViewModel:BaseNotify
    {
        IRepository passwordRepository;

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
        #endregion

        public ClientViewModel()
        {
            CLoseCommand = new RelayCommand(CloseApplication);
            passwordRepository = new Repository();
            LoadCommand = new RelayCommand(Load);
            AddPassCOmmand = new RelayCommand(AddPassword);
            Passwords = new ObservableCollection<Password>();
            DeleteCOmmand = new RelayCommand(Delete);
            SaveUpdate = new RelayCommand(Save);
        }

        #region Methods

        private void CloseApplication(object a)
        {
            Application.Current.Shutdown();
        }

        private void Save(object a)
        {
            passwordKeepers = JsonConvert.DeserializeObject<List<PasswordKeeper>>(File.ReadAllText("PasswordKepper.json"));
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords = this.Passwords;
                    string content = JsonConvert.SerializeObject(passwordKeepers);
                    File.WriteAllText("PasswordKepper.json", content, Encoding.Default);
                    MessageBox.Show("Updates is saver");
                    break;
                }
            }
        }

        private void Delete(object a)
        {
            Passwords.Remove(SelectedPassword);
            Passwords = new ObservableCollection<Password>(Passwords);

            passwordKeepers = JsonConvert.DeserializeObject<List<PasswordKeeper>>(File.ReadAllText("PasswordKepper.json"));
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords = this.Passwords;
                    string content = JsonConvert.SerializeObject(passwordKeepers);
                    File.WriteAllText("PasswordKepper.json", content, Encoding.Default);
                    break;
                }
            }
        }

        private void Load(object a)
        {
            passwordKeepers = JsonConvert.DeserializeObject<List<PasswordKeeper>>(File.ReadAllText("PasswordKepper.json"));
            Singleton singleton = Singleton.GetInstance();
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

        private void AddPassword(object a)
        {
            Password passw = new Password { WebSerwise = this.WebServis, Login = this.Log, PassWor = this.Pass, Uri = this.URI };
             Passwords.Add(passw);
             Passwords = new ObservableCollection<Password>(Passwords);
            passwordKeepers = JsonConvert.DeserializeObject<List<PasswordKeeper>>(File.ReadAllText("PasswordKepper.json"));
            Singleton singleton = Singleton.GetInstance();
            foreach (var item in passwordKeepers)
            {
                if (singleton.ID == item.ID)
                {

                    item.Passwords.Add(passw);
                    string content = JsonConvert.SerializeObject(passwordKeepers);
                    File.WriteAllText("PasswordKepper.json", content, Encoding.Default);
                    break;
                }
            }
        }
        #endregion
    }
}
