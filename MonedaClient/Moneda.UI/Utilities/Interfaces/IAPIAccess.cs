using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneda.UI.Utilities
{
    public interface IAPIAccess
    {
        Task Post<T>(string url, T obj);
    }
}
