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

        public static List<T> Load<T>() {
            using (esoftContext db = new esoftContext()) {
                if (typeof(T) == typeof(Useraccount)) {
                    return db.Useraccount.ToList() as List<T>;
                }
            }
            return null;
        }

        public static Useraccount GetUserWithLogin(string login) {
            using (esoftContext db = new esoftContext()) {
                return db.Useraccount.Where(u => u.Login == login).FirstOrDefault();
            }
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
