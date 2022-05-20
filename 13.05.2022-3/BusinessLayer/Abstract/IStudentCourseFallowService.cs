using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IStudentCourseFallowService
    {
        CourseFallow GetByID(int id);
        CourseFallow GetByLesson(string lesson);
        CourseFallow GetBySession(string session);
        List<CourseFallow> GetList();
        void LessonFinished(CourseFallow courseFallow);
        void LessonNotFinished(CourseFallow courseFallow);


        List<CourseFallow> TYTTURKwhereList(int id);
        List<CourseFallow> TYTBİYOKwhereList(int id);
        List<CourseFallow> TYTCOGwhereList(int id);
        List<CourseFallow> TYTDİNKwhereList(int id);
        List<CourseFallow> TYTFELwhereList(int id);
        List<CourseFallow> TYTFİZKwhereList(int id);
        List<CourseFallow> TYTGEOKwhereList(int id);
        List<CourseFallow> TYTKİMwhereList(int id);
        List<CourseFallow> TYTMATKwhereList(int id);
        List<CourseFallow> TYTTARwhereList(int id);


        List<CourseFallow> AYTEDEBwhereList(int id);
        List<CourseFallow> AYTBİYOKwhereList(int id);
        List<CourseFallow> AYTCOGwhereList(int id);
        List<CourseFallow> AYTDİNKwhereList(int id);
        List<CourseFallow> AYTFELwhereList(int id);
        List<CourseFallow> AYTFİZKwhereList(int id);
        List<CourseFallow> AYTGEOKwhereList(int id);
        List<CourseFallow> AYTKİMwhereList(int id);
        List<CourseFallow> AYTMATKwhereList(int id);
        List<CourseFallow> AYTTARwhereList(int id);

        void Add(CourseFallow CourseFallow);
        void Delete(CourseFallow CourseFallow);
        void Update(CourseFallow CourseFallow);
    }
}
