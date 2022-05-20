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
    public class StudentExamResultManager : IStudentExamResultService
    {
        IStudentExamResultDal _StudentExamResultDal;

        public StudentExamResultManager(IStudentExamResultDal studentExamResultDal)
        {
            _StudentExamResultDal = studentExamResultDal;
        }

        public void Add(StudentExamResult StudentExamResult)
        {
            _StudentExamResultDal.Insert(StudentExamResult);
        }

        public void Delete(StudentExamResult StudentExamResult)
        {
            _StudentExamResultDal.Delete(StudentExamResult);
        }

        public StudentExamResult GetById(int id)
        {
           return _StudentExamResultDal.Get(x => x.ExamID == id );
        }



        public StudentExamResult GetByIdforDelete(StudentExamResult studentExamResults)
        {
            return _StudentExamResultDal.Get(x => x.ExamID == studentExamResults.ExamID & x.StudentID == studentExamResults.StudentID );
        }

        public List<StudentExamResult> List()
        {
            return _StudentExamResultDal.List();
        }

        public List<StudentExamResult> ListForStudent(int id)
        {
            return _StudentExamResultDal.WhrList(x => x.StudentID == id);
        }

        public void Update(StudentExamResult StudentExamResult)
        {
            _StudentExamResultDal.Update(StudentExamResult);
        }

        public List<StudentExamResult> WhereList(StudentExamResult StudentExamResult)
        {
            return _StudentExamResultDal.WhrList(x => x.ExamID == StudentExamResult.ExamID & x.StudentID == StudentExamResult.StudentID);
        }
    }
}
