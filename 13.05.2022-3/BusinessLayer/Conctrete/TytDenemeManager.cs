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
    public class TytDenemeManager : ITytDenemeService

    {

        ITytDenemeDal _tytDenemeDal;

        public TytDenemeManager(ITytDenemeDal tytDenemeDal)
        {
            _tytDenemeDal = tytDenemeDal;
        }

        public TytDeneme GetByID(int id)
        {
            return _tytDenemeDal.Get(x => x.ID == id);
        }

        public TytDeneme GetByToplamNet(int value)
        {
            return _tytDenemeDal.Get(x => x.TopNet == value);
        }

        public TytDeneme GetBySession(string session)
        {
            throw new NotImplementedException();
        }

        public List<TytDeneme> GetList()
        {
            return _tytDenemeDal.List();
        }
        public List<TytDeneme> GetListStudentWhere(int id)
        {
            return _tytDenemeDal.WhrList(x => x.StudentID == id);
        }

    

        public void WAdd(TytDeneme TytDeneme)
        {
            _tytDenemeDal.Insert(TytDeneme);
        }

        public void WDelete(TytDeneme TytDeneme)
        {
            _tytDenemeDal.Delete(TytDeneme);
        }

        public void WUpdate(TytDeneme TytDeneme)
        {
            _tytDenemeDal.Update(TytDeneme);
        }
    }
}
