using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using ViewModel.Commands;
using ViewModel.Screens;

namespace ViewModel
{
    public class TimerViewModel : ScreenViewModel
    {
        private readonly ICell<TimeSpan> _elapsedTimeCell;
        private ICell<IGame> _game;
        private System.Timers.Timer _timer;
        private TimeSpan _elapsedTime;
        private bool _running;

        public TimerViewModel(ICell<ScreenViewModel> currentScreen, ICell<IGame> game) : base(currentScreen)
        {
            _timer = new System.Timers.Timer(10);
            _timer.Elapsed += TimeElapsed;
            _game = game;

            _elapsedTimeCell = Cell.Create(_elapsedTime);
            if (!_running && game.Value.Status.Equals(GameStatus.InProgress))
            {
                StartTimer();
            }
        }

        public ICell<TimeSpan> ElapsedTimeCell => _elapsedTimeCell;
        public ICommand StartCommand => new ActionCommand(StartTimer);
        public ICommand StopCommand => new ActionCommand(StopTimer);

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            if (_running && !_game.Value.Status.Equals(GameStatus.InProgress))
            {
                StopTimer();
            }

            _elapsedTime = _elapsedTime.Add(TimeSpan.FromMilliseconds(10));
            _elapsedTimeCell.Value = _elapsedTime;
        }

        public void StartTimer()
        {
            if (!_running)
            {
                _timer.Start();
                _running = true;
            }
        }

        public void StopTimer()
        {
            if (_running)
            {
                _timer.Stop();
                _running = false;
            }
        }
    }
}
