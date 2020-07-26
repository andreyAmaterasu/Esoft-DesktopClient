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
        private bool showMessage;
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
        public bool ShowMessage {
            get { return showMessage; }
            set {
                showMessage = value;
                OnPropertyChanged("ShowMessage");
            }
        }

        private RelayCommand entryCommand;
        public RelayCommand EntryCommand {
            get {
                return entryCommand ??
                  (entryCommand = new RelayCommand(obj => {
                      Password = inputPassword.Password;
                      Useraccount useraccount = (Useraccount)Database.DatabaseManager.GetUserWithLogin<Useraccount>(Login);
                      if (useraccount != null && useraccount.Login == Login && useraccount.Password == Password) {
                          MainPage mainPage = new MainPage(Login);
                          TasksPage tasksPage = new View.TasksPage(Login);
                          MainPage.CurrentPage.Content = tasksPage;

                          NavigationService.Navigate(mainPage);
                      }
                      else {
                          ShowMessage = true;
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
