using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
   public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım arkadaşı ismini boş geçemezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev kısmını boş geçemezsiniz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez");
            RuleFor(x => x.PersonName).Length(0, 50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapın");
            RuleFor(x => x.Title).Length(0, 50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapın");
        }
    }
}

