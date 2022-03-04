using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaton
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(p => p.ContentMain).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Category).NotEmpty();
            RuleFor(p => p.ContentSummary).NotEmpty();
        }
    }
}
