using Cells;
using DataStructures;
using PiCross;
using System.Windows.Input;
using Grid = DataStructures.Grid;


namespace ViewModel
{
    public class GameViewModel
    {
        public ICommand Back { get; }
        public ICommand Quit { get; }

        public ICommand New { get; }

    public MainWindowViewModel MainWindowViewModel { get; }

        public IPlayablePuzzle PlayablePuzzle { get; private set; }
        public MainWindowViewModel Vm { get; private set; }
        public IGrid<PuzzleSquareViewModel> Grid { get; private set; }
        public GameViewModel(MainWindowViewModel mainWindowViewModel, IPlayablePuzzle playablePuzzle)
        {
            MainWindowViewModel = mainWindowViewModel;
            Vm = mainWindowViewModel;
            PlayablePuzzle = playablePuzzle;
            Grid = PlayablePuzzle.Grid.Map(puzzleSquare => new PuzzleSquareViewModel(puzzleSquare)).Copy();
            Back = new EasyCommand(() => MainWindowViewModel.StartViewModel());
            New = new EasyCommand(() => MainWindowViewModel.ChooseGame());
            Quit = new EasyCommand(() => MainWindowViewModel.CloseWindow());

        }
        public Cell<bool> IsSolved { get { return PlayablePuzzle.IsSolved; } }
    }
}