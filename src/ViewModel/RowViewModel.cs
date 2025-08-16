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
    public class RowViewModel
    {
        public IEnumerable<SquareViewModel>? Squares { get; set; }

        public RowViewModel(ICell<IGame> game, int rowIndex)
        {
            var squares = new List<SquareViewModel>();

            for (var col = 0; col < game.Value.Board.Width; col++)
            {
                var position = new Vector2D(col, rowIndex);
                squares.Add(new SquareViewModel(game, position));
            }

            Squares = squares;
        }
    }
}
