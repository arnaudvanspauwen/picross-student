using DataStructures;
using PiCross;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SelectVM
    {
        public SelectVM(MainWindowVM MainWindowVM)
        {
            vm = MainWindowVM;

            var dummyData = vm.PiCrossFacade.CreateDummyGameData();

            Puzzles = dummyData.PuzzleLibrary.Entries;

            SelectedPuzzle = Puzzles.ElementAt(0);

            ChoosePuzzle = new ChoosePuzzle(MainWindowVM);
            Back = new Commands(() => vm.StartVM());
            Quit = new Commands(() => vm.CloseWindow());
            Play = new Commands(() => vm.StartGame(vm.PiCrossFacade.CreatePlayablePuzzle(SelectedPuzzle.Puzzle)));
        }

        public PiCrossFacade Facade;

        public MainWindowVM vm;

        public IPuzzleLibraryEntry SelectedPuzzle { get; set; }

        public IEnumerable<IPuzzleLibraryEntry> Puzzles { get; }

        public ICommand ChoosePuzzle { get; }

        public ICommand Back { get; }

        public ICommand Quit { get; }

        public ICommand Play { get; }
    }

    public class ChoosePuzzle : ICommand
    {
        // The add { } remove { } gets rid of annoying warning
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private MainWindowVM vm { get; }


        public ChoosePuzzle(MainWindowVM MainWindowVM)
        {
            vm = MainWindowVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var puzzle = parameter as IPlayablePuzzle;
            vm.StartGame(puzzle);
        }
    }
}
