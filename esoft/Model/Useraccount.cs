using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace esoft.Models
{
    public partial class Useraccount : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private bool accountStatus;
        private DateTime datetimeAuthorized;
        private Manager manager;
        private Performer performer;

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
                OnPropertyChanged("Paasword");
            }
        }
        public bool Accountstatus {
            get { return accountStatus; }
            set {
                accountStatus = value;
                OnPropertyChanged("AccountStatus");
            }
        }
        public DateTime Datetimeauthorized {
            get { return datetimeAuthorized; }
            set {
                datetimeAuthorized = value;
                OnPropertyChanged("Datetimeauthorized");
            }
        }

        public virtual Manager Manager {
            get { return manager; }
            set {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }
        public virtual Performer Performer {
            get { return performer; }
            set {
                performer = value;
                OnPropertyChanged("Performer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}