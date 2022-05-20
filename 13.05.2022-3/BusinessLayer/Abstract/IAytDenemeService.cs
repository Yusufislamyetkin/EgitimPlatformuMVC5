using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAytDenemeService
    {
        AytDeneme GetByID(int id);
        AytDeneme GetBySession(string session);
        List<AytDeneme> GetList();
        List<AytDeneme> GetListStudentWhere(int id);
        void WAdd(AytDeneme AytDeneme);
        void WDelete(AytDeneme AytDeneme);
        void WUpdate(AytDeneme AytDeneme);
    }
}
