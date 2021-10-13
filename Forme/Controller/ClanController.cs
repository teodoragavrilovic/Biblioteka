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
    class ClanController
    {
        internal void DodajNovogClana(TextBox txtIme, TextBox txtPrezime, TextBox txtAdresa, TextBox txtTelefon, TextBox txtJmbg, TextBox txtBrCK)
        {
             if (!UserControlHelpers.EmptyFieldValidation(txtIme) 
                | !UserControlHelpers.EmptyFieldValidation(txtPrezime)
                | !UserControlHelpers.EmptyFieldValidation(txtAdresa)
                | !UserControlHelpers.EmptyFieldValidation(txtTelefon)
                | !UserControlHelpers.EmptyFieldValidation(txtJmbg))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
            if (!UserControlHelpers.TelefonFieldValidation(txtTelefon))
            {
                MessageBox.Show("Telefon nije ispravno unet!");
                return;
            }
            if (!UserControlHelpers.JmbgFieldValidation(txtJmbg))
            {
                MessageBox.Show("JMBG mora sadržati 13 cifara!");
                return;
            }
        
            
            try 

            {
                Clan c = new Clan()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    Telefon = txtTelefon.Text,
                    Jmbg = txtJmbg.Text
                };
                if (!Communication.Instance.ProveriJMBG(c))
                {
                    MessageBox.Show("Član sa unetim JMBG-om već postoji!");
                }
                else
                {
                    Communication.Instance.DodajNovogClana(c);
                    int id = Communication.Instance.VratiID() - 1;

                    Clanarina cl = new Clanarina()
                    {
                        Clan = new Clan()
                        {
                            BrojClanskeKarte = id
                        },
                        DatumDo = DateTime.Now.AddYears(1)
                    };
                    Communication.Instance.ProduziClanarinu(cl);
                    txtBrCK.Text = Convert.ToString(id);
                    
                    MessageBox.Show("Član je zapamćen!");
                }
             }
            catch(Exception)
            {

                MessageBox.Show("Pamćenje novog člana nije uspelo!");
               
            }
        }

        internal void IzmeniClana(TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, TextBox txtAdresa, TextBox txtBrojCK)
        {
            try
            {
                Clan c = new Clan
                {
                    BrojClanskeKarte = int.Parse(txtBrojCK.Text),
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    Telefon = txtTelefon.Text
                };
                Communication.Instance.IzmeniClana(c);
                MessageBox.Show("Član " + c + " je izmenjen!");
            }
            catch (Exception)
            {

                MessageBox.Show("Pamćenje izmena člana nije uspelo!");
            }
        }
    }
}
