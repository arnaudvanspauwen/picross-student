using System.Windows.Input;

namespace ViewModel
{
    public class StartVM
    {
        public ICommand Choose { get; }
        public ICommand Quit { get; }
        public StartVM(MainWindowVM mainWindowView)
        {
            vm = mainWindowView;
            Choose = new Commands(() => vm.ChooseGame());
            Quit = new Commands(() => vm.CloseWindow());
        }
        private MainWindowVM vm { get; }
    }
}
