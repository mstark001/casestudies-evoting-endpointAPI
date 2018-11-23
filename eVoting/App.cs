using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using eVoting.Interfaces;
using eVoting.Models;
using eVoting.Services;

namespace eVoting
{
    public enum ViewType
    {
        LoginView
    }

    static class App
    {
        private static Dictionary<ViewType, BaseView> _viewRegister = new Dictionary<ViewType, BaseView>();

        private static IDependencyService _dependencyService;
        private static ICoordinateServerService _coordinateServerService;
        private static IVotingServerService _votingServerService;

        private static BaseView _currentView;



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _dependencyService = new DependencyService();

            RegisterViews();
            SetupServices();
            RegisterServices();

            NavigateToView(ViewType.LoginView);
        }

        public static void NavigateToView(ViewType type)
        {
            if (_currentView != null)
            {
                //_currentView.Hide();
                _currentView.Teardown();
            }

            if (_viewRegister.TryGetValue(type, out var view))
            {
                _currentView = view;
                _currentView.Setup();

                System.Windows.Forms.Application.Run(_currentView);
                //_currentView.Show();
            }
            else
            {
                throw new ArgumentException($"No Such view as {type.ToString()}");
            }
        }

        #region Private Helper Functions

        private static void RegisterViews()
        {
            _viewRegister.Add(ViewType.LoginView, new LoginView(_dependencyService));
        }

        private static void SetupServices()
        {
            ///////////// Service Setup ///////////////////////////////////////

            //_coordinateServerService = new CoordinateServerService("someUserId", "someUserSecret");
            //_votingServerService = new VotingServerService(geo, _coordinateServerService);

            ////////////////////////////////////////////////////////////ß//
        }

        private static void RegisterServices()
        {
            ///////////// Set up the Dependnecy Service //////////////////

            _dependencyService.Register<ICoordinateServerService>(_coordinateServerService);
            _dependencyService.Register<IVotingServerService>(_votingServerService);

            //////////////////////////////////////////////////////////////
        }

        #endregion

    }
}
