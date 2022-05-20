using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITytDenemeService
    {
        TytDeneme GetByID(int id);
        TytDeneme GetBySession(string session);
        List<TytDeneme> GetList();
        List<TytDeneme> GetListStudentWhere(int id);
        TytDeneme GetByToplamNet(int value);
        void WAdd(TytDeneme TytDeneme);
        void WDelete(TytDeneme TytDeneme);
        void WUpdate(TytDeneme TytDeneme);
    }
}
