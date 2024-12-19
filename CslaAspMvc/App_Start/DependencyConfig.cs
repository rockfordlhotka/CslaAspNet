using Csla.Configuration;
using CslaAspMvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

public static class DependencyConfig
{
    public static IServiceProvider Configure()
    {
        var services = new ServiceCollection();

        // Register your services here
        services.AddCsla();
        services.AddSingleton<Csla.Core.IContextManager, Csla.Web.Mvc.ApplicationContextManager>();
        services.AddTransient<HomeController>();


        var serviceProvider = services.BuildServiceProvider();

        // Set the dependency resolver for MVC
        DependencyResolver.SetResolver(new DefaultDependencyResolver(serviceProvider));

        return serviceProvider;
    }
}

public class DefaultDependencyResolver : IDependencyResolver
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultDependencyResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object GetService(Type serviceType)
    {
        return _serviceProvider.GetService(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        return _serviceProvider.GetServices(serviceType);
    }
}
