using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.UILib.Controls
{
    public class UserCommandWithParam : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _executeMethod;
        Func<bool> canExecute;
        Func<object, bool> _canexecuteMethod;
        Action _execute;

        public UserCommandWithParam(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }
        public UserCommandWithParam(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this.canExecute = canExecute;
        }
        public UserCommandWithParam(Action execute)
        {
            _execute = execute;
        }

        public UserCommandWithParam(Action<object> execute)
        {
            _executeMethod = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            //throw new NotImplementedException();
            return this.canExecute();
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();

            _executeMethod(parameter);

        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

    public class UserCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        private readonly Action execute;


        public UserCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("execute can not null");

            _execute = execute;
            _canExecute = canExecute;
        }

        public UserCommand(Action<object> execute) : this(execute, null)
        {

        }


        public UserCommand(Action exectue) : this(exectue, null)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UserCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// can executes event handler
        /// </summary>

        /// <summary>
        /// implement of icommand can execute method
        /// </summary>
        /// <param name="o">parameter by default of icomand interface</param>
        /// <returns>can execute or not</returns>
        public bool CanExecute(object o)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        /// <summary>
        /// implement of icommand interface execute method
        /// </summary>
        /// <param name="o">parameter by default of icomand interface</param>
        public void Execute(object o)
        {
            this.execute();
        }

        /// <summary> 
        /// raise ca excute changed when property changed
        /// </summary>

    }
}
