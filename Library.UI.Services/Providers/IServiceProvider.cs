using Library.Business.Services.Authantication;
using Library.Business.Services.Book;
using Library.Business.Services.Integration;
using Library.Business.Services.Provider;

namespace Library.UI.Services.Providers
{
    public interface IServiceProvider
    {
        IBookService BookService { get; };
        IAuthenticationService AuthenticationService { get; };
        IIntegrationService IntegrationService { get; };
        IItemProvider ItemsProvider { get; };
    }
}