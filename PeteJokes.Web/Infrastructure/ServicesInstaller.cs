using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MediatR;
using PeteJokes.Queries;

namespace PeteJokes.Web.Infrastructure
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMediator>()
                    .ImplementedBy<Mediator>()
                    .LifestylePerWebRequest(),

                Component.For<SingleInstanceFactory>()
                    .UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t))
                    .LifestylePerWebRequest(),

                Component.For<MultiInstanceFactory>()
                    .UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t))
                    .LifestylePerWebRequest(),

                Classes.FromAssemblyContaining<RecentJokesQuery>()
                    .BasedOn(typeof(IRequestHandler<,>))
                    .WithServiceBase()
                    .LifestylePerWebRequest(),

                Classes.FromAssemblyContaining<RecentJokesQuery>()
                    .BasedOn(typeof(IAsyncRequestHandler<,>))
                    .WithServiceBase()
                    .LifestylePerWebRequest()
                );
            
        }
    }
}