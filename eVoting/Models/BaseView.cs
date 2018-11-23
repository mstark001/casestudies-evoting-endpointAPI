using System;
using System.Windows.Forms;

namespace eVoting.Models
{
    public abstract class BaseView : Form
    {
        protected IDependencyService _dependencyService;

        protected BaseView(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }

        public abstract void Setup();
        public abstract void Teardown();

    }
}
