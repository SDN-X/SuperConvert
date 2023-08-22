using Microsoft.Extensions.DependencyInjection;

namespace SuperConvert.Abstraction.Extensions
{
    public static class SuperConvertAbstractionExtensions
    {
        /// <summary>
        /// registering excel service in the DI container in order to use it later
        /// </summary>
        /// <param name="serviceContainer"></param>
        /// <returns></returns>
        public static IServiceCollection UseSuperConvertExcelService(this IServiceCollection serviceContainer)
        {
            serviceContainer.AddSingleton<ISuperConvertExcelService, SuperConvertExcelService>();
            return serviceContainer;
        }
    }
}