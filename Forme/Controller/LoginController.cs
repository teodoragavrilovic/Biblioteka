using Domain;
using Forme.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using View.Helpers;

namespace View.Controller
{
    public class LoginController
    {
        internal void Login(TextBox txtUsername, TextBox txtPassword, FrmLogin frmLogin)
        {
            if (!UserControlHelpers.
                EmptyFieldValidation(txtUsername)
                | !UserControlHelpers.EmptyFieldValidation(txtPassword))
            {
                return;
            }
            try
            {
                User k = Communication.Communication.Instance.Login(txtUsername.Text, txtPassword.Text);
                MainCoordinator.Instance.User = k;
                if (k != null)
                {
                    MessageBox.Show($"Korisnik {k.Name} {k.LastName} se uspesno prijavio!");

                    MainCoordinator.Instance.OpenMainForm();
                    frmLogin.Dispose();
                }else
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
            }
            catch (Exception)
            {
                MessageBox.Show("Prijava neuspešna!");
            }
        }

        internal bool Connect()
        {
            try
            {
                Communication.Communication.Instance.Connect();
                return true;
            }
            catch (SocketException)
            {
                MessageBox.Show("Greska pri povezivanju sa serverom!");
                return false;
            }
        }
    }
}
