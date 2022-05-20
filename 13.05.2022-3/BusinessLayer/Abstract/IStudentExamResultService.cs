using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IStudentExamResultService
    {
        StudentExamResult GetById(int id);
        List<StudentExamResult> List();
      

        void Add(StudentExamResult StudentExamResult);
        void Delete(StudentExamResult StudentExamResult);
        List<StudentExamResult> WhereList(StudentExamResult StudentExamResult);

        void Update(StudentExamResult StudentExamResult);
    }
}
