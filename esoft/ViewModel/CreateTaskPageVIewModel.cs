using esoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace esoft.ViewModel
{
    class CreateTaskPageVIewModel : BaseViewModel
    {
        private string login;
        private Performer selectedPerformer;
        private Task createdTask = new Task();
        private bool showMessage;

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public Performer SelectedPerformer {
            get { return selectedPerformer; }
            set {
                selectedPerformer = value;
                OnPropertyChanged("SelectedPerformer");
            }
        }

        public Task CreatedTask {
            get { return createdTask; }
            set {
                createdTask = value;
                OnPropertyChanged("CreatedTask");
            }
        }

        public List<string> StatusList {
            get { return new List<string>() { "Запланирована", "Исполняется", "Выполнена", "Отменена" }; }
        }

        public List<string> NatureOfTheTaskList {
            get { return new List<string>() { "Ананлиз и проектирование", "Установка оборудования", "Техническое обслуживание и сопровождение" }; }
        }

        public CreateTaskPageVIewModel(string login) {
            Login = login;
        }

        public List<Performer> PerformersList {
            get {
                return Database.DatabaseManager.GetPerformersOfManager(Login);
            }
        }

        private RelayCommand createTask;
        public RelayCommand CreateTask {
            get {
                return createTask ??
                    (createTask = new RelayCommand(obj => {
                        Database.DatabaseManager.CreateTask(CreatedTask);
                        ShowMessage = true;
                    }));
            }
        }

        public bool ShowMessage {
            get { return showMessage; }
            set {
                showMessage = value;
                OnPropertyChanged("ShowMessage");
            }
        }
    } 
}
