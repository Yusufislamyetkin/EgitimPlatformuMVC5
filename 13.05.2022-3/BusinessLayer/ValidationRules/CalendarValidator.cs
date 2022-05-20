using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CalendarValidator:AbstractValidator<calendar>
    {
        public CalendarValidator()
        {
            RuleFor(x => x.CalendarDate).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.CalenderContent).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");

         
            RuleFor(x => x.CalenderContent).MaximumLength(250).WithMessage("Maximum 250 karakter");

        }
    }
}
