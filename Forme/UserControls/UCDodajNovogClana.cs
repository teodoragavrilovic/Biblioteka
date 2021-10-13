using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forme.Controller;

namespace Forme.UserControls
{

    public partial class UCDodajNovogClana : UserControl
    {
        ClanController clanController = new ClanController();
        public UCDodajNovogClana()
        {
            InitializeComponent();
        }

  

        private void btnDodajClana_Click(object sender, EventArgs e)
        {
            clanController.DodajNovogClana(txtIme, txtPrezime, 
                txtAdresa, txtTelefon, txtJmbg, txtBrCK);
           // txtBrCK.BackColor = Color.LightGray;
            
        }

        private void UCDodajNovogClana_Load(object sender, EventArgs e)
        {
           txtBrCK.Enabled = false;
            
        }
    
        private void btnOsvezi_Click_1(object sender, EventArgs e)
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtJmbg.Text = "";
            txtTelefon.Text = "";
            txtAdresa.Text = "";
            txtBrCK.Text = "";
            txtIme.BackColor = Color.White;
            txtPrezime.BackColor = Color.White;
            txtJmbg.BackColor = Color.White;
            txtTelefon.BackColor = Color.White;
            txtAdresa.BackColor = Color.White;
            txtBrCK.BackColor = Color.White;

     
        }
    }
}
