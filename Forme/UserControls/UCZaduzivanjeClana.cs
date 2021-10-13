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
    public partial class UCZaduzivanjeClana : UserControl
    {

        KnjigaController knjigaController = new KnjigaController();
        NaslovController naslovController = new NaslovController();
        //BindingList<Knjiga> Sve = new BindingList<Knjiga>();
       // BindingList<Knjiga> Odabrane = new BindingList<Knjiga>();
        

        public UCZaduzivanjeClana()
        {
            InitializeComponent();
      
        }

        private void UCZaduzivanjeClanacs_Load(object sender, EventArgs e)
        {

            naslovController.PopuniZanrove(cmbZanr);
            
            knjigaController.PopuniIzdavace(cmbIzdavac);
            btnDodaj.Enabled = false;
           
            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
         
            knjigaController.VratiKnjigePoKriterijumu(txtNaslov, cmbZanr, txtAutor, cmbIzdavac, dgvKnjige, btnDodaj);
           
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            knjigaController.DodajUZaduzeneGrid(dgvKnjige, dgvZaduzene);
           

        }

        private void btnZaduzi_Click(object sender, EventArgs e)
        {
            knjigaController.ZaduziKnjige(txtClan, dtpDatumOd,dtpDatumDo , txtNapomena);
        }

        private void dgvKnjige_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDodaj.Enabled = true;
        }
    }
}
