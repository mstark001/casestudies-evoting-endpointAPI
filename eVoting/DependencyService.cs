using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting
{
    public class DependencyService : IDependencyService
    {
        private readonly Dictionary<Type, object> _registeredServices = new Dictionary<Type, object>();

        public void Register<T>(object impl)
        {
            GetRegisteredServices()[typeof(T)] = impl;
        }

        public T Get<T>() where T : class
        {
            return (T)GetRegisteredServices()[typeof(T)];
        }

        #region Private Helper Functions

        private Dictionary<Type, object> GetRegisteredServices()
        {
            return _registeredServices;
        }

        #endregion
    }
}
