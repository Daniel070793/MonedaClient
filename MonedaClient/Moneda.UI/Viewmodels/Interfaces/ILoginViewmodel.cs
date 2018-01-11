using System.Windows.Input;
using Moneda.UI.Utilities;

namespace Moneda.UI.Viewmodels
{
    public interface ILoginViewmodel
    {
        IAPIAccess APIAccess { get; set; }
        ICommand CreateCommand { get; }
        ICommand LoginCommand { get; }
        string Password { get; set; }
        string Username { get; set; }
    }
}