using mpp_proiect_1.model;
using mpp_proiect_1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mpp_proiect_1.client
{
    public class ClientController : IObserver
    {
        public event EventHandler<VoluntarEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IServices server;
        private Voluntar currentUser;

        public ClientController(IServices server)
        {
            this.server = server;
            currentUser = null;
        }



        public void login(String userId, String pass)
        {
            Voluntar user = new Voluntar(Int32.Parse(userId), pass);
            server.login(user, this);
            Console.WriteLine("Login succeeded ....");
            currentUser = user;
            Console.WriteLine("Current user {0}", user);

        }

        public void logout()
        {
            Console.WriteLine("Ctr logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        public Donator[] getDonatori()
        {
            Console.WriteLine("ctr getDonatori");
            return server.getDonatori();

        }

        public Donatie[] getDonatii()
        {
            Console.WriteLine("ctr getDonatii");
            return server.getDonatii();
        }

        public CazCaritabil[] getCazuri()
        {
            Console.WriteLine("ctr getCazuri");
            CazCaritabil[] cazuri = server.getCazuri();
            return cazuri;
        }

       

        protected virtual void OnUserEvent(VoluntarEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public void saveDonator(Donator donator)
        {
            server.addDonator(donator);
        }



        public void updateDonator(Donator donator)
        {
            
            VoluntarEventArgs userArgs = new VoluntarEventArgs(VoluntarEvent.NewDonator, donator);
            OnUserEvent(userArgs);
           

        }

        public void updateSumaCaz(CazCaritabil nou)
        {
            VoluntarEventArgs userArgs = new VoluntarEventArgs(VoluntarEvent.UpdatedCaz, nou);
            OnUserEvent(userArgs);
            server.updateCazCaritabil(nou);
        }

        public void updateSC(CazCaritabil caz)
        {
           
            VoluntarEventArgs userArgs = new VoluntarEventArgs(VoluntarEvent.UpdatedCaz, caz);
            OnUserEvent(userArgs);
           
        }


        public void donatieAdded(Donatie donatie)
        {
            server.addDonatie(donatie);
        }
    }
}
