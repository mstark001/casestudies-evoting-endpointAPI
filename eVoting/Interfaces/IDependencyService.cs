using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
        void Register<T>(object impl);
    }
}
