using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");


            RuleFor(x => x.Message).MaximumLength(250).WithMessage("Bu Kısım Maximum 250 karakter alabilir ");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Maximum 50 karakter");
            RuleFor(x => x.UserMail).MaximumLength(50).WithMessage("Maximum 50 karakter");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Maximum 50 karakter");
        }
    }
}
