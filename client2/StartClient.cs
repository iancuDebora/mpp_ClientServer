using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Hashtable = System.Collections.Hashtable;
using mpp_proiect_1.services;
using mpp_proiect_1.windows;
using mpp_proiect_1.networking;

namespace mpp_proiect_1.client
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            IServices server = new ServerProxy("127.0.0.1", 55555);
            ClientController ctrl = new ClientController(server);
            LogInWindow win = new LogInWindow(ctrl);
            Application.Run(win);
        }
    }
}
