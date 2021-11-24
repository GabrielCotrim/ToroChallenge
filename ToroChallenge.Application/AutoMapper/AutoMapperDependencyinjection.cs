using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ToroChallenge.Application.AutoMapper.Mappings;

namespace ToroChallenge.Application.AutoMapper
{
    public static class AutoMapperDependencyinjection
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
