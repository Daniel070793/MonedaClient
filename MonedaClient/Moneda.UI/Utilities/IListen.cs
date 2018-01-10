using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Moneda.UI.Utilities
{
    public interface IListen
    {

    }
    public interface IListen<T1> : IListen
    {
        void DisplayMessage(string message);
        void Navigate(Page page, T1 obj);
    }
}
