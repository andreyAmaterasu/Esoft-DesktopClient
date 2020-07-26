using esoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace esoft.Database
{
    class DatabaseManager
    {
        public static void CreateTask(Task task) {
            using (esoftContext db = new esoftContext()) {
                db.Task.Add(task);
                db.SaveChanges();
            }
        }

        public static List<Task> GetTasksWithPerformer(string login) {
            using (esoftContext db = new esoftContext()) {
                return db.Task.Where(t => t.Taskperformer == login).ToList();
            }
        }

        public static IEnumerable<Task> GetTasksWithManager(string login) {
            using (esoftContext db = new esoftContext()) {
                
                List<Performer> performers = db.Performer.Where(p => p.Manager == login).ToList();
                List<Task> tasks = db.Task.ToList();

                var result = tasks.Join(performers, t => t.Taskperformer, p => p.Login, (t, p) => new Task() {
                    Taskid = t.Taskid,
                    Taskname = t.Taskname,
                    Aboutoftask = t.Aboutoftask,
                    Periodofexecution = t.Periodofexecution,
                    Dateofcompletion = t.Dateofcompletion,
                    Taskcomplexity = t.Taskcomplexity,
                    Timetocompletethetask = t.Timetocompletethetask,
                    Taskstatus = t.Taskstatus,
                    Natureofthetask = t.Natureofthetask,
                    Taskperformer = t.Taskperformer,
                });


                return result;
            }
        }

        public static List<T> GetUsersWithType<T>() {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount)) {
                    return db.Useraccount.ToList() as List<T>;
                }
                else if (typeof(T) == typeof(Manager)) {
                    return db.Manager.ToList() as List<T>;
                }
                else if (typeof(T) == typeof(Performer)) {
                    return db.Performer.ToList() as List<T>;
                }
            }
            return null;
        }

        public static T GetUserWithLogin<T>(string login) where T : class {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount))
                    return db.Useraccount.Where(m => m.Login == login).FirstOrDefault() as T;
                else if (typeof(T) == typeof(Manager))
                    return db.Manager.Where(m => m.Login == login).FirstOrDefault() as T;
                else if (typeof(T) == typeof(Performer))
                    return db.Performer.Where(p => p.Login == login).FirstOrDefault() as T;
            }
            return null;
        }

        public static List<Performer> GetPerformersOfManager(string login) {
            using (esoftContext db = new esoftContext()) {
                return db.Performer.Where(p => p.Manager == login).ToList();
            }
        }

        public static void Edit<T>(T obj) {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount)) {
                    db.Useraccount.Update(obj as Useraccount);
                    db.SaveChanges();
                }
                if (typeof(T) == typeof(Task)) {
                    db.Task.Update(obj as Task);
                    db.SaveChanges();
                }
            }
        }

        public static void RemoveTask(int taskId) {
            using (esoftContext db = new esoftContext()) {
                Task task = db.Task.Where(t => t.Taskid == taskId).FirstOrDefault();
                db.Task.Remove(task);
                db.SaveChanges();
            }
        }
    }
}
