using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public  class CourseFallow
    {
        [Key]
        public int ID { get; set; }
      
        public string Ders { get; set; }
        public string Konu { get; set; }
        public bool Durum { get; set; }
        public DateTime Tarih { get; set; }


        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
