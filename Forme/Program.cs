﻿using View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forme.Exceptions;

namespace View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FrmLogin());
            while (true)
            {
                try
                {
                    MainCoordinator.Instance.OpenLoginForm();
                    Application.Run();
                }
                catch (ServerException se)
                {
                    MessageBox.Show(se.Message);
                    Console.WriteLine(se.Message);
                }
            }
        }
    }
}
