using Domain;
using Domen;
using Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Helpers;


namespace View
{
    //mogu napraviti za svaku klasu poseban
    public class MainController
    {

        internal void CloseMainForm()
        {
            Communication.Communication.Instance.Disconnect();
            MainCoordinator.Instance.OpenLoginForm();
        }

        internal void OpenUCDodajNovogClana(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCDodajNovogClana());
        }

        internal void OpenUCProveraClanarine(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCProveraClanarine());
        }

        internal void OpenUnosKnjige(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCUnosKnjige());
        }

        internal void OpenUCDodajNaslov(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCDodajNaslov());
        }

        internal void OpenUCPretragaKnjiga(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCPretragaKnjiga());
        }

        internal void OpenUCZaduzivanjeClana(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCZaduzivanjeClana());
        }

        internal void OpenUCRazduzivanjeClana(FrmMain frmMain)
        {
            frmMain.SetPanel(new UCRazduzivanjeClana());
        }
    }
}
