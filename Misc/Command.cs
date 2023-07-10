using System;

namespace Scrappers
{
    public class Command
    {
        public bool _canExecute = true;

        public EventHandler<object> OnExecute;

        public Command(EventHandler<object> OnExecute)
        {
            this.OnExecute = OnExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }
            set
            {
                _canExecute = value;
            }
        }

        public void Execute(object parameter)
        {
            OnExecute(this, parameter);
        }
    }
}