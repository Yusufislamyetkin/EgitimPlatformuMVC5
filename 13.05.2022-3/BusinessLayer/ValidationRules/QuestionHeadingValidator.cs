using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class QuestionHeadingValidator:AbstractValidator<Heading>
    {
        public QuestionHeadingValidator()
        {
            RuleFor(x => x.HeadingFirstContent).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");

            RuleFor(x => x.HeadingFirstContent).MaximumLength(100).WithMessage("Maximum 100 karakter kullanın");
            RuleFor(x => x.HeadingName).NotEmpty().MaximumLength(50).WithMessage("Maximum 50 karakter kullanın");



        }
    }
}
