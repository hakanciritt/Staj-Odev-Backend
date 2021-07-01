using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık alanı minimum 5 karakter uzunluğunda olabilir");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık alanı maximum 100 karakter uzunluğunda olabilir");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");
            RuleFor(x => x.Body).NotEmpty().WithMessage("İçerik alanı boş geçilemez");
            RuleFor(x => x.Body).MinimumLength(50).WithMessage("İçerik minimux 50 karakter uzunluğunda olmalıdır");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
        }
    }
}
