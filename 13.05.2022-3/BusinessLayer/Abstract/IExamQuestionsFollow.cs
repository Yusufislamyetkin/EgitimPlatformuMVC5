using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IExamQuestionsFollow
    {
        ExamQuestionFollow GetById(int id);
        List<ExamQuestionFollow> List();
        List<ExamQuestionFollow> WhereList(int id);

        void Add(ExamQuestionFollow ExamQuestionFollow);
        
   
        void Update(ExamQuestionFollow ExamQuestionFollow);

    }
}
