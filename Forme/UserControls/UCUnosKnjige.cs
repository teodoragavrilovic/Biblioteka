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
    public partial class UCUnosKnjige : UserControl
    {
        KnjigaController knjigaController = new KnjigaController();
        NaslovController naslovController = new NaslovController();
        Naslov n = new Naslov();
        public UCUnosKnjige()
        {
            InitializeComponent();
        }

        private void UCUnosKnjige_Load(object sender, EventArgs e)
        {
            naslovController.PopuniZanrove(cmbZanr);
            naslovController.PopuniAutore(cmbAutor);
            knjigaController.PopuniIzdavace(cmbIzdavac);
            btnZapamti.Enabled = false;
            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            
           
            dgvPretraga.DataSource = knjigaController.VratiNaslovePoKriterijumu(cmbAutor, cmbZanr, txtNaslov);
        }

        private void btnZapamti_Click(object sender, EventArgs e)
        {
            
            knjigaController.ZapamtiKnjigu(cmbIzdavac,txtIsbn,txtGodina,txtKnjigaID);
        }

        private void dgvPretraga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnZapamti.Enabled = true;
            knjigaController.VratiNaslov(dgvPretraga, txtKAutor,txtKNaslov,txtKZanr);
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            txtGodina.Text = "";
            txtIsbn.Text = "";
            cmbIzdavac.SelectedIndex = -1;
            cmbIzdavac.Text = "Odaberi izdavaca";
            txtKnjigaID.Text = "";
            txtKAutor.Text = "";
            txtKNaslov.Text = "";
            txtKZanr.Text = "";
            
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbIzdavac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
