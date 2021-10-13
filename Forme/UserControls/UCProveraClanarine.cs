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
    public partial class UCProveraClanarine : UserControl
    {
        ClanarinaController clanarinaController = new ClanarinaController();
        ClanController clanController = new ClanController();
        public UCProveraClanarine()
        {
            InitializeComponent();
        }

        private void btnProveri_Click(object sender, EventArgs e)
        {
            clanarinaController.ProveraClanarine(txtBrojCK, txtJmbg,txtVazenje,btnProduzi,btnProveri, txtIme,txtPrezime, txtTelefon,txtAdresa);

        }

        private void UCProveraClanarine_Load(object sender, EventArgs e)
        {
            btnProduzi.Enabled = false;
            txtVazenje.Enabled = false;
        }

        private void btnProduzi_Click(object sender, EventArgs e)
        {
            clanarinaController.ProduziClanarinu(txtBrojCK);
            txtVazenje.Clear();
            btnProveri.Enabled = true;
            btnProduzi.Enabled = false;
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            clanController.IzmeniClana(txtIme, txtPrezime,txtTelefon, txtAdresa, txtBrojCK);
        }
    }
}
