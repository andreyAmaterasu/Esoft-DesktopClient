using System;
using System.Collections.Generic;

namespace esoft.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Performer = new HashSet<Performer>();
        }

        public string Login { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }

        public virtual Useraccount LoginNavigation { get; set; }
        public virtual Listofcoefficient Listofcoefficient { get; set; }
        public virtual ICollection<Performer> Performer { get; set; }
    }
}
