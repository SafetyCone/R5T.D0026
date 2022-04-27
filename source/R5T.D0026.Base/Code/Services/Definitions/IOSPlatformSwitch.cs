using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0026
{
    [ServiceDefinitionMarker]
    public interface IOSPlatformSwitch : IServiceDefinition
    {
        void Switch(Action windowsAction, Action osxAction, Action linuxAction);
        Task SwitchAsync(Func<Task> windowsActionAsync, Func<Task> osxActionAsync, Func<Task> linuxActionAsync);
    }
}
