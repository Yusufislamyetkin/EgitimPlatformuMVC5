using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IAboutUsService
    {
        void add(AboutUs AboutUs);
        void update(AboutUs AboutUs);
        AboutUs GetById();


    }
}
