using System;
using System.Collections.Generic;
using System.Text;

namespace esoft.ViewModel
{
    class CreateTaskPageVIewModel : BaseViewModel
    {
        private string login;

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public CreateTaskPageVIewModel(string login) {
            Login = login;
        }
    }
}
