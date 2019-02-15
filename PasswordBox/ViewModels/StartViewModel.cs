﻿using Caliburn.Micro;
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
using Newtonsoft.Json;
using System.IO;

namespace PasswordBox.ViewModels
{
    public class StartViewModel:Screen
    {
        private int ID = 3;
        private List<Account> accounts;
        private List<PasswordKeeper> passwordKeepers;
        private readonly IWindowManager windowManager;
        public ICommand LoadCommand { get; set; }

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
        public StartViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
            accounts = Account.GetAccounts();
            passwordKeepers = PasswordKeeper.GetPasswordKeepers();
            LoadCommand = new RelayCommand(Load);
        }


        public bool CanLog(string login,string password) =>  !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password);


        public void Log(string login, string password)
        {
            foreach (var item in accounts)
            {
                if (item.Password == Password && item.Login == Login)
                {
                    int id = item.ID;
                    foreach (var it in passwordKeepers)
                    {
                        if(id == it.ID)
                        {
                            Singleton singleton = Singleton.GetInstance();
                            singleton.ID = id;
                            windowManager.ShowWindow(new ClientViewModel());
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
            accounts.Add(new Account { Password = this.Password, Login = this.Login, ID = this.ID });
            passwordKeepers.Add(new PasswordKeeper { ID = this.ID });
            this.ID++;
            string account_id = JsonConvert.SerializeObject(ID);
            File.WriteAllText("data.json", account_id, Encoding.Default);

            MessageBoxResult result = MessageBox.Show("Do you want go to your accaunt?",
                                          "Registration successful!",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Singleton singleton = Singleton.GetInstance();
                singleton.ID = ID;
                windowManager.ShowWindow(new ClientViewModel());
            }
            else
            {
                Application.Current.Shutdown();
            }
        }


        public void Load(object a)
        {
            ID = JsonConvert.DeserializeObject<int>(File.ReadAllText("data.json"));
            MessageBox.Show(ID.ToString());
           
        }

    }
}