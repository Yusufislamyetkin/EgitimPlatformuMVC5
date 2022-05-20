using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conctrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void AddValue(Questions p)
        {
            _questionDal.Insert(p);
        }

        public Questions GetByID(int id)
        {
            return _questionDal.Get(x => x.QuestionsID == id);
        }

        public List<Questions> GetList()
        {
            return _questionDal.List();
        }

        public void QuestionsDelete(Questions Questions)
        {
          _questionDal.Delete(Questions);
        }

        public void QuestionsUpdate(Questions Questions)
        {
            _questionDal.Update(Questions); 
        }

        public List<Questions> WhereList(int id)
        {
           return _questionDal.WhrList(x => x.Exam.ExamID == id);
        }
    }
}
