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
    public class NaslovController
    {
        internal void PopuniZanrove(ComboBox cmbZanr)
        {
            try
            {
                cmbZanr.DataSource = Communication.Instance.PopuniZanrove();
                cmbZanr.SelectedIndex = -1;
                cmbZanr.Text = "Odaberi žanr";
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void PopuniAutore(ComboBox cmbAutor)
        {
            try
            {
                cmbAutor.DataSource = Communication.Instance.PopuniAutore();
               
                cmbAutor.SelectedIndex = -1;
                cmbAutor.Text = "Odaberi autora";
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void DodajNaslov(TextBox txtNaziv, ComboBox cmbAutor, ComboBox cmbZanr)
        {
            Autor a = (Autor)cmbAutor.SelectedItem;
            Zanr z = (Zanr)cmbZanr.SelectedItem;
            if (!UserControlHelpers.EmptyFieldValidation(txtNaziv)
                | a==null | z==null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
            try
            {
                Naslov n = new Naslov()
                {
                    Naziv = txtNaziv.Text,
                    Autor = a,
                    Zanr = z

                };
                Communication.Instance.DodajNaslov(n);
                MessageBox.Show("Naslov je dodat!");
            }
            catch (Exception)
            {

                MessageBox.Show("Pamćenje naslova nije uspelo!");
            }
        }

       
    }
}
