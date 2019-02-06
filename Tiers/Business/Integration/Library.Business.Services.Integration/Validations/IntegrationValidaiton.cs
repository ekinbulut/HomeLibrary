using FluentValidation;
using Library.Business.Services.Integration.Model;

namespace Library.Business.Services.Integration.Validations
{
    public class ImportObjectValidaiton : AbstractValidator<ImportObject>
    {
        public ImportObjectValidaiton()
        {
            RuleFor(t => t.BookName).Null();
            RuleFor(t => t.Publishdate).Null();
            RuleFor(t => t.GenreName).Null();
        }
    }
}
