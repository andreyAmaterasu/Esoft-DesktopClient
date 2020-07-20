using esoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace esoft.ViewModel
{
    class MainPageViewModel : BaseViewModel
    {
        private string login;
        private Page currentPage;

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Firstname {
            get { return Database.DatabaseManager.GetUserWithLogin<Manager>(Login).Firstname; }

        }

        public string Lastname {
            get { return Database.DatabaseManager.GetUserWithLogin<Manager>(Login).Lastname; }
        
        }

        private RelayCommand toPerformer;
        public RelayCommand ToPerformer {
            get {
                return toPerformer ??
                    (toPerformer = new RelayCommand(obj => {
                        CurrentPage = new View.PerformersPage();
                        DataContextForPages(new PerformersPageViewModel());
                    }));
            }
        }

        private RelayCommand toTasks;
        public RelayCommand ToTasks {
            get {
                return toTasks ??
                    (toTasks = new RelayCommand(obj => {
                        CurrentPage = new View.TasksPage();
                        TasksPageViewModel tasksPageContext = new TasksPageViewModel();
                        tasksPageContext.Login = Login;
                        DataContextForPages(tasksPageContext);
                    }));
            }
        }

        public Page CurrentPage {
            get { return currentPage; }
            set {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public void DataContextForPages<T>(T dataContext) {
            currentPage.DataContext = dataContext;
        }
    }
}
