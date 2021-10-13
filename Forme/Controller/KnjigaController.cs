using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Communication;
using View.Helpers;

namespace Forme.Controller
{
    class KnjigaController
    {
        BindingList<Knjiga> Odabrane = new BindingList<Knjiga>();
        BindingList<Knjiga> Sve = new BindingList<Knjiga>();
        BindingList<Knjiga> Pozajmljene = new BindingList<Knjiga>();
        BindingList<Knjiga> Result = new BindingList<Knjiga>();
        Knjiga knjiga = new Knjiga();
        internal void PopuniIzdavace(ComboBox cmbIzdavac)
        {
            try
            {
                cmbIzdavac.DataSource = Communication.Instance.PopuniIzdavace();
                cmbIzdavac.SelectedIndex = -1;
                cmbIzdavac.Text = "Odaberi izdavaca";
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Naslov> VratiNaslovePoKriterijumu(ComboBox cmbAutor, ComboBox cmbZanr, TextBox naziv)
        {
            List<Naslov> Result;
            
            int a = cmbAutor.SelectedIndex;
            int z = cmbZanr.SelectedIndex;
            if (!UserControlHelpers.EmptyFieldValidation(naziv)
                && a == -1 && z == -1)
            {
                MessageBox.Show("Ni jedan kriterijum nije unet");
                return null;
            }
            try
            {
                Naslov n = new Naslov()
                {
                  
                    GCondition = "",
                 
                };
                if (a != -1)
                    n.GCondition = $"A.AutorID = {((Autor)cmbAutor.SelectedItem).AutorID}";
                if (z != -1)
                {
                    if (n.GCondition == "")
                        n.GCondition = $"Z.ZanrID = {((Zanr)cmbZanr.SelectedItem).ZanrID}";
                    else
                        n.GCondition = n.GCondition + $" and Z.ZanrID = {((Zanr)cmbZanr.SelectedItem).ZanrID}";
                }
                if (naziv.Text != "")
                {
                    if (n.GCondition == "")
                        n.GCondition = $"Naziv LIKE '{naziv.Text}%'";
                    else
                        n.GCondition = n.GCondition + $" and Naziv LIKE '{naziv.Text}%'";
                }


                Result = Communication.Instance.VratiNaslovePoKriterijumu(n);
                if(Result.Count==0)
                    MessageBox.Show("Ne postoji naslov sa zadatim kriterijumima!");
                cmbAutor.SelectedIndex = -1;
                cmbZanr.SelectedIndex = -1;
                cmbZanr.Text = "Odaberi zanr";
                cmbAutor.Text = "Odaberi autora";
                naziv.Text = "";
                return Result;

            }
            catch (Exception)
            {

                MessageBox.Show("Učitavanje naslova nije uspelo!");
                return null;
            }
        }

        internal void UcitajKnjigu(DataGridView dgvKnjige, Button btnObrisi, TextBox txtKID, TextBox txtKNaslov, TextBox txtKAutor, TextBox txtKZanr, TextBox txtKIzdavac, TextBox txtKGodina, TextBox txtKISBN)
        {
            try
            {
                Knjiga k = new Knjiga
                {
                    PrimerakID = ((Knjiga)dgvKnjige.SelectedCells[0].OwningRow.DataBoundItem).PrimerakID,
                   
                };
                k.GCondition = $"K.PrimerakID = {k.PrimerakID}";
                 k =  Communication.Instance.VratiKnjigu(k);
                txtKID.Text = Convert.ToString(k.PrimerakID);
                txtKNaslov.Text = k.Naslov.Naziv;
                txtKAutor.Text = k.Naslov.Autor.ImePrezime;
                txtKZanr.Text = k.Naslov.Zanr.NazivZanra;
                txtKIzdavac.Text = k.Izdavac.NazivIzdavaca;
                txtKGodina.Text = Convert.ToString(k.Godina);
                txtKISBN.Text = k.ISBN;
                btnObrisi.Enabled = true;

            }
            catch (Exception)
            {

                MessageBox.Show("Učitavanje knjige nije uspelo!");
                txtKNaslov.Text = "";
                txtKAutor.Text = "";
                txtKZanr.Text = "";
                txtKIzdavac.Text = "";
                txtKGodina.Text = "";
                txtKISBN.Text = "";
                txtKID.Text = "";
            }
            
        }

        internal void ObrisiRed(DataGridView dgvKnjige)
        {
            Pozajmljene.Remove((Knjiga)dgvKnjige.SelectedCells[0].OwningRow.DataBoundItem);
        }

        internal void DodajUZaduzeneGrid(DataGridView dgvKnjige, DataGridView dgvZaduzene)
        {
            try
            {
                Knjiga k = (Knjiga)dgvKnjige.SelectedCells[0].OwningRow.DataBoundItem;
                Sve.Remove(k);
                dgvKnjige.DataSource = Sve;
                k.GCondition = $"K.PrimerakID = {k.PrimerakID} AND K.Dostupna = 1";
                k = Communication.Instance.VratiKnjigu(k);
                if (k == null)
                {
                    MessageBox.Show("Knjiga je u međuvremenu zadužena!");
                    return;
                }
                Odabrane.Add(k);
                dgvZaduzene.DataSource = Odabrane;
                MessageBox.Show("Knjiga je dodata u listu za zaduživanje!");
               
            }
            catch (Exception)
            {

                MessageBox.Show("Dodavanje knjige na listu za zaduživanje nije uspelo!");
            }
            
           
        }

        internal void RazduziKnjige(TextBox txtClan)
        {
            if (!UserControlHelpers.EmptyFieldValidation(txtClan))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
            try
            {
                int n = int.Parse(txtClan.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Neispravno unet broj članske karte!");
                txtClan.Text = "";
                txtClan.BackColor = Color.Maroon;
                return;
            }
            try
            {

                foreach (Knjiga k in Pozajmljene)
                {
                    Zaduzenje z = new Zaduzenje()
                    {
                        Knjiga = k,
                        Clan = new Clan()
                        {
                            BrojClanskeKarte = int.Parse(txtClan.Text)
                        },

                        Vracena = true,
                        

                    };

                    z.GCondition = $"ZD.ClanID = {z.Clan.BrojClanskeKarte} and ZD.PrimerakID = {k.PrimerakID} and ZD.Vracena = 0";
                    bool kasnjenje = Communication.Instance.ProveriKasnjenje(z);
                    if (!kasnjenje)
                        MessageBox.Show($"Kašnjenje sa razduživanjem knjige '{k.Naslov}'");
                    Communication.Instance.RazduziKnjige(z);
                 

                }
                txtClan.Text = "";
                txtClan.BackColor = Color.White;
                Pozajmljene.Clear();
                MessageBox.Show("Knjige su vraćene!");
            }
            catch (Exception)
            {
                txtClan.Text = "";
                MessageBox.Show("Unet član nije zaduzio neku od unetih knjiga! Molim proverite podatke i pokusajte ponovo!");
            }

        }

        internal void VratiKnjigu(TextBox primerakID, DataGridView dgvKnjige)
        {
            try
            {
                int n=int.Parse(primerakID.Text);
                for(int i = 0; i < Pozajmljene.Count; i++)
                {
                    if(Pozajmljene[i].PrimerakID == n)
                    {
                        MessageBox.Show("Ova knjiga je već uneta!");
                        primerakID.Text = "";
                        return;
                    }

                }
               
            }
            catch (Exception)
            {
                if(primerakID.Text=="")
                    MessageBox.Show("Niste uneli šifru knjige!");
                else
                    MessageBox.Show("Šifra knjige ne moze biti tekst!");
                return;
            }
            try
            {
                Knjiga k = new Knjiga
                {
                    PrimerakID = int.Parse(primerakID.Text),
                    GCondition = $"PrimerakID = {primerakID.Text} AND Aktuelna = 1 AND Dostupna = 0"
                };
                k = Communication.Instance.VratiKnjigu(k);
                Pozajmljene.Add(k);
                dgvKnjige.DataSource = Pozajmljene;
                primerakID.Text = "";
                MessageBox.Show("Knjiga je dodata na listu za razduživanje!");

            }
            catch (Exception)
            {

                MessageBox.Show("Ne postoji zaduženje za unetu knjigu!");
                return;
            }
        }

        internal void VratiKnjigePoKriterijumu(TextBox txtNaslov, ComboBox cmbZanr, TextBox txtAutor, ComboBox cmbIzdavac, DataGridView dgvKnjige, Button btnObrisi)
        {
            
            int Z = cmbZanr.SelectedIndex;
            
            int I = cmbIzdavac.SelectedIndex;
            if (string.IsNullOrWhiteSpace(txtNaslov.Text) && string.IsNullOrWhiteSpace(txtAutor.Text)
             && Z == -1  && I == -1)
            {
                MessageBox.Show("Niste uneli ni jedan kriterijum za pretragu!");
                return;
            }
            Knjiga k = new Knjiga();
            if (I == -1 && Z == -1 && string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                k.GCondition = $"N.Naziv LIKE '{txtNaslov.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
            }
            else
            {
                if (I == -1 && Z == -1 && string.IsNullOrWhiteSpace(txtNaslov.Text))
                {
                    k.GCondition = $"A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                }
                else
                {
                    if (I == -1 && string.IsNullOrWhiteSpace(txtAutor.Text) && string.IsNullOrWhiteSpace(txtNaslov.Text))
                    {
                        k.GCondition = $"N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND K.Aktuelna = 1 AND K.Dostupna=1";
                    }
                    else
                    {
                        if (Z == -1 && string.IsNullOrWhiteSpace(txtAutor.Text) && string.IsNullOrWhiteSpace(txtNaslov.Text))
                        {
                            k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND K.Aktuelna = 1 AND K.Dostupna=1";
                        }
                        else
                        {
                            if (I == -1 && Z == -1)
                            {
                                k.GCondition = $"N.Naziv LIKE '{txtNaslov.Text}%' AND A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                            }
                            else
                            {
                                if (I == -1 && string.IsNullOrWhiteSpace(txtNaslov.Text))
                                {
                                    k.GCondition = $"N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                }
                                else
                                {
                                    if (I == -1 && string.IsNullOrWhiteSpace(txtAutor.Text))
                                    {
                                        k.GCondition = $"N.Naziv LIKE '{txtNaslov.Text}%' AND N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                    }
                                    else
                                    {
                                        if (Z == -1 && string.IsNullOrWhiteSpace(txtNaslov.Text))
                                        {
                                            k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND  A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                        }
                                        else
                                        {
                                            if (Z == -1 && string.IsNullOrWhiteSpace(txtAutor.Text))
                                            {
                                                k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND N.Naziv LIKE '{txtNaslov.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                            }
                                            else
                                            {
                                                if (string.IsNullOrWhiteSpace(txtNaslov.Text) && string.IsNullOrWhiteSpace(txtAutor.Text))
                                                {
                                                    k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                                }
                                                else
                                                {
                                                    if (I == -1)
                                                    {
                                                        k.GCondition = $"N.Naziv LIKE '{txtNaslov.Text}%' AND N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                                    }
                                                    else
                                                    {
                                                        if (Z == -1)
                                                        {
                                                            k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND N.Naziv LIKE '{txtNaslov.Text}%' AND A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                                        }
                                                        else
                                                        {
                                                            if (string.IsNullOrWhiteSpace(txtAutor.Text))
                                                            {
                                                                k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND N.Naziv LIKE '{txtNaslov.Text}%' AND N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND K.Aktuelna = 1 AND K.Dostupna=1";

                                                            }
                                                            else
                                                            {
                                                                if (string.IsNullOrWhiteSpace(txtNaslov.Text))
                                                                    k.GCondition = $"K.IzdavacID = '{((Izdavac)cmbIzdavac.SelectedItem).IzdavacID}' AND N.ZanrID = '{((Zanr)cmbZanr.SelectedItem).ZanrID}' AND A.ImePrezime LIKE '{txtAutor.Text}%' AND K.Aktuelna = 1 AND K.Dostupna=1";
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
          

            try
            {
                Result = new BindingList<Knjiga>(Communication.Instance.VratiKnjigePoKriterijumu(k));
                if (Result.Count != 0)
                {
                    dgvKnjige.DataSource = Result;

                    txtNaslov.Text = "";
                    txtAutor.Text = "";
                    cmbIzdavac.SelectedIndex = -1;
                    cmbIzdavac.Text = "Odaberi izdavača";
                    cmbZanr.SelectedIndex = -1;
                    cmbZanr.Text = "Odaberi žanr";
                }
                else
                {
                    MessageBox.Show("Nema knjiga sa zadatim kriterijumima!");
                    txtNaslov.Text = "";
                    txtAutor.Text = "";
                    cmbIzdavac.SelectedIndex = -1;
                    cmbIzdavac.Text = "Odaberi izdavača";
                    cmbZanr.SelectedIndex = -1;
                    cmbZanr.Text = "Odaberi žanr";
                    btnObrisi.Enabled = false;
                    dgvKnjige.DataSource = null;
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Trenutno je nemoguće izvršiti pretragu!");
                return;
            }
        }

        internal void ObrisiKnjigu(TextBox txtK, DataGridView dgvKnjige)
        {
          
            try
            {
                Knjiga k = new Knjiga
                {
                    GCondition = $"Aktuelna = '{0}' , Dostupna = '{0}'",
                    PrimerakID = int.Parse(txtK.Text)

                };
                
                Communication.Instance.ObrisiKnjigu(k);
                Result.Remove((Knjiga)dgvKnjige.SelectedCells[0].OwningRow.DataBoundItem);
              
                MessageBox.Show("Knjiga je obrisana!");
            }
            catch (Exception)
            {
                MessageBox.Show("Likvidacija knjige nije uspela!");
            }
        }

        internal void ZaduziKnjige(TextBox txtClan, DateTimePicker dtpDatumOd, DateTimePicker dtpDatumDo, RichTextBox txtNapomena)
        {
            try
            {
                if (!UserControlHelpers.EmptyFieldValidation(txtClan))
                {
                    MessageBox.Show("Unesite broj clanske karte!");
                    return;
                }
                if(dtpDatumOd.Value.Date>= dtpDatumDo.Value.Date)
                {
                    MessageBox.Show("Datum vracanja mora biti nakon datuma zaduzenja!");
                    return;
                }
                try
                {
                    int.Parse(txtClan.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravno unet broj clanske karte!");
                    return;
                }
                try
                {
                    Clanarina cl = new Clanarina()
                    {
                        GCondition = $"Cl.ClanID = {txtClan.Text}"
                    };
                    cl = Communication.Instance.ProveriClanarine(cl);
                    if (cl.DatumDo > dtpDatumDo.Value.Date)
                    {
                        if(Odabrane.Count == 0)
                        {
                            MessageBox.Show("Nema odabranih knjiga za zaduživanje!");
                            return;

                        }
                       
                        foreach (Knjiga k in Odabrane)
                        {
                            k.GCondition = $"Dostupna = 0";
                            Zaduzenje z = new Zaduzenje()
                            {
                                Knjiga = k,

                                Clan = new Clan()
                                {
                                    BrojClanskeKarte = int.Parse(txtClan.Text)
                                },
                                DatumOd = dtpDatumOd.Value.Date,
                                DatumDo = dtpDatumDo.Value.Date,
                                Napomena = txtNapomena.Text,
                                Vracena = false

                            };

                            Communication.Instance.ZaduziKnjige(z);
                            Communication.Instance.PostaviZaduzenje(k);
                            
                            

                        }
                        Odabrane.Clear();
                        MessageBox.Show("Knjige su zaduzene!");
                    }
                    else
                    {
                        MessageBox.Show("Nije moguće zadužiti knjige jer članarina ističe!");
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Nije moguće pronaći člana sa unetim brojem članske karte!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Pamćenje zaduženja nije uspelo!");
            }

        }
        internal void VratiNaslov(DataGridView dgvPretraga, TextBox txtKAutor, TextBox txtKNaslov, TextBox txtKZanr)
        {
            try
            {
                Naslov n = (Naslov)dgvPretraga.SelectedCells[0].OwningRow.DataBoundItem;
                n.GCondition = $"NaslovID = {n.NaslovID}";
                n = Communication.Instance.VratiNaslovePoKriterijumu(n)[0];
                txtKAutor.Text = n.Autor.ImePrezime;
                txtKNaslov.Text = n.Naziv;
                txtKZanr.Text = n.Zanr.NazivZanra;
                knjiga.Naslov = n;


            }
            catch (Exception)
            {

                MessageBox.Show("Nije moguće učitati odabrani naslov!");
              
            }


        }
        internal void ZapamtiKnjigu(ComboBox cmbIzdavac, TextBox txtIsbn, TextBox txtGodina, TextBox txtKnjigaID)
        {
            if (!UserControlHelpers.EmptyFieldValidation(txtIsbn)
                | !UserControlHelpers.EmptyFieldValidation(txtGodina)
                | cmbIzdavac.SelectedItem==null
                )
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
            
            Knjiga k = new Knjiga()
            {
                Aktuelna = true,
                Dostupna = true,
                Naslov = knjiga.Naslov,
                Izdavac = (Izdavac)cmbIzdavac.SelectedItem,
                ISBN = txtIsbn.Text,
                Godina = int.Parse(txtGodina.Text)
            };
            knjiga.Naslov = null;
            try
            {
                Communication.Instance.ZapamtiKnjigu(k);
                int id = Communication.Instance.VratiIDKnjige()-1;
                MessageBox.Show("Knjiga je dodata u bazu!");
                txtKnjigaID.Text = Convert.ToString(id);
           


            }
            catch (Exception)
            {
                MessageBox.Show("Pamćenje nove knjige nije uspelo!");
            }
        }
    }
}
