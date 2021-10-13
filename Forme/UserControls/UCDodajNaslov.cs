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
using Domen;

namespace Forme.UserControls
{
    public partial class UCDodajNaslov : UserControl
    {
        NaslovController naslovController = new NaslovController();
        public UCDodajNaslov()
        {
            InitializeComponent();
        }

        private void UCDodajNaslov_Load(object sender, EventArgs e)
        {
            naslovController.PopuniZanrove(cmbZanr);
            naslovController.PopuniAutore(cmbAutor);
            
        }

        private void btnDodajNaslov_Click(object sender, EventArgs e)
        {
            
            naslovController.DodajNaslov(txtNaziv, cmbAutor, cmbZanr);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
