using esoft.ViewModel;
using System;
using System.Collections.Generic;

namespace esoft.Models
{
    public partial class Task : BaseViewModel
    {
        //public int Taskid { get; set; }
        //public string Taskname { get; set; }
        //public string Aboutoftask { get; set; }
        //public DateTime Periodofexecution { get; set; }
        //public DateTime? Dateofcompletion { get; set; }
        //public short Taskcomplexity { get; set; }
        //public short Timetocompletethetask { get; set; }
        //public string Taskstatus { get; set; }
        //public string Natureofthetask { get; set; }
        //public string Taskperformer { get; set; }

        private int taskid;
        private string taskname;
        private string aboutoftask;
        private DateTime periodofexecution;
        private DateTime? dateofcompletion;
        private short taskcomplexity;
        private short timetocompletethetask;
        private string taskstatus;
        private string natureofthetask;
        private string taskperformer;

        public int Taskid { 
            get { return taskid; }
            set {
                taskid = value;
                OnPropertyChanged("Taskid");
            }
        }
        public string Taskname {
            get { return taskname; }
            set {
                taskname = value;
                OnPropertyChanged("Taskname");
            }
        }
        public string Aboutoftask {
            get { return aboutoftask; }
            set {
                aboutoftask = value;
                OnPropertyChanged("Aboutoftask");
            }
        }
        public DateTime Periodofexecution {
            get { return periodofexecution; }
            set {
                periodofexecution = value;
                OnPropertyChanged("Periodofexecution");
            }
        }
        public DateTime? Dateofcompletion {
            get { return dateofcompletion; }
            set {
                dateofcompletion = value;
                OnPropertyChanged("Dateofcompletion");
            }
        }
        public short Taskcomplexity {
            get { return taskcomplexity; }
            set {
                taskcomplexity = value;
                OnPropertyChanged("Taskcomplexity");
            }
        }
        public short Timetocompletethetask {
            get { return timetocompletethetask; }
            set {
                timetocompletethetask = value;
                OnPropertyChanged("Timetocompletethetask");
            }
        }
        public string Taskstatus {
            get { return taskstatus; }
            set {
                taskstatus = value;
                OnPropertyChanged("Taskstatus");
            }
        }
        public string Natureofthetask {
            get { return natureofthetask; }
            set {
                natureofthetask = value;
                OnPropertyChanged("Natureofthetask");
            }
        }
        public string Taskperformer {
            get { return taskperformer; }
            set {
                taskperformer = value;
                OnPropertyChanged("Taskperformer");
            }
        }

        public virtual Performer TaskperformerNavigation { get; set; }
    }
}
