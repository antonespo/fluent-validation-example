using Autofac;
using FluentValidation;

namespace FluentValidationExample.Autofac;

public static class AutofacExtension
{
    public static void RegisterValidators(this ContainerBuilder builder)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.RegisterAssemblyTypes(assemblies)
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
            .AsImplementedInterfaces();
    }
}
