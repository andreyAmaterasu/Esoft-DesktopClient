using esoft.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using esoft.Database;
using System.Linq;
using esoft.Models;

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

        private dynamic PerformerManager() {
            using (esoftContext db = new esoftContext()) {
                var user = Database.DatabaseManager.GetUserWithLogin<Performer>(login);
                if (user != null) {
                    IEnumerable<Performer> performers = db.Performer.Where(p => p.Login == Login);
                    List<Manager> managers = db.Manager.ToList();
                    List<Task> tasks = db.Task.ToList();

                    var temp = tasks.Join(performers, t => t.Taskperformer, p => p.Login, (t, p) => new {
                        Manager = p.Manager,
                        TaskStatus = t.Taskstatus,
                        TaskName = t.Taskname,
                        Performer = $"Исполнитель: {p.Lastname} {p.Firstname} {p.Patronymic}",
                    }).ToList();

                    var result = temp.Join(managers, t => t.Manager, m => m.Login, (t, m) => new {
                        TaskName = t.TaskName,
                        TaskStatus = t.TaskStatus,
                        Performer = t.Performer,
                        Manager = $"Менеджер: {m.Lastname} {m.Firstname} {m.Patronymic}"
                    }).ToList();

                    return result;
                }
                else {
                    IEnumerable<Manager> managers = db.Manager.Where(m => m.Login == Login);
                    List<Performer> performers = db.Performer.ToList();
                    List<Task> tasks = db.Task.ToList();

                    var temp = performers.Join(managers, p => p.Manager, m => m.Login, (p, m) => new {
                        PerformerLogin = p.Login,
                        Performer = $"Исполнитель: {p.Lastname} {p.Firstname} {p.Patronymic}",
                        Manager = $"Менеджер: {m.Lastname} {m.Firstname} {m.Patronymic}"
                    }).ToList();

                    var result = temp.Join(tasks, te => te.PerformerLogin, ta => ta.Taskperformer, (te, ta) => new {
                        TaskName = ta.Taskname,
                        TaskStatus = ta.Taskstatus,
                        Performer = te.Performer,
                        Manager = te.Manager
                    }).ToList();

                    return result;
                }
            }
        }

        //public List<Performer> Performers {
        //    get { return Database.DatabaseManager.GetUsersWithType<Performer>(); }
        //}

        public dynamic Performers {
            get { return PerformerManager(); }
        }
    }
}
