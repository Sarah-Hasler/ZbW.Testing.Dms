using System;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Windows;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Views;

    internal class LoginViewModel : BindableBase
    {
        private readonly LoginView _loginView;

        private string _benutzername;

        public LoginViewModel(LoginView loginView)
        {
            _loginView = loginView;
            CmdLogin = new DelegateCommand(OnCmdLogin, OnCanLogin);
            CmdAbbrechen = new DelegateCommand(OnCmdAbbrechen);

	        var savedUser = Properties.Settings.Default.currentUser;


			if (!String.IsNullOrEmpty(savedUser))
	        {
		        Benutzername = savedUser;
				this.OnCmdLogin();
	        }
        }

        public DelegateCommand CmdAbbrechen { get; }

        public DelegateCommand CmdLogin { get; }

        public string Benutzername
        {
            get
            {
                return _benutzername;
            }

            set
            {
                if (SetProperty(ref _benutzername, value))
                {
                    CmdLogin.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanLogin()
        {
            return !string.IsNullOrEmpty(Benutzername);
        }

        private void OnCmdAbbrechen()
        {
            Application.Current.Shutdown();
        }

        private void OnCmdLogin()
        {
            if (string.IsNullOrEmpty(Benutzername))
            {
                MessageBox.Show("Bitte tragen Sie einen Benutzernamen ein...");
                return;
            }

			this.saveUser();

			var searchView = new MainView(Benutzername);
            searchView.Show();

            _loginView.Close();
        }

	    private void saveUser() {
			Properties.Settings.Default.currentUser = Benutzername;
		    Properties.Settings.Default.Save();
		}
    }
}