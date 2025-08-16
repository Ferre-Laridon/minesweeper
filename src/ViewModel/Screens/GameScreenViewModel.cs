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

    // This class takes over the functionality of the (now deleted) GameViewModel
    // I did this to minimize the amount of repeated code
    public class GameScreenViewModel : ScreenViewModel
    {
        public ICommand SwitchToStartScreen { get; }
        public ICommand SwitchToGameScreen { get; }
        private readonly ICell<IGame> _currentGame;
        public GameBoardViewModel Board { get; }
        public ICell<bool> Won { get; }
        public ICell<bool> Lost { get; }
        public ICell<bool> End { get; }
        public TimerViewModel Timer { get; }

        public GameScreenViewModel(ICell<ScreenViewModel> currentScreen, int boardSize, double mineProbability, bool flooding) : base(currentScreen)
        {
            var game = IGame.CreateRandom(boardSize, mineProbability, flooding);
            _currentGame = Cell.Create(game);
            Board = new GameBoardViewModel(_currentGame);

            SwitchToStartScreen = new ActionCommand(() => CurrentScreen.Value = new StartScreenViewModel(this.CurrentScreen, boardSize, mineProbability, flooding));
            SwitchToGameScreen = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, boardSize, mineProbability, flooding));

            // Game status
            Won = this._currentGame.Derive(g => g.Status == GameStatus.Won);
            Lost = this._currentGame.Derive(g => g.Status == GameStatus.Lost);
            End = this._currentGame.Derive(g => g.Status != GameStatus.InProgress);

            // Timer
            Timer = new TimerViewModel(currentScreen, this._currentGame);
        }
    }
}
