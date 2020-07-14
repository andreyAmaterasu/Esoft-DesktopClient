using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using esoft.Models;
using esoft.ViewModel;

namespace esoft.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INotifyPropertyChanged
    {
        public LoginPage() {
            InitializeComponent();

            DataContext = this;
        }

        private string login;
        private string password;
        private bool showMassage;
        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public bool ShowMassage {
            get { return showMassage; }
            set {
                showMassage = value;
                OnPropertyChanged("ShowMassage");
            }
        }

        private RelayCommand entryCommand;
        public RelayCommand EntryCommand {
            get {
                return entryCommand ??
                  (entryCommand = new RelayCommand(obj => {
                      Useraccount useraccount = Database.DatabaseManager.GetUserWithLogin(Login);
                      if (useraccount != null && useraccount.Login == Login && useraccount.Password == Password) {
                          ShowMassage = false;
                          MainPage mainPage = new MainPage();
                          MainViewModel mainViewModel = new MainViewModel();
                          mainViewModel.Login = Login;
                          mainViewModel.Pass = password;
                          mainViewModel.CurrentPage = new View.TasksPage();
                          mainViewModel.DataContextForPages = mainViewModel;
                          mainPage.DataContext = mainViewModel;
                          NavigationService.Navigate(mainPage);
                      }
                      else {
                          ShowMassage = true;
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
