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
    public class CalendarManager : ICalendarService
    {
        ICalendarDal _calendarDal;

        public CalendarManager(ICalendarDal calendarDal)
        {
            _calendarDal = calendarDal;
        }

        public void AddValue(calendar p)
        {
            _calendarDal.Insert(p);
        }

        public void calendarDelete(calendar calendar)
        {
            _calendarDal.Delete(calendar);
        }

        public void calendarUpdate(calendar calendar)
        {
            _calendarDal.Update(calendar);
        }

        public calendar GetByID(int id)
        {
          return  _calendarDal.Get( x=> x.calendarID == id);
        }

        public List<calendar> GetByIDStudent(int id)
        {
            return _calendarDal.WhrList(x => x.StudentID == id);
        }

        public List<calendar> GetByIDStudentFalse(int id)
        {
            return _calendarDal.WhrList(x => x.StudentID == id && x.CalendarStatus == false);
        }

        public List<calendar> GetByIDStudentTrue(int id)
        {
            return _calendarDal.WhrList(x => x.StudentID == id && x.CalendarStatus == true);
        }

        public List<calendar> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
