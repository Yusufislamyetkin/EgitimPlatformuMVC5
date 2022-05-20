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
    public class StudentCourseFallowManager : IStudentCourseFallowService
    {
        IStudentCourseFallowDal _studentCourseFallowDal;

        public StudentCourseFallowManager(IStudentCourseFallowDal studentCourseFallowDal)
        {
            _studentCourseFallowDal = studentCourseFallowDal;
        }

        public void Add(CourseFallow CourseFallow)
        {
            _studentCourseFallowDal.Insert(CourseFallow);
        }

        public List<CourseFallow> AYTBİYOKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTBİYO" & x.StudentID == id);
        }

        public List<CourseFallow> AYTCOGwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTCOG" & x.StudentID == id);
        }

        public List<CourseFallow> AYTDİNKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTDİN" & x.StudentID == id);
        }

        public List<CourseFallow> AYTEDEBwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTEDEB" & x.StudentID == id);
        }

        public List<CourseFallow> AYTFELwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTFEL" & x.StudentID == id);
        }

        public List<CourseFallow> AYTFİZKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTFİZ" & x.StudentID == id);
        }

        public List<CourseFallow> AYTGEOKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTGEO" & x.StudentID == id);
        }

        public List<CourseFallow> AYTKİMwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTKİM" & x.StudentID == id);
        }

        public List<CourseFallow> AYTMATKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTMAT" & x.StudentID == id);
        }

        public List<CourseFallow> AYTTARwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "AYTTAR" & x.StudentID == id);
        }

        public void Delete(CourseFallow CourseFallow)
        {
            _studentCourseFallowDal.Delete(CourseFallow);
        }

        public CourseFallow GetByID(int id)
        {
            return _studentCourseFallowDal.Get(x => x.ID == id);
        }

        public CourseFallow GetByLesson(string lesson)
        {
            throw new NotImplementedException();
        }

        public CourseFallow GetBySession(string session)
        {
            throw new NotImplementedException();
        }

        public List<CourseFallow> GetList()
        {
            return _studentCourseFallowDal.List();
        }

        public void LessonFinished(CourseFallow courseFallow)
        {

            courseFallow.Durum = true;
            _studentCourseFallowDal.Update(courseFallow);

        }
        public void LessonNotFinished(CourseFallow courseFallow)
        {

            courseFallow.Durum = false;
            _studentCourseFallowDal.Update(courseFallow);

        }

        public List<CourseFallow> TYTBİYOKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTBİYO" & x.StudentID == id);
        }

        public List<CourseFallow> TYTCOGwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTCOG" & x.StudentID == id);
        }

        public List<CourseFallow> TYTDİNKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTDİN" & x.StudentID == id);
        }

        public List<CourseFallow> TYTFELwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTFEL" & x.StudentID == id);
        }

        public List<CourseFallow> TYTFİZKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTFİZ" & x.StudentID == id);
        }

        public List<CourseFallow> TYTGEOKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTGEO" & x.StudentID == id);
        }

        public List<CourseFallow> TYTKİMwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTKİM" & x.StudentID == id);
        }

        public List<CourseFallow> TYTMATKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTMAT" & x.StudentID == id);
        }

        public List<CourseFallow> TYTTARwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTTAR" & x.StudentID == id);
        }

        public List<CourseFallow> TYTTURKwhereList(int id)
        {
            return _studentCourseFallowDal.WhrList(x => x.Ders == "TYTTURK" & x.StudentID == id);
        }

        public void Update(CourseFallow CourseFallow)
        {
            _studentCourseFallowDal.Update(CourseFallow);
        }
    }
}
