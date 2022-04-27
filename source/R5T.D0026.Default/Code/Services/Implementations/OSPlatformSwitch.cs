using System;
using System.Threading.Tasks;

using R5T.D0024;

using IParameterizedOSPlatformSwitch = R5T.D0025.IOSPlatformSwitch;using R5T.T0064;


namespace R5T.D0026.Default
{[ServiceImplementationMarker]
    public class OSPlatformSwitch : IOSPlatformSwitch,IServiceImplementation
    {
        private IOSPlatformProvider OSPlatformProvider { get; }
        private IParameterizedOSPlatformSwitch ParameterizedOSPlatformSwitch { get; }


        public OSPlatformSwitch(
            IOSPlatformProvider oSPlatformProvider,
            IParameterizedOSPlatformSwitch parameterizedOSPlatformSwitch)
        {
            this.OSPlatformProvider = oSPlatformProvider;
            this.ParameterizedOSPlatformSwitch = parameterizedOSPlatformSwitch;
        }

        public void Switch(Action windowsAction, Action osxAction, Action linuxAction)
        {
            var oSPlatform = this.OSPlatformProvider.GetOSPlatform();

            this.ParameterizedOSPlatformSwitch.Switch(oSPlatform, windowsAction, osxAction, linuxAction);
        }

        public Task SwitchAsync(Func<Task> windowsActionAsync, Func<Task> osxActionAsync, Func<Task> linuxActionAsync)
        {
            var oSPlatform = this.OSPlatformProvider.GetOSPlatform();

            var task = this.ParameterizedOSPlatformSwitch.SwitchAsync(oSPlatform, windowsActionAsync, osxActionAsync, linuxActionAsync);
            return task;
        }
    }
}
