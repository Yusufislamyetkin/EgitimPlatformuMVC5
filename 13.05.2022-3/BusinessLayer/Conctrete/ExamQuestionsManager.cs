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
    public class ExamQuestionsManager : IExamQuestionsService
    {
        IExamQuestionsDal _examQuestionsDal;

        public ExamQuestionsManager(IExamQuestionsDal examQuestionsDal)
        {
            _examQuestionsDal = examQuestionsDal;
        }

        public void Add(ExamQuestion ExamQuestion)
        {
            _examQuestionsDal.Insert(ExamQuestion);
        }

        public void Delete(ExamQuestion ExamQuestion)
        {
            _examQuestionsDal.Delete(ExamQuestion);
        }

        public ExamQuestion GetById(int id)
        {
            return _examQuestionsDal.Get(x => x.ExamID == id);
        }

        public List<ExamQuestion> GetByIdList(int id)
        {
            return _examQuestionsDal.WhrList(x => x.ExamID == id);
        }


        public List<ExamQuestion> List()
        {
           return _examQuestionsDal.List();
        }

        public void Update(ExamQuestion ExamQuestion)
        {
            _examQuestionsDal.Update(ExamQuestion);
        }

        public List<ExamQuestion> WhereList()
        {
            throw new NotImplementedException();
        }
    }
}
