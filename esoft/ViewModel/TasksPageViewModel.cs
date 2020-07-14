using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace esoft.ViewModel
{
    class TasksPageViewModel : BaseViewModel
    {
        private string login;
        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }
    }
}
