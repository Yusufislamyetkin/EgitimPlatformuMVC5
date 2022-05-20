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
    public class StudentLoginManager : IStudentLoginService
    {
        IStudentLoginDal _studentLoginDal;

        public StudentLoginManager(IStudentLoginDal studentLoginDal)
        {
            _studentLoginDal = studentLoginDal;
        }

        public Student GetByStudentId(int id)
        {
          return _studentLoginDal.Get(x => x.StudentID == id);
        }

        public Student GetByStudentLogin(Student student)
        {
            return _studentLoginDal.Get(x => x.StudentEmail == student.StudentEmail & x.StudentPassword == student.StudentPassword);
        }

        public Student GetByStudentUsername(string username)
        {
            return _studentLoginDal.Get(x => x.StudentEmail == username);
        }

        public List<Student> WhereStudentList()
        {
            throw new NotImplementedException();
        }

        public void StudentAdd(Student student)
        {
            throw new NotImplementedException();
        }

        public void StudentDelete(Student writer)
        {
            throw new NotImplementedException();
        }

        public List<Student> StudentList()
        {
            throw new NotImplementedException();
        }

        public void StudentUpdate(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
