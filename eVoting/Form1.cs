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
    public partial class Form1 : Form
    {
        IDependencyService dependencyService = new DependencyService();

        public Form1()
        {
            InitializeComponent();
        }

        public void Run()
        {
            var geo = new GeoCoordinate();
            geo.SetLatitude(53.3797045);
            geo.SetLongitude(-1.4655254);

            ///////////// Services ///////////////////////////////////////
            var coordinateServerService = new CoordinateServerService("someUserId", "someUserSecret");
            var votingServerService = new VotingServerService(geo, coordinateServerService);
            //////////////////////////////////////////////////////////////


            ///////////// Set up the Dependnecy Service //////////////////
            dependencyService.Register<ICoordinateServerService>(coordinateServerService);
            dependencyService.Register<IVotingServerService>(votingServerService);
            //////////////////////////////////////////////////////////////






        }

    }
}
