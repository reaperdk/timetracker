using System.Windows;
using TimeTrakcer.Wpf.ViewModel;
using TimeTrakcer.Wpf.View;

namespace TimeTrakcer.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new ViewModel.ViewModel();
            var view = new MainWindow();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
