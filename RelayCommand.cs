using System.Windows.Input;

namespace ConsoleApp2048
{
    internal class RelayCommand : ICommand
    {
        private Action moveLeft;

        public RelayCommand(Action moveLeft)
        {
            this.moveLeft = moveLeft;
        }
    }
}