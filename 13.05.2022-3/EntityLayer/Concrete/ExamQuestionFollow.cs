using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class ExamQuestionFollow
    {
        [Key]
        public int ExamQuesitonFollowID { get; set; }

        public DateTime ExamQuestionFollowDate { get; set; }

        public string StudentAnswer { get; set; }

        public string CorrectAnswer { get; set; }

    



        
        public int ExamID { get; set; }
        public int ExamQuestionID { get; set; }
        public virtual ExamQuestion ExamQuestion { get; set; }

       

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }


    }
}
