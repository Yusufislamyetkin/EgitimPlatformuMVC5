using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }


        public int CategoryID { get; set; } //Onaylandı
        public virtual Category Category { get; set; }

        public ICollection<ExamQuestion> examQuestions { get; set; }
        public ICollection<StudentExamResult> studentExamResults { get; set; }
    }
}
