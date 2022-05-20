using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        public string ContentValue { get; set; }
        public string AnswerImage { get; set; }
        public DateTime ContentDate { get; set; }


        public int? StudentID { get; set; } // Onaylandı
        public virtual Student Student { get; set; }

        public int HeadingID { get; set; } // Onaylandı
        public virtual Heading Heading { get; set; }

    }
}
