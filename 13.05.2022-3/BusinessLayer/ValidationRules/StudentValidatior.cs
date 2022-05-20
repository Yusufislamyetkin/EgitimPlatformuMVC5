using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class StudentValidatior : AbstractValidator<Student>
    {
        public StudentValidatior()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Bu Kısım Boş Bırakılamaz");
            RuleFor(x => x.StudentSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz");
            RuleFor(x => x.StudentEmail).NotEmpty().WithMessage("Yazar Mail Boş Bırakılamaz");
            RuleFor(x => x.StudentAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmı Boş Bırakılamaz");

            RuleFor(x => x.StudentName).MinimumLength(2).WithMessage("Yazar Adı Minimum 2 Karakter Olmak Zorundadır");
            RuleFor(x => x.StudentSurname).MinimumLength(2).WithMessage("Yazar Soyadı  Minimum 2 Karakter Olmak Zorundadır");
            RuleFor(x => x.StudentEmail).EmailAddress().WithMessage("Yazar Mail Girişi Hatalı");
            RuleFor(x => x.StudentAbout).MaximumLength(25).WithMessage("Yazar Hakkında Kısmı Maksimum 25 Karakter Olabilir");


        }
    }
}
