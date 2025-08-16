using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class UncoverSquareCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public ICell<IGame> Game { get; }
        public Vector2D Position { get; }
        public ICell<bool> canExecute { get; }

        public UncoverSquareCommand(ICell<IGame> game, Vector2D position)
        {
            Game = game;
            Position = position;
            canExecute = Game.Derive(g => g.Board[position].Status != SquareStatus.Uncovered && g.Board[position].Status != SquareStatus.Flagged && g.Status == GameStatus.InProgress);
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute.Value;
        }

        public void Execute(object? parameter)
        {
            Game.Value = Game.Value.UncoverSquare(Position);
        }
    }
}
