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
        void HandleMessage(string data);
        void HandleNavigation(string message, object data);
    }
}
