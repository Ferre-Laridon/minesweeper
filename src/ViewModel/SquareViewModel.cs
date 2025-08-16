using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class SquareViewModel
    {
        public ICell<Square> Square { get; }
        public ICommand? Uncover { get; }
        public ICommand? Flag { get; }
        public Vector2D Position { get; }
        public ICell<SquareStatus> Status { get; }

        public SquareViewModel(ICell<IGame> game, Vector2D position)
        {
            Square = game.Derive(b => b.Board[position]);
            Position = position;
            Uncover = new UncoverSquareCommand(game, position);
            Flag = new FlagSquareCommand(game, position);
            Status = Square.Derive(s =>
            {
                if (game.Value.Status != GameStatus.InProgress)
                {
                    ISet<Vector2D> mines = game.Value.Mines;
                    if (mines.Contains(Position)) return SquareStatus.Mine;
                }
                return s.Status;
            });
        }
    }
}
