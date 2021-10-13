
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using View;

namespace View
{
    public partial class FrmMain : Form
    {
        private readonly MainController mainController;

        public FrmMain(MainController mainController)
        {
            InitializeComponent();
            this.mainController = mainController;
        }

   

        private void EditProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // SetPanel(new UCUser(mainController));
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Environment.Exit(0);
            mainController.CloseMainForm();
           
        }

    

   

        public void SetPanel(UserControl userControl)
        {
            pnlMain.Controls.Clear();
            userControl.Parent = pnlMain;
            userControl.Dock = DockStyle.Fill;
        }

      

        
         private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void proveraClanarineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCProveraClanarine(this);
        }

        private void noviClanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCDodajNovogClana(this);

        }

        private void unosKnjigeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUnosKnjige(this);

        }

        private void unosNaslovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCDodajNaslov(this);
        }

        private void pretragaNaslovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCPretragaKnjiga(this);
        }

        private void zaduživanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCZaduzivanjeClana(this);
        }

        private void razduživanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenUCRazduzivanjeClana(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
