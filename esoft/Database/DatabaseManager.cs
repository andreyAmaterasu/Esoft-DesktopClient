using esoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace esoft.Database
{
    class DatabaseManager
    {
        public static void Add(Useraccount ua) {
            using (esoftContext db = new esoftContext()) {
                db.Useraccount.Add(ua);
                db.SaveChanges();
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
            }
            return null;
        }

        public static T GetUserWithLogin<T>(string login) where T : class {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount))
                    return db.Useraccount.Where(m => m.Login == login).FirstOrDefault() as T;
                else if (typeof(T) == typeof(Manager))
                    return db.Manager.Where(m => m.Login == login).FirstOrDefault() as T;
            }
            return null;
        }

        public static void Edit<T>(T obj) {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount)) {
                    db.Useraccount.Update(obj as Useraccount);
                    db.SaveChanges();
                }
            }
        }
    }
}
