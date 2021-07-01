using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("Kategori adı en az 4 karakter uzunluğunda olabilir");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter uzunluğunda olabilir");

        }
    }
}
