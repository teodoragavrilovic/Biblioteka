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
    public partial class UCPretragaKnjiga : UserControl
    {
        KnjigaController knjigaController = new KnjigaController();
        NaslovController naslovController = new NaslovController();
       
        public UCPretragaKnjiga()
        {
            InitializeComponent();
        }

        private void UCPretragaKnjiga_Load(object sender, EventArgs e)
        {
            naslovController.PopuniZanrove(cmbZanr);
            knjigaController.PopuniIzdavace(cmbIzdavac);
            btnObrisi.Enabled = false;
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            knjigaController.VratiKnjigePoKriterijumu(txtNaslov, cmbZanr, txtAutor, cmbIzdavac, dgvKnjige, btnObrisi);
            
           
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            
            knjigaController.ObrisiKnjigu(txtKID, dgvKnjige);
            txtKNaslov.Text = "";
            txtKAutor.Text = "";
            txtKZanr.Text = "";
            txtKIzdavac.Text = "";
            txtKGodina.Text = "";
            txtKISBN.Text = "";
            txtKID.Text = "";
        }

        private void dgvKnjige_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            knjigaController.UcitajKnjigu(dgvKnjige, btnObrisi,txtKID, txtKNaslov,txtKAutor,txtKZanr,txtKIzdavac, txtKGodina, txtKISBN);
            
        }

        private void txtKISBN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
