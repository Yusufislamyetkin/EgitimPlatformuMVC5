using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IExamService
    {
        List<Exam> GetList();
        void AddValue(Exam p);
        Exam GetByID(int id);
        void ExamDelete(Exam exam);
        void ExamUpdate(Exam exam);
         List<Exam> GetListWhere(int id);
    }
}
