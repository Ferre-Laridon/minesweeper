using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel.Screens
{
    public class StartScreenViewModel : ScreenViewModel
    {
        public StartScreenViewModel(ICell<ScreenViewModel> currentScreen, int boardSize, double mineProbablity, bool flooding) : base(currentScreen)
        {
            SwitchToGameScreenEasy = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, 5, 0.2, true));
            SwitchToGameScreenMedium = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, 10, 0.2, true));
            SwitchToGameScreenHard = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, 15, 0.2, true));
            SwitchToGameScreenExtreme = new ActionCommand(() => CurrentScreen.Value = new GameScreenViewModel(this.CurrentScreen, 20, 0.2, true));
            SwitchToSettingsScreen = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(this.CurrentScreen, boardSize, mineProbablity, flooding));
        }

        public ICommand SwitchToGameScreenEasy { get; }
        public ICommand SwitchToGameScreenMedium { get; }
        public ICommand SwitchToGameScreenHard { get; }
        public ICommand SwitchToGameScreenExtreme { get; }
        public ICommand SwitchToSettingsScreen { get; }
    }
}
