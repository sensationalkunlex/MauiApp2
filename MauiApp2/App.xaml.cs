using MauiApp2.Handler;
using Microsoft.Maui.Platform;

namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntryExtension), (handler, view) =>
            {
                if (view is BorderlessEntryExtension)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());

#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
                }
            });


            MainPage = new AppShell();
        }
    }
}
