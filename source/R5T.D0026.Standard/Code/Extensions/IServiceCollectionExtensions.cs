using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0024;
using R5T.D0024.Default;
using R5T.D0025.Default;
using R5T.D0026.Default;

using R5T.Dacia;

using IParameterizedOSPlatformSwitch = R5T.D0025.IOSPlatformSwitch;


namespace R5T.D0026.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static (
            IServiceAction<IOSPlatformSwitch> OSPlatformSwitchOptionAction,
            IServiceAction<IOSPlatformProvider> OSPlatformProviderAction,
            IServiceAction<IParameterizedOSPlatformSwitch> ParameterizedOSPlatformSwitchAction
            )
            AddOSPlatformSwitchAction(this IServiceCollection services)
        {
            // 0.
            var oSPlatformProviderAction = services.AddOSPlatformProviderAction();
            var parameterizedOSPlatformSwitchAction = R5T.D0025.Default.IServiceCollectionExtensions.AddOSPlatformSwitchAction(services);

            // 1.
            var oSPlatformSwitchOptionAction = services.AddOSPlatformSwitchAction(oSPlatformProviderAction, parameterizedOSPlatformSwitchAction);

            return (
                oSPlatformSwitchOptionAction,
                oSPlatformProviderAction,
                parameterizedOSPlatformSwitchAction);
        }

        public static IServiceCollection AddOSPlatformSwitch(this IServiceCollection services)
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var addOSPlatformSwitchAction = services.AddOSPlatformSwitchAction();
#pragma warning restore IDE0042 // Deconstruct variable declaration

            services.Run(addOSPlatformSwitchAction.OSPlatformSwitchOptionAction); // Only need to run this action.

            return services;
        }
    }
}
