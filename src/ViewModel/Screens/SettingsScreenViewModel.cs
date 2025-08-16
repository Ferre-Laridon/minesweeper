using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel.Screens
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        public int BoardSize { get; set; }
        public double MineProbability { get; set; }
        public bool Flooding { get; set; }

        public int MinimumBoardSize { get; set; } = IGame.MinimumBoardSize;
        public int MaximumBoardSize { get; set; } = IGame.MaximumBoardSize;
        public double MinimumMineProbability { get; set; } = IGame.MinimumMineProbability;
        public double MaximumMineProbability { get; set; } = IGame.MaximumMineProbability;


        public SettingsScreenViewModel(ICell<ScreenViewModel> currentScreen, int boardSize, double mineProbability, bool flooding) : base(currentScreen)
        {
            BoardSize = boardSize;
            MineProbability = mineProbability;
            Flooding = flooding;

            SwitchToGameScreen = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, BoardSize, MineProbability, Flooding));
        }

        public ICommand SwitchToGameScreen { get; }
    }
}
