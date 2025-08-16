using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Screens
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            var firstScreen = new StartScreenViewModel(CurrentScreen, 5, 0.2, true);

            CurrentScreen.Value = firstScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
