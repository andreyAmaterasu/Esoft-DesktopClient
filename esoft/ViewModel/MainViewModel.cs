using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace esoft.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private Page currentPage;
        public Page CurrentPage {
            get { return currentPage; }
            set {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public MainViewModel DataContextForPages {
            set {
                currentPage.DataContext = value;
                OnPropertyChanged("DataContextForPages");
            }
        }
        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Pass {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged("Pass");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
