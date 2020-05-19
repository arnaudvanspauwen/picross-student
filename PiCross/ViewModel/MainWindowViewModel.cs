using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object activeWindow;

        public PiCrossFacade PiCrossFacade { get; }

        public Action Close { get; set; }
        public MainWindowViewModel()
        {
            CurrentWindow = new StartViewModel(this);
            PiCrossFacade = new PiCrossFacade();
        }

        public object CurrentWindow
        {
            get
            {
                return activeWindow;
            }
            private set
            {
                activeWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentWindow)));
            }
        }

        public void StartGame(IPlayablePuzzle puzzle)
        {
            CurrentWindow = new GameViewModel(this, puzzle);
        }

        public void ChooseGame()
        {
            CurrentWindow = new SelectWindowViewModel(this);
        }

        public void StartViewModel()
        {
            CurrentWindow = new StartViewModel(this);
        }

        public void CloseWindow()
        {
            Close?.Invoke();
        }
    }
}
