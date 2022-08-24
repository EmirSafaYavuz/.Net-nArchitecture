using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Features.Brands.Rules;

namespace RentACar.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<BrandBusinessRules>();

        return services;
    }
}