using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Communication;
using View.Helpers;

namespace Forme.Controller
{
    class ClanarinaController
    {
        internal void ProveraClanarine(TextBox txtBrojCK, TextBox txtJmbg, TextBox txtVazenje, Button btnProduzi, Button btnProveri, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, TextBox txtAdresa)
        {
            if (!UserControlHelpers.EmptyFieldValidation(txtBrojCK) && !UserControlHelpers.EmptyFieldValidation(txtJmbg))
            {
                MessageBox.Show("Ni jedan identifikator člana nije unet!");
                return;
            }
            try
            {
                string gC = "";
                if (string.IsNullOrWhiteSpace(txtJmbg.Text) && !string.IsNullOrWhiteSpace(txtBrojCK.Text))
                    gC = $"Cl.ClanID = {txtBrojCK.Text}";
                if (!string.IsNullOrWhiteSpace(txtJmbg.Text) && string.IsNullOrWhiteSpace(txtBrojCK.Text))
                    gC = $"C.JMBG = '{txtJmbg.Text}'";
                if(!string.IsNullOrWhiteSpace(txtJmbg.Text) && !string.IsNullOrWhiteSpace(txtBrojCK.Text))
                    gC = $"C.JMBG = '{txtJmbg.Text}' AND Cl.ClanID = {txtBrojCK.Text}";
                Clanarina cl = new Clanarina()
                {
                    GCondition = gC
                };
                cl = Communication.Instance.ProveriClanarine(cl);
                txtIme.Text = cl.Clan.Ime;
                txtPrezime.Text = cl.Clan.Prezime;
                txtAdresa.Text = cl.Clan.Adresa;
                txtTelefon.Text = cl.Clan.Telefon;
                txtBrojCK.Text = Convert.ToString(cl.Clan.BrojClanskeKarte);
                txtJmbg.Text = cl.Clan.Jmbg;
                if (cl.DatumDo > DateTime.Now)
                {
                    txtVazenje.Text = "Važi do " + cl.DatumDo.ToString();
                   // txtBrojCK.Text = "";
                  //  txtJmbg.Text = "";
                    
                }
                else
                {
                    txtVazenje.Text = "Članarina je istekla!";
                    btnProduzi.Enabled = true;
                    btnProveri.Enabled = false;

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ne postoji član sa unetim brojem članske karte i/ili JMBG-om!");
            }
        }

        internal void ProduziClanarinu(TextBox txtBrojCK)
        {
            try
            {
                Clanarina cl = new Clanarina()
                {
                    Clan = new Clan(){
                    BrojClanskeKarte = int.Parse(txtBrojCK.Text)
                    },
                    DatumDo = DateTime.Now.AddYears(1),
  
                   // GCondition = $"ClanID = {txtBrojCK.Text}"
                };
                Communication.Instance.ProduziClanarinu(cl);
                MessageBox.Show("Članarina člana " + cl.Clan + " je produžena do: " + cl.DatumDo.ToString());
                
            }
            catch (Exception)
            { 
                MessageBox.Show("Produžavanje članarine nije uspelo!");
            }
        }
    }
}
