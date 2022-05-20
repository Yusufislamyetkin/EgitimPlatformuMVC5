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
    public class StudentCourseManager : IStudentCourseService
    {
        IStudentCourseDal _CourseDal;

        public StudentCourseManager(IStudentCourseDal courseDal)
        {
            _CourseDal = courseDal;
        }

        public Course GetByID(int id)
        {
            return _CourseDal.Get(x => x.ID == id);
        }

        public Course GetByLesson(string lesson)
        {
            return _CourseDal.Get(x => x.Ders == lesson);
        }

        public Course GetBySession(string session)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetList()
        {
            return _CourseDal.List();
        }

        public void WAdd(Course Course)
        {
            _CourseDal.Insert(Course);
        }

        public void WDelete(Course Course)
        {
            _CourseDal.Delete(Course);
        }

        public void WUpdate(Course Course)
        {
            _CourseDal.Update(Course);
        }
    }
}
