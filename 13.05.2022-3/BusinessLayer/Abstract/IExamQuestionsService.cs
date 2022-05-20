using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IExamQuestionsService
    {

        ExamQuestion GetById(int id);
        List<ExamQuestion> List();
        List<ExamQuestion> WhereList();
        void Add(ExamQuestion ExamQuestion);
        void Delete(ExamQuestion ExamQuestion);
        void Update(ExamQuestion ExamQuestion);

    }
}
