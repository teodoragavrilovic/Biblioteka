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
    public partial class UCRazduzivanjeClana : UserControl
    {
        KnjigaController knjigaController = new KnjigaController();
       
        public UCRazduzivanjeClana()
        {
            InitializeComponent();
            
        }

        private void UCRazduzivanjeClana_Load(object sender, EventArgs e)
        {
            btnObrisi.Enabled = false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
           
            knjigaController.VratiKnjigu(txtKnjiga, dgvKnjige);
            
        }

        private void btnRazduzi_Click(object sender, EventArgs e)
        {
            knjigaController.RazduziKnjige(txtClan);
        }

        private void dgvKnjige_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnObrisi.Enabled = true;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            knjigaController.ObrisiRed(dgvKnjige);
        }
    }
}
