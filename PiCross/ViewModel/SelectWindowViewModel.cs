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
    public class SelectWindowViewModel
    {
        public SelectWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            vm = mainWindowViewModel;

            var dummyData = vm.PiCrossFacade.CreateDummyGameData();

            var list = dummyData.PuzzleLibrary.Entries;

            Puzzles = new ArrayList();

            foreach (IPuzzleLibraryEntry entry in list)
            {
                Puzzles.Add(vm.PiCrossFacade.CreatePlayablePuzzle(entry.Puzzle));
            }

            ChoosePuzzle = new ChoosePuzzle(mainWindowViewModel);
            Back = new EasyCommand(() => vm.StartViewModel());
            Quit = new EasyCommand(() => vm.CloseWindow());
        }

        public PiCrossFacade Facade;

        public MainWindowViewModel vm;

        public ArrayList Puzzles { get; }
        public ICommand ChoosePuzzle { get; }
        public ICommand Back { get; }
        public ICommand Quit { get; }
    }

    public class ChoosePuzzle : ICommand
    {
        // The add { } remove { } gets rid of annoying warning
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private MainWindowViewModel vm { get; }


        public ChoosePuzzle(MainWindowViewModel mainWindowViewModel)
        {
            vm = mainWindowViewModel;
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
