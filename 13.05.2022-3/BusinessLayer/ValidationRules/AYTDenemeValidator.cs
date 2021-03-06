using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AYTDenemeValidator:AbstractValidator<AytDeneme>
    {
        public AYTDenemeValidator()
        {
            RuleFor(x => x.FenNet).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.EdebNet).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.SosNet).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.MatNet).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.Puan).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");


            RuleFor(x => x.Yayın).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
        }
    }
}
