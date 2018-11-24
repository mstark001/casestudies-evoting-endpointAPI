﻿using System;
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
        LoginView,
        RegisterView,
        VotingView
    }

    static class App
    {
        private static Dictionary<ViewType, BaseView> _viewRegister = new Dictionary<ViewType, BaseView>();

        private static IDependencyService _dependencyService;
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
            SetupAndRegisterServices();


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

        private static void SetupAndRegisterServices()
        {
            ///////////// Service Setup ///////////////////////////////////////

            var geoLocationService = new GeoLocationService();
            var endpointServerService = new EndpointServerService(geoLocationService);
            var votingServerService = new VotingServerService(endpointServerService);
            var loginService = new LoginService(endpointServerService, votingServerService);
            var translationServerService = new TranslationServerService();
            var accessibleValueService = new AccessibleValueService(translationServerService);

            ///////////// Set up the Dependency Service //////////////////

            _dependencyService.Register<IGeoLocationService>(geoLocationService);
            _dependencyService.Register<ILoginService>(loginService);
            _dependencyService.Register<IEndpointServerService>(endpointServerService);
            _dependencyService.Register<IVotingServerService>(votingServerService);
            _dependencyService.Register<ITranslationServerService>(translationServerService);
            _dependencyService.Register<IAccessibleValueService>(accessibleValueService);

            //////////////////////////////////////////////////////////////
        }



        #endregion

    }
}
