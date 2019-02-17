using Caliburn.Micro;
using PasswordBox.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PasswordBox.Models;
using System.Collections.ObjectModel;
using PasswordBox.Infrasrtucture;
using System.Windows.Input;

namespace PasswordBox.ViewModels
{
    public class StartViewModel:Screen
    {
        private int ID;
        private List<Account> accounts;
        private List<PasswordKeeper> passwordKeepers;
        private readonly IWindowManager windowManager;
        public ICommand LoadCommand { get; set; }
        private IAccountSaver accountSaver;
        private IPasswordKeeperSaver passwordKeeperSaver;
        private IIDSaver iDSaver;
        private IDLoader idLoader;
        private IAccountLoader accountLoader;
        private IPasswordKepperLoader passwordKepperLoader;
        private readonly IEventAggregator eventAggregator;
        IEncoder encoder;

        #region Properties
        private string login;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        #endregion
        public StartViewModel(IWindowManager windowManager,IIDSaver idsaver,IDLoader idLoader,IEncoder encoder, IEventAggregator eventAggregator)
        {
            this.windowManager = windowManager;
            LoadCommand = new RelayCommand(Load);
            accountSaver = new JSONAccountSaver();
            passwordKeeperSaver = new JSONPasswordKepperSaver();
            iDSaver = idsaver;
            this.idLoader = idLoader;
            accountLoader = new JSONAccountLoader();
            passwordKepperLoader = new JSONPasswordKepperLoader();
            this.eventAggregator = eventAggregator;
            this.encoder = encoder;
        }


        public bool CanLog(string login,string password) =>  !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password);


        public void Log(string login, string password)
        {
            foreach (var item in accounts)
            {
                if (item.Password == encoder.GetHashCode(Password) && item.Login == Login)
                {
                    int id = item.ID;
                    foreach (var it in passwordKeepers)
                    {
                        if(id == it.ID)
                        {
                            Singleton singleton = Singleton.GetInstance();
                            singleton.ID = id;
                            windowManager.ShowWindow(new ClientViewModel(passwordKeeperSaver, passwordKepperLoader));
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public bool CanAddClient(string login, string password) => !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password);

        public void AddClient(string login, string password)
        {
            foreach (var item in accounts)
            {
                if(this.Login == item.Login)
                {
                    MessageBox.Show("Such login already exists");
                    return;
                }
            }

            

            accounts.Add(new Account { Password = encoder.GetHashCode(Password), Login = this.Login, ID = this.ID });
            passwordKeepers.Add(new PasswordKeeper { ID = this.ID });
            accountSaver.Save(accounts);
            passwordKeeperSaver.Save(passwordKeepers);
            Singleton singleton = Singleton.GetInstance();
            singleton.ID = ID;
            this.ID++;
            iDSaver.Save(ID);
            MessageBoxResult result = MessageBox.Show("Do you want go to your accaunt?", "Registration successful!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {              
                windowManager.ShowWindow(new ClientViewModel(passwordKeeperSaver,passwordKepperLoader));
            }
            else
            {
                Application.Current.Shutdown();
            }
        }


        public void Load(object a)
        {
            ID = idLoader.Load();
            accounts = accountLoader.Load();
            passwordKeepers = passwordKepperLoader.Load();
        }

    }
}
