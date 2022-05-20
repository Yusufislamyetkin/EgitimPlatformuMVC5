using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentImage { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPassword { get; set; }
        public string StudentAbout { get; set; }
        public string StudentTitle { get; set; }
        public string SecurityQuestion { get; set; }
    
        public bool StudentStatus { get; set; }
        public DateTime MemeberShipDate { get; set; }

     
        public ICollection<Content> Contents { get; set; } // Onaylandı
        public ICollection<Heading> Headings { get; set; } // Onaylandı
        public ICollection<CourseFallow> courseFallows { get; set; } // Onaylandı
        public ICollection<ExamQuestionFollow> ExamQuestionFollow { get; set; } // Onaylandı
        public ICollection<StudentExamResult> StudentExamResults { get; set; }
        public ICollection<calendar> calendars { get; set; }
    }
}
