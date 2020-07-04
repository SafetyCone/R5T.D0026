using System;
using System.Threading.Tasks;


namespace R5T.D0026
{
    public interface IOSPlatformSwitch
    {
        void Switch(Action windowsAction, Action osxAction, Action linuxAction);
        Task SwitchAsync(Func<Task> windowsActionAsync, Func<Task> osxActionAsync, Func<Task> linuxActionAsync);
    }
}
