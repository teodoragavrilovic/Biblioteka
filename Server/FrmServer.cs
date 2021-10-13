﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server s;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            //osvezavanje labele sa vremenom
            Thread t = new Thread(RefreshTime);
            t.IsBackground = true;
            t.Start();

            Timer timer = new Timer();
            timer.Interval = 1000;
           
            timer.Start();
        }

      

        private void RefreshTime()
        {
            while (true)
            {
                lblTime.Invoke(new Action(() => lblTime.Text = DateTime.Now.ToString("dd. MM. yyyy. HH:mm:ss")));
                Thread.Sleep(1000);
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s = new Server();
                s.Start();
                Thread thread = new Thread(s.Listen);
                thread.IsBackground = true;
                thread.Start();
                button1.Enabled = false;
                button2.Enabled = true;
                s.Users.ListChanged += Users_ListChanged;
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Users_ListChanged(object sender, ListChangedEventArgs e)
        {
            dgvClient.Invoke(new Action(() => dgvClient.DataSource = s.Users.ToList()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
