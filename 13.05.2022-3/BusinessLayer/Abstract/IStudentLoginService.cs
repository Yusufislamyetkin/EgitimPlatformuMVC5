using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IStudentLoginService
    {
        Student GetByStudentId(int id);
        Student GetByStudentLogin(Student student);
        Student GetByStudentUsername(string username);
        List<Student> StudentList();
        List<Student> WhereStudentList();
        void StudentAdd(Student student);
        void StudentDelete(Student student);
        void StudentUpdate(Student student);

    }
}
