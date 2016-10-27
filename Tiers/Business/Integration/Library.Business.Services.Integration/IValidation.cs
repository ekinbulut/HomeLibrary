using Library.Business.Services.Integration.Model;

namespace Library.Business.Services.Integration
{
    public interface IValidation
    {
        bool IsEmpty(ImportObject data);
    }
}