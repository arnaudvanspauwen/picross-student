using System.Windows;
using ViewModel;


namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var mainWindow = new MainWindow();

            MainWindowViewModel vm = new MainWindowViewModel();
            vm.Close += MainViewModel_ApplicationExit;
            mainWindow.DataContext = vm;
            mainWindow.Show();


            vm.Close += MainViewModel_ApplicationExit;

            mainWindow.DataContext = vm;
            mainWindow.Show();
        }

        private void MainViewModel_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
    }
}