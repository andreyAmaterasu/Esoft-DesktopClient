using System;
using System.Collections.Generic;

namespace esoft.Models
{
    public partial class Listofcoefficient
    {
        public string Manager { get; set; }
        public int Minimumwagegm { get; set; }
        public short Timetocompletethetaskti { get; set; }
        public short Coefficientofcosttimetc { get; set; }
        public short Taskcomplexitydi { get; set; }
        public short Coefficientoftaskcomplexityde { get; set; }
        public float Coefficientofnatureofworkci { get; set; }
        public short Forconvertedintocashtb { get; set; }

        public virtual Manager ManagerNavigation { get; set; }
    }
}
