using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentCourseService
    {
        Course GetByID(int id);
        Course GetByLesson(string lesson);
        Course GetBySession(string session);
        List<Course> GetList();
        void WAdd(Course Course);
        void WDelete(Course Course);
        void WUpdate(Course Course);

    }
}
