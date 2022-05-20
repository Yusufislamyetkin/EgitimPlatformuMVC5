using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Questions
    {
        [Key]
        public int QuestionsID { get; set; }
        public String Question { get; set; }
        public String AnswerA { get; set; }
        public String AnswerB { get; set; }
        public String AnswerC { get; set; }
        public String AnswerD { get; set; }
        public String CorrectAnswer { get; set; }

        public virtual int ExamID { get; set; }
        public Exam Exam { get; set; }

    }
}
