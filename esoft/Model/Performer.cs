using System;
using System.Collections.Generic;

namespace esoft.Models
{
    public partial class Performer
    {
        public Performer()
        {
            Task = new HashSet<Task>();
        }

        public string Login { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string Grade { get; set; }
        public string Manager { get; set; }

        public virtual Useraccount LoginNavigation { get; set; }
        public virtual Manager ManagerNavigation { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
