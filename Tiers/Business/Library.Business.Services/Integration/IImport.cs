using Library.Business.Services.Integration.Dtos;

namespace Library.Business.Services.Integration
{
    public interface IImport
    {
        bool Import(ImportInputDto input);
    }
}