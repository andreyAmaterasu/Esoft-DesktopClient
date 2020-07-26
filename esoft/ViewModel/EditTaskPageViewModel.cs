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
        private List<Task> tasksList;
        private Task selectedTask = new Task();

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public List<Task> TasksList {
            get {
                var user = Database.DatabaseManager.GetUserWithLogin<Performer>(login);
                if (user != null) {
                    return Database.DatabaseManager.GetTasksWithPerformer(Login);
                }
                else {
                    return Database.DatabaseManager.GetTasksWithPerformer(Login);
                }
            }
        }

        public Task SelectedTask {
            get { return selectedTask; }
            set {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }
    }
}
