#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
namespace NetflixClone
{
    public partial class App : Application
    {
        public App()
        {
            const int WindowWidth = 540;
            const int WindowHeight = 1000;
            InitializeComponent();
#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId Id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(Id);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            });
#endif

            MainPage = new AppShell();
        }
    }
}
