using Cells;
using DataStructures;
using PiCross;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using Grid = DataStructures.Grid;


namespace ViewModel
{
    public class GameVM : INotifyPropertyChanged
    {
        private TimeSpan collectTime;
        private DateTime lastTick;
        private DispatcherTimer timer;

        public GameVM(MainWindowVM VM, IPlayablePuzzle playablePuzzle)
        {
            MainWindowVM = VM;
            Vm = MainWindowVM;
            PlayablePuzzle = playablePuzzle;
            Grid = PlayablePuzzle.Grid.Map(puzzleSquare => new SquareVM(puzzleSquare)).Copy();
            Back = new Commands(() => MainWindowVM.StartVM());
            New = new Commands(() => MainWindowVM.ChooseGame());
            Quit = new Commands(() => MainWindowVM.CloseWindow());

            lastTick = DateTime.Now;
            timer = new DispatcherTimer(TimeSpan.FromMilliseconds(10), DispatcherPriority.Background, OnTimerTick, Dispatcher.CurrentDispatcher);
            timer.IsEnabled = true;

        }

        public ICommand Back { get; }
        public ICommand Quit { get; }
        public ICommand New { get; }

        public MainWindowVM MainWindowVM { get; }

        public IPlayablePuzzle PlayablePuzzle { get; private set; }
        public MainWindowVM Vm { get; private set; }
        public IGrid<SquareVM> Grid { get; private set; }

        public Cell<bool> IsSolved { get { return PlayablePuzzle.IsSolved; } }

        public TimeSpan GetTimer
        {
            get { return collectTime; }

            set 
            {
                collectTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GetTimer)));
            }
        }
        private void OnTimerTick(object sender, EventArgs args)
        {
            if (!this.IsSolved.Value)
            {
                var now = DateTime.Now;
                GetTimer += now - lastTick;
                lastTick = now;
            }
            else
            {
                this.timer.IsEnabled = false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}