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
    public class ExamQuestionFollowManager : IExamQuestionsFollow
    {
        IExamQuestionFollowDal _examQuestionFollow;

        public ExamQuestionFollowManager(IExamQuestionFollowDal examQuestionFollow)
        {
            _examQuestionFollow = examQuestionFollow;
        }

        public void Add(ExamQuestionFollow ExamQuestionFollow)
        {
            _examQuestionFollow.Insert(ExamQuestionFollow);
        }

        public void Delete(ExamQuestionFollow ExamQuestionFollow)
        {
            _examQuestionFollow.Delete(ExamQuestionFollow);
        }
        
      

        public ExamQuestionFollow GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExamQuestionFollow> List()
        {
          return  _examQuestionFollow.List();
        }

        public void Update(ExamQuestionFollow ExamQuestionFollow)
        {
            _examQuestionFollow.Update(ExamQuestionFollow);
        }

        public List<ExamQuestionFollow> WhereList(int id)
        {
            return _examQuestionFollow.WhrList(x => x.ExamQuestion.ExamID == id);
        }
    }
}
