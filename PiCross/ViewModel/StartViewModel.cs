using System.Windows.Input;

namespace ViewModel
{
    public class StartViewModel
    {
        public ICommand Choose { get; }
        public ICommand Quit { get; }
        public StartViewModel(MainWindowViewModel mainWindowView)
        {
            vm = mainWindowView;
            Choose = new EasyCommand(() => vm.ChooseGame());
            Quit = new EasyCommand(() => vm.CloseWindow());
        }
        private MainWindowViewModel vm { get; }
    }
}
