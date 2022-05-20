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
    public class ExamManager : IExamService
    {
        IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public void AddValue(Exam p)
        {
            _examDal.Insert(p);  
        }

        public void ExamDelete(Exam exam)
        {
            _examDal.Delete(exam);
        }

        public void ExamUpdate(Exam exam)
        {
            _examDal.Update(exam);
        }

        public Exam GetByID(int id)
        {
            return _examDal.Get(x => x.ExamID == id);
        }

        public List<Exam> GetList()
        {
            return _examDal.List();
        }
      
        public List<Exam> GetListWhere(int id)
        {
            return _examDal.WhrList(x => x.ExamID == id);

        }
        public List<Exam> AYTBİYOKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 4);
        }

        public List<Exam> AYTCOGwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 5);
        }

        public List<Exam> AYTDİNKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 6);
        }

        public List<Exam> AYTEDEBwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 7);
        }

        public List<Exam> AYTFELwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 8);
        }

        public List<Exam> AYTFİZKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 9);
        }

        public List<Exam> AYTGEOKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 10);
        }

        public List<Exam> AYTKİMwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 11);
        }

        public List<Exam> AYTMATKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 12);
        }

        public List<Exam> AYTTARwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 13);
        }

        public List<Exam> TYTBİYOKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 14);
        }

        public List<Exam> TYTCOGwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 15);
        }

        public List<Exam> TYTDİNKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 16);
        }

        public List<Exam> TYTTURKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 24);
        }

        public List<Exam> TYTFELwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 17);
        }

        public List<Exam> TYTFİZKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 18);
        }

        public List<Exam> TYTGEOKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 19);
        }

        public List<Exam> TYTKİMwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 20);
        }

        public List<Exam> TYTMATKwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 21);
        }

        public List<Exam> TYTTARwhereList()
        {
            return _examDal.WhrList(x => x.CategoryID == 23);
        }



    }
}
