using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        List<Content> GetWhereList(int id);
        List<Content> GetWhereStudentList(string session);
        List<Content> GetList();
        void ContentAdd(Content content);
        void ContentStatus(Content content);
        void ContentUpdate(Content content);
        Content getByID(int id);
      
    }
}
