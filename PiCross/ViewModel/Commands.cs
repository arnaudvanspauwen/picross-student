using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class Commands : ICommand
    {
        private readonly Action action;

        public Commands(Action action)
        {
            this.action = action;
        }
        // The add { } remove { } gets rid of annoying warning
        public event EventHandler CanExecuteChanged { add { } remove { } }
        
        public void Execute(object parameter)
        {
            action();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}