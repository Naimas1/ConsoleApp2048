using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleApp2048
{
    public class Tile
    {
        public int Value { get; set; }

    }

    public class GameBoard
    {
        public Tile[,] Tiles { get; set; }
        public int Score { get; set; }
 
    }
    public class GameViewModel : ViewModelBase
    {
        private GameBoard _gameBoard;

        public GameBoard GameBoard
        {
            get { return _gameBoard; }
            set
            {
                _gameBoard = value;
                OnPropertyChanged(nameof(GameBoard));
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public ICommand MoveLeftCommand => new RelayCommand(MoveLeft);
        public ICommand MoveRightCommand => new RelayCommand(MoveRight);
        public ICommand MoveUpCommand => new RelayCommand(MoveUp);
        public ICommand MoveDownCommand => new RelayCommand(MoveDown);


        private void MoveLeft()
        {
            for (int row = 0; row < GameBoard.Tiles.GetLength(0); row++)
            {
                for (int col = 1; col < GameBoard.Tiles.GetLength(1); col++)
                {
                    if (GameBoard.Tiles[row, col] != null)
                    {
                        int currentCol = col;
                        while (currentCol > 0 && GameBoard.Tiles[row, currentCol - 1] == null)
                        {
                            // Переміщення вліво, поки не зустрічаємо ненульову плитку або край
                            GameBoard.Tiles[row, currentCol - 1] = GameBoard.Tiles[row, currentCol];
                            GameBoard.Tiles[row, currentCol] = null;
                            currentCol--;
                        }

                        if (currentCol > 0 && GameBoard.Tiles[row, currentCol - 1].Value == GameBoard.Tiles[row, currentCol].Value)
                        {
                            // Об'єднання, якщо зустрічаємо плитку з тим самим значенням
                            GameBoard.Tiles[row, currentCol - 1].Value *= 2;
                            GameBoard.Tiles[row, currentCol] = null;
                            
                        }
                    }
                }
            }
        }

        private void MoveRight()
        {
            for (int row = 0; row < GameBoard.Tiles.GetLength(0); row++)
            {
                for (int col = GameBoard.Tiles.GetLength(1) - 2; col >= 0; col--)
                {
                    if (GameBoard.Tiles[row, col] != null)
                    {
                        int currentCol = col;
                        while (currentCol < GameBoard.Tiles.GetLength(1) - 1 && GameBoard.Tiles[row, currentCol + 1] == null)
                        {
                            // Переміщення вправо, поки не зустрічаємо ненульову плитку або край
                            GameBoard.Tiles[row, currentCol + 1] = GameBoard.Tiles[row, currentCol];
                            GameBoard.Tiles[row, currentCol] = null;
                            currentCol++;
                        }

                        if (currentCol < GameBoard.Tiles.GetLength(1) - 1 && GameBoard.Tiles[row, currentCol + 1].Value == GameBoard.Tiles[row, currentCol].Value)
                        {
                            // Об'єднання, якщо зустрічаємо плитку з тим самим значенням
                            GameBoard.Tiles[row, currentCol + 1].Value *= 2;
                            GameBoard.Tiles[row, currentCol] = null;
                          
                        }
                    }
                }
            }

        }

        private void MoveUp()
        {
            for (int col = 0; col < GameBoard.Tiles.GetLength(1); col++)
            {
                for (int row = 1; row < GameBoard.Tiles.GetLength(0); row++)
                {
                    if (GameBoard.Tiles[row, col] != null)
                    {
                        int currentRow = row;
                        while (currentRow > 0 && GameBoard.Tiles[currentRow - 1, col] == null)
                        {
                            // Переміщення вгору, поки не зустрічаємо ненульову плитку або край
                            GameBoard.Tiles[currentRow - 1, col] = GameBoard.Tiles[currentRow, col];
                            GameBoard.Tiles[currentRow, col] = null;
                            currentRow--;
                        }

                        if (currentRow > 0 && GameBoard.Tiles[currentRow - 1, col].Value == GameBoard.Tiles[currentRow, col].Value)
                        {
                            // Об'єднання, якщо зустрічаємо плитку з тим самим значенням
                            GameBoard.Tiles[currentRow - 1, col].Value *= 2;
                            GameBoard.Tiles[currentRow, col] = null;
                         
                        }
                    }
                }
            }

        }

        private void MoveDown()
        {
            for (int col = 0; col < GameBoard.Tiles.GetLength(1); col++)
            {
                for (int row = GameBoard.Tiles.GetLength(0) - 2; row >= 0; row--)
                {
                    if (GameBoard.Tiles[row, col] != null)
                    {
                        int currentRow = row;
                        while (currentRow < GameBoard.Tiles.GetLength(0) - 1 && GameBoard.Tiles[currentRow + 1, col] == null)
                        {
                            // Переміщення вниз, поки не зустрічаємо ненульову плитку або край
                            GameBoard.Tiles[currentRow + 1, col] = GameBoard.Tiles[currentRow, col];
                            GameBoard.Tiles[currentRow, col] = null;
                            currentRow++;
                        }

                        if (currentRow < GameBoard.Tiles.GetLength(0) - 1 && GameBoard.Tiles[currentRow + 1, col].Value == GameBoard.Tiles[currentRow, col].Value)
                        {
                            // Об'єднання, якщо зустрічаємо плитку з тим самим значенням
                            GameBoard.Tiles[currentRow + 1, col].Value *= 2;
                            GameBoard.Tiles[currentRow, col] = null;
                           
                        }
                    }
                }
            }
        }

     
    }

}
