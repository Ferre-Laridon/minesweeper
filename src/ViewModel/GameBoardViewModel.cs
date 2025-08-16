using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GameBoardViewModel
    {
        private readonly ICell<IGameBoard> _board;

        public IEnumerable<RowViewModel> Rows { get; }

        public GameBoardViewModel(ICell<IGame> game) 
        {
            _board = game.Derive(g => g.Board);
            var rows = new List<RowViewModel>();

            for (var row = 0; row < _board.Value.Width; row++)
            {
                rows.Add(new RowViewModel(game, row));
            }

            Rows = rows;
        }
    }
}
