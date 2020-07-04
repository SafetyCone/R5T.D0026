using System;
using System.Threading.Tasks;


namespace R5T.D0026
{
    public static class IOSPlatformSwitchExtensions
    {
        public static T Switch<T>(this IOSPlatformSwitch oSPlatformSwitch, Func<T> windowsFunc, Func<T> osxFunc, Func<T> linuxFunc)
        {
            var output = default(T);

            void WindowsAction()
            {
                output = windowsFunc();
            }

            void OsxAction()
            {
                output = osxFunc();
            }

            void LinuxAction()
            {
                output = linuxFunc();
            }

            oSPlatformSwitch.Switch(WindowsAction, OsxAction, LinuxAction);

            return output;
        }

        public static Task<T> SwitchAsync<T>(this IOSPlatformSwitch oSPlatformSwitch, Func<Task<T>> windowsFuncAsync, Func<Task<T>> osxFuncAsync, Func<Task<T>> linuxFuncAsync)
        {
            Task<T> output = default;

            Task WindowsActionAsync()
            {
                output = windowsFuncAsync();

                return Task.CompletedTask;
            }

            Task OsxActionAsync()
            {
                output = osxFuncAsync();

                return Task.CompletedTask;
            }

            Task LinuxActionAsync()
            {
                output = linuxFuncAsync();

                return Task.CompletedTask;
            }

            oSPlatformSwitch.Switch(WindowsActionAsync, OsxActionAsync, LinuxActionAsync); // Synchronous.

            return output;
        }
    }
}
