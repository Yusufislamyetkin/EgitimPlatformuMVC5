using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class AytDeneme
    {
        [Key]
        public int ID { get; set; }
        public decimal EdebNet { get; set; }
        public decimal SosNet { get; set; }
        public decimal MatNet { get; set; }
        public decimal FenNet { get; set; }
        public decimal TopNet { get; set; }
        public decimal Puan { get; set; }


        public int StudentID { get; set; }
        public virtual Student students { get; set; }

        [StringLength(30)]
        public string Yayın { get; set; }
        public DateTime Tarih { get; set; }
    }
}
