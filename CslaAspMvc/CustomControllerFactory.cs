using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Extensions.DependencyInjection;

public class CustomControllerFactory : DefaultControllerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CustomControllerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
        if (controllerType == null)
            return null;

        return (IController)_serviceProvider.GetService(controllerType) ?? base.GetControllerInstance(requestContext, controllerType);
    }
}
