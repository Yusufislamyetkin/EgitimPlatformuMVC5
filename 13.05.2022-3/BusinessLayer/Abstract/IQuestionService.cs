using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IQuestionService
    {
        List<Questions> GetList();
        void AddValue(Questions p);
        Questions GetByID(int id);
        void QuestionsDelete(Questions Questions);
        void QuestionsUpdate(Questions Questions);
        List<Questions> WhereList(int id);
    }
}
