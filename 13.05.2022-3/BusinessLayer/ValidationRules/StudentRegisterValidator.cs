using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentRegisterValidator:AbstractValidator<Student>
    {
        public StudentRegisterValidator()
        {
            RuleFor(x => x.StudentTitle).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentPassword).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentEmail).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentImage).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentSurname).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");

            RuleFor(x => x.StudentTitle).MaximumLength(15).WithMessage("Maximum 15 karakter kullanın");
            RuleFor(x => x.StudentName).MaximumLength(8).WithMessage("Maximum 8 karakter kullanın");
         
            RuleFor(x => x.StudentEmail).MaximumLength(40).WithMessage("Maximum 40 karakter kullanın");
            RuleFor(x => x.StudentImage).MaximumLength(150).WithMessage("Maximum 150 karakter kullanın");
            RuleFor(x => x.StudentSurname).MaximumLength(15).WithMessage("Maximum 15 karakter kullanın");
        }
    }
}
