using View.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Domain;

namespace View
{
    public class MainCoordinator
    {
        private MainController mainController = new MainController();
        private LoginController loginController = new LoginController();
        private FrmLogin frmLogin;
        private FrmMain frmMain;

        public User User { get; set; }

        private static MainCoordinator instance;
        private MainCoordinator() { }

        public static MainCoordinator Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        public void OpenLoginForm()
        {
            frmLogin = new FrmLogin(loginController);
            frmLogin.Show();
        }

        public void OpenMainForm()
        {
            frmMain = new FrmMain(mainController);
            frmMain.Show();
        }
    }
}
