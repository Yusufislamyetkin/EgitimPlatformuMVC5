using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        public string HeadingName { get; set; }

        public string HeadingFirstContent { get; set; }
        public string Headingimage { get; set; }

        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        public int StudentID { get; set; } // Onaylandı
        public virtual Student Student { get; set; }

        public int CategoryID { get; set; } //Onaylandı
        public virtual Category Category { get; set; }

        public ICollection<Content> Contents { get; set; } //Onaylandı

    }
}
