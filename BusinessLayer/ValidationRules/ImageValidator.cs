using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
   public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlığını boş geçemezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel açıklamasını boş geçemezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel yolunu boş geçemezsiniz");
        }
    }
}
