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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentStatus(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content getByID(int id)
        {
            return _contentDal.Get(x => x.HeadingID == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetWhereList(int id)
        {
            return _contentDal.WhrList(x => x.HeadingID == id);
        }
        public List<Content> GetWhereStudentList(int id)
        {
            return _contentDal.WhrList(x => x.StudentID == id);
        }
        public List<Content> GetWhereStudentList(string session)
        {
            return _contentDal.WhrList(x => x.Student.StudentEmail == session);
        }

    }
}
