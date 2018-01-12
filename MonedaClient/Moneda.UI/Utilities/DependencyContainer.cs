using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneda.UI.Utilities
{
    public class DependencyContainer
    {
        private static DependencyContainer instance;

        public static DependencyContainer GetInstance {
            get
            {
                if(instance == null)
                {
                    instance = new DependencyContainer();
                }
                return instance;
            }
        }
        IUnityContainer _container;

        public IUnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        private DependencyContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IAPIAccess, APIAccess>();
            _container.RegisterType<IEventAggregator, EventAggregator>();
        }
        
    }
}
