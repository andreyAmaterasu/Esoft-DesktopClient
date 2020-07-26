using esoft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace esoft.ViewModel
{
    class EditTaskPageViewModel : BaseViewModel
    {
        public EditTaskPageViewModel(string login) {
            Login = login;
        }

        private string login;
        private Task editedTask = new Task();

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public IEnumerable<Task> TasksList {
            get {
                var user = Database.DatabaseManager.GetUserWithLogin<Performer>(login);
                if (user != null) {
                    return Database.DatabaseManager.GetTasksWithPerformer(Login);
                }
                else {
                    return Database.DatabaseManager.GetTasksWithManager(Login);
                }
            }
        }

        public List<Performer> PerformersList {
            get { return Database.DatabaseManager.GetPerformersOfManager(Login); }
        }

        public List<string> StatusList {
            get { return new List<string>() { "Запланирована", "Исполняется", "Выполнена", "Отменена" }; }
        }

        public List<string> NatureOfTheTaskList {
            get { return new List<string>() { "Анализ и проектирование", "Установка оборудования", "Техническое обслуживание и сопровождение" }; }
        }

        public Task EditedTask {
            get { return editedTask; }
            set {
                editedTask = value;
                OnPropertyChanged("EditedTask");
            }
        }

        private RelayCommand editTask;
        public RelayCommand EditTask {
            get {
                return editTask ??
                    (editTask = new RelayCommand(obj => {
                        Database.DatabaseManager.Edit<Task>(EditedTask);
                    }));
            }
        }
    }
}
