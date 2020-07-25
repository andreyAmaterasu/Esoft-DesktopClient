using esoft.Models;
using esoft.View;
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
        public MainPageViewModel(string login) {
            Login = login;
        }

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
            get {
                var user = Database.DatabaseManager.GetUserWithLogin<Performer>(login);
                if (user != null) {
                    return user.Firstname;
                }
                else {
                    return Database.DatabaseManager.GetUserWithLogin<Manager>(login).Firstname;
                }
            }
        }

        public string Lastname {
            get {
                var user = Database.DatabaseManager.GetUserWithLogin<Performer>(login);
                if (user != null) {
                    return user.Lastname;
                }
                else {
                    return Database.DatabaseManager.GetUserWithLogin<Manager>(login).Lastname;
                }
            }
        }

        private RelayCommand toPerformer;
        public RelayCommand ToPerformer {
            get {
                return toPerformer ??
                    (toPerformer = new RelayCommand(obj => {
                        PerformersPage performersPage = new PerformersPage();
                        PerformersPageViewModel performersPageViewModel = new PerformersPageViewModel();
                        MainPage.CurrentPage.Content = performersPage;
                        //CurrentPage = new View.PerformersPage();
                        //DataContextForPages(new PerformersPageViewModel());

                        //PerformersPage.CurrentPage.Content = new PerformersPage();

                    }));
            }
        }

        private RelayCommand toTasks;
        public RelayCommand ToTasks {
            get {
                return toTasks ??
                    (toTasks = new RelayCommand(obj => {
                        TasksPage tasksPage = new View.TasksPage();
                        TasksPageViewModel taskPageViewModel = new TasksPageViewModel(Login);
                        tasksPage.DataContext = taskPageViewModel;
                        MainPage.CurrentPage.Content = tasksPage;
                        //CurrentPage = new View.TasksPage();
                        //TasksPageViewModel tasksPageContext = new TasksPageViewModel(Login);
                        //tasksPageContext.Login = Login;
                        //DataContextForPages(tasksPageContext);
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
