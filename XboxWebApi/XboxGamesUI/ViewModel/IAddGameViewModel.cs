using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XboxGamesUI.ViewModel
{
    public interface IModifyGameViewModel
    {
         ICommand SaveCommand { get; set; }
         Boolean AllowTitleEdit { get; }
    }
}
