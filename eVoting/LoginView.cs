using eVoting.Interfaces;
using eVoting.Models;
using eVoting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eVoting
{
    public partial class LoginView : BaseView
    {
        //Can call to _dependencyService from this call to access anything we need

        #region View Setup and Teardown functions

        public LoginView(IDependencyService dependencyService) : base(dependencyService) 
        {
            //Matt: Should not be needed when not using WinForms
            InitializeComponent();
        }


        public override void Setup()
        {

        }

        public override void Teardown()
        {

        }

        #endregion

        public void Run()
        {
            var geo = new GeoCoordinate();
            geo.SetLatitude(53.3797045);
            geo.SetLongitude(-1.4655254);
        }

    }
}
