using View.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Storage;
using View;
using View.Controller;

namespace View
{
    public partial class FrmLogin : Form
    {
        private LoginController loginController;

        // private ControllerBL.Controller kontroler;
        public FrmLogin()
        {
            // kontroler = new ControllerBL.Controller();
            InitializeComponent();
            txtUsername.Text = "pera";
            txtPassword.Text = "pera";

        }

        public FrmLogin(LoginController loginController)
        {
            this.loginController = loginController;
            InitializeComponent();
            txtUsername.Text = "tea";
            txtPassword.Text = "tea";
        }

        private void btnPrijavi_Click(object sender, EventArgs e)
        {
            if(loginController.Connect())
            loginController.Login(txtUsername, txtPassword, this);
            
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
