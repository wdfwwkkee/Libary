using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using UsmanovBochkarevKhayrullin.ViewModels;
using UsmanovBochkarevKhayrullin.Views;

namespace UsmanovBochkarevKhayrullin
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {   
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainWindowViewModel(mainWindow);
                    desktop.MainWindow = mainWindow;
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}