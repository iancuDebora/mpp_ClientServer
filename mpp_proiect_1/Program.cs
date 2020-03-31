using log4net.Config;

using mpp_proiect_1.model;
using mpp_proiect_1.repository;
using mpp_proiect_1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//[assembly : log4net.Config.XmlConfigurator(Watch = true)]
namespace mpp_proiect_1
{/*
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            VoluntarDbRepository vRepo = new VoluntarDbRepository();
            VoluntarService volServ = new VoluntarService(vRepo);
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new LogInWindow(volServ));
            DonatorDbRepository repo = new DonatorDbRepository();
            
           /* Console.WriteLine("aiciiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
            Console.WriteLine(repo.findOne(1).ToString());
           // repo.save(new model.Donator(3, "nume", "adresa", 09992838));
            repo.findAll().ToList().ForEach(s => Console.WriteLine(s.ToString()));
            //repo.delete(2);
            Console.WriteLine("aiciiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
            repo.findAll().ToList().ForEach(s => Console.WriteLine(s.ToString()));
            Donator d = new Donator(3, "updated", "upd", 999999);
            repo.update(repo.findOne(3), d);
            Console.WriteLine(repo.findOne(3).ToString());
            
            

        }
    }*/
}
