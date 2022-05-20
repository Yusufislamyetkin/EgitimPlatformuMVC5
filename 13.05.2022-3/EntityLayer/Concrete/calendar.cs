using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class calendar
    {
        public int calendarID { get; set; }
        public string CalenderContent { get; set; }



        [DisplayFormat(DataFormatString = "{0:d}")] //Format as ShortDateTime
        public DateTime CalendarDate { get; set; }

        public bool CalendarStatus { get; set; }

        public int? StudentID { get; set; } // Onaylandı
        public virtual Student Student { get; set; }
    }
}
