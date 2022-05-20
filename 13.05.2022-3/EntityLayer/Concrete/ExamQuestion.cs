using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class ExamQuestion
    {
        [Key]
        public int ExamQuestionID { get; set; }
        public string Question { get; set; }
        public string QuestionImage { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        public string CorrectAnswer { get; set; }

        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }

        public ICollection<ExamQuestionFollow> examQuestionFollows { get; set; }

    }
}
