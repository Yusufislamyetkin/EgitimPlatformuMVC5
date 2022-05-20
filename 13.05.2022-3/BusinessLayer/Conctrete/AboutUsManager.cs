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
   public class AboutUsManager: IAboutUsService
    {
        IAboutUsDal _aboutUs;

        public AboutUsManager(IAboutUsDal aboutUs)
        {
            _aboutUs = aboutUs;
        }

        public void add(AboutUs AboutUs)
        {
            _aboutUs.Insert(AboutUs);
        }

        public AboutUs GetById()
        {
            return _aboutUs.Get(x => x.AboutUsID == 1);
        }

        public void update(AboutUs AboutUs)
        {
            _aboutUs.Update(AboutUs);
        }
    }
}
