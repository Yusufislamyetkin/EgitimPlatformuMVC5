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
    public class StudentManager : IStudentService
    {
        IStudentDal _StudentDal;

        public StudentManager(IStudentDal StudentDal)
        {
            _StudentDal = StudentDal;
        }

        public Student GetByID(int id)
        {
            return _StudentDal.Get(x => x.StudentID == id);
        }

        public Student GetBySession(string session)
        {
            return _StudentDal.Get(x => x.StudentEmail == session);
        }
    
        public List<Student> GetList()
        {
            return _StudentDal.List();
        }

        public void WAdd(Student w)
        {
            _StudentDal.Insert(w);
        }

        public void WDelete(Student w)
        {
            _StudentDal.Delete(w);
        }

        public void WUpdate(Student w)
        {
            _StudentDal.Update(w);
        }
    }
}
