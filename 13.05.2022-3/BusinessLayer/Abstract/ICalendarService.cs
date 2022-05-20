using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface ICalendarService
    {
        List<calendar> GetList();
        void AddValue(calendar p);
        calendar GetByID(int id);
        List<calendar> GetByIDStudent(int id);
        List<calendar> GetByIDStudentTrue(int id);
        List<calendar> GetByIDStudentFalse(int id);
        void calendarDelete(calendar calendar);
        void calendarUpdate(calendar calendar);
    }
}
