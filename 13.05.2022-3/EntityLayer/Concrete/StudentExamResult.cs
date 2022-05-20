using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class StudentExamResult
    {
        [Key]
        public int StudentExamResultID { get; set; }
       
        public int StudentScore { get; set; }
        public int StudentWrongScore { get; set; }

        public int ExamID { get; set; }
        public virtual Exam exams { get; set; }

        public int StudentID { get; set; }
        public virtual Student students { get; set; }

    }
}
