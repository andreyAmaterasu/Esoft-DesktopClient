using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace esoft.ViewModel
{
    class TasksPageViewModel : INotifyPropertyChanged
    {
        private string login;
        private string password;
        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Passw {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged("Passw");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
