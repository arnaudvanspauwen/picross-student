using Cells;
using DataStructures;
using PiCross;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ViewModel
{
    public class SquareVM
    {
        public IPlayablePuzzleSquare PSquare { get; }
        public ICommand Click { get; }
        public Cell<Square> Contents
        {
            get
            {
                return PSquare.Contents;
            }
        }

        public SquareVM(IPlayablePuzzleSquare puzzleSquare)
        {
            PSquare = puzzleSquare;
            Click = new Click(this);
        }
    }

    public class Click : ICommand
    {
        // The add { } remove { } gets rid of annoying warning
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private SquareVM viewModel;

        public Click(SquareVM SquareVM)
        {
            viewModel = SquareVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object p)
        {
            var square = p as IPlayablePuzzleSquare;

            if (square.Contents.Value == Square.FILLED)
            {
                square.Contents.Value = Square.EMPTY;
            }
            else
            {
                square.Contents.Value = Square.FILLED;
            }
        }
    }
}