using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ControleLancamento.Api.Api.DependencyMap
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var config = AutoMapperConfig.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
