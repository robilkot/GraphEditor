using LW5.Interfaces;

namespace LW5.Commands
{
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void Run()
        {
            try
            {
                if (_command.CanBeExecuted)
                {
                    _command.Execute();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
