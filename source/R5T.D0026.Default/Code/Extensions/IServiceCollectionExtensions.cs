using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0024;

using R5T.Dacia;

using IParameterizedOSPlatformSwitch = R5T.D0025.IOSPlatformSwitch;


namespace R5T.D0026.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="OSPlatformSwitch"/> implementation of <see cref="IOSPlatformSwitch"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOSPlatformSwitch(this IServiceCollection services,
            IServiceAction<IOSPlatformProvider> oSPlatformProviderAction,
            IServiceAction<IParameterizedOSPlatformSwitch> parameterizedOSPlatformSwitchAction)
        {
            services
                .AddSingleton<IOSPlatformSwitch, OSPlatformSwitch>()
                .Run(oSPlatformProviderAction)
                .Run(parameterizedOSPlatformSwitchAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="OSPlatformSwitch"/> implementation of <see cref="IOSPlatformSwitch"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOSPlatformSwitch> AddOSPlatformSwitchAction(this IServiceCollection services,
            IServiceAction<IOSPlatformProvider> oSPlatformProviderAction,
            IServiceAction<IParameterizedOSPlatformSwitch> parameterizedOSPlatformSwitchAction)
        {
            var serviceAction = ServiceAction.New<IOSPlatformSwitch>(() => services.AddOSPlatformSwitch(
                oSPlatformProviderAction,
                parameterizedOSPlatformSwitchAction));

            return serviceAction;
        }
    }
}
