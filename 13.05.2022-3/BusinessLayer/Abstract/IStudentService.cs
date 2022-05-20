using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        Student GetByID(int id);
        Student GetBySession(string session);
        List<Student> GetList();
        void WAdd(Student w);
        void WDelete(Student w);
        void WUpdate(Student w);

    }
}
