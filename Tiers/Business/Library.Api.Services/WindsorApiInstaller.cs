﻿using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Library.Data;
using Library.Data.Repositories.Books;
using Library.Data.Repositories.Users;
using SenseFramework.Data.EntityFramework.Context;

namespace Library.Api.Services
{
    public class WindsorApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<BaseContext>().ImplementedBy<LibraryContext>());

            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepository>());
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest());

            //container.Register(Component.For<IBookApiController>().ImplementedBy<BookApiController>());

        }
    }
}