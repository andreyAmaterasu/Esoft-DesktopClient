﻿using esoft.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using esoft.Database;
using System.Linq;
using esoft.Models;
using System.Security.Cryptography.Pkcs;

namespace esoft.ViewModel
{
    class TasksPageViewModel : BaseViewModel
    {
        private string login;
        private string selectedPerformer = "Все";
        private string selectedStatus = "Все";

        public string Login {
            get { return login; }
            set {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string SelectedPerformer {
            get { return selectedPerformer; }
            set {
                selectedPerformer = value;
                OnPropertyChanged("SelectedPerformer");
            }
        }

        public string SelectedStatus {
            get { return selectedStatus; }
            set {
                selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }

        public List<string> StatusList {
            get { return new List<string>() { "Запланирована", "Исполняется", "Выполнена", "Отменена", "Все" }; }
        }

        public List<string> PerformersList {
            get {
                List<string> performers = new List<string>();
                List<Performer> performersList = Database.DatabaseManager.GetUsersWithType<Performer>();

                foreach (Performer performer in performersList) {
                    performers.Add($"{performer.Lastname} {performer.Firstname} {performer.Patronymic}");
                }
                performers.Add("Все");
                return performers;
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
                    IEnumerable<Manager> managers = db.Manager.Where(m => m.Login == Login); ;
                    List<Performer> performers = db.Performer.ToList();
                    List<Task> tasks = db.Task.ToList();

                    if (SelectedPerformer != "Все") {
                        string[] words = SelectedPerformer.Split(new char[] { ' ' });
                        performers = db.Performer.Where(p => p.Lastname == words[0] && p.Firstname == words[1] && p.Patronymic == words[2]).ToList();
                    }

                    if (SelectedStatus != "Все") {
                        tasks = db.Task.Where(t => t.Taskstatus == SelectedStatus).ToList();
                    }

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

        public dynamic performers;

        public dynamic Performers {
            get { return performers; }
            set {
                performers = value;
                OnPropertyChanged("Performers");
            }
        }

        public TasksPageViewModel(string login) {
            Login = login;
            Performers = PerformerManager();
        }

        private RelayCommand filter;
        public RelayCommand Filter {
            get {
                return filter ??
                    (filter = new RelayCommand(obj => {
                        Performers = PerformerManager();
                    }));
            }
        }
    }
}
