using System;
using esoft.Models;
using System.Collections.Generic;
using System.Text;
using esoft.Database;
using System.Linq;

namespace esoft.ViewModel
{
    class PerformersPageViewModel : BaseViewModel
    {
        private dynamic PerformerManager() {
            using (esoftContext db = new esoftContext()) {
                List<Performer> performers = db.Performer.ToList();
                List<Manager> managers = db.Manager.ToList();

                var result = performers.Join(managers, p => p.Manager, m => m.Login, (p, m) => new {
                    Performers = $"{p.Lastname} {p.Firstname} {p.Patronymic}",
                    Grade = p.Grade,
                    Managers = $"Менеджер: {m.Lastname} {m.Firstname} {m.Patronymic}"
                }).ToList();

                return result;
            }
        }

        public dynamic Performers {
            get { return PerformerManager(); }
        }
    }
}
