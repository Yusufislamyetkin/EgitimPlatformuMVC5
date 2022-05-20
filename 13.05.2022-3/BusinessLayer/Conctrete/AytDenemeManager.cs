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
    public class AytDenemeManager : IAytDenemeService
    {
        IAytDenemeDal _aytDenemeDal;

        public AytDenemeManager(IAytDenemeDal aytDenemeDal)
        {
            _aytDenemeDal = aytDenemeDal;
        }

        public AytDeneme GetByID(int id)
        {
            return _aytDenemeDal.Get(x => x.ID == id);
        }

        public AytDeneme GetBySession(string session)
        {
            throw new NotImplementedException();
        }

        public List<AytDeneme> GetList()
        {
            return _aytDenemeDal.List();
        }
        public List<AytDeneme> GetListStudentWhere(int id)
        {
            return _aytDenemeDal.WhrList(x => x.StudentID == id);
        }

        public void WAdd(AytDeneme AytDeneme)
        {
            _aytDenemeDal.Insert(AytDeneme);
        }

        public void WDelete(AytDeneme AytDeneme)
        {
            _aytDenemeDal.Delete(AytDeneme);
        }

        public void WUpdate(AytDeneme AytDeneme)
        {
            _aytDenemeDal.Update(AytDeneme);
        }
    }
}
