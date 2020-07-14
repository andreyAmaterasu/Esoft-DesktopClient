using System;
using System.Collections.Generic;

namespace esoft.Models
{
    public partial class Task
    {
        public int Taskid { get; set; }
        public string Taskname { get; set; }
        public string Aboutoftask { get; set; }
        public DateTime Periodofexecution { get; set; }
        public DateTime? Dateofcompletion { get; set; }
        public short Taskcomplexity { get; set; }
        public short Timetocompletethetask { get; set; }
        public string Taskstatus { get; set; }
        public string Natureofthetask { get; set; }
        public string Taskperformer { get; set; }

        public virtual Performer TaskperformerNavigation { get; set; }
    }
}
