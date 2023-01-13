using Autofac;
using FluentValidationExample.Autofac;

namespace FluentValidationExample;

public static class AutofacConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterValidators();
        return builder.Build();
    }
}