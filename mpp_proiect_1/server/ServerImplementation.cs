
using mpp_proiect_1.model;
using mpp_proiect_1.repository;
using mpp_proiect_1.services;
using mpp_proiect_1.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1
{
    class ServerImplementation : IServices
    {
        
        private IVoluntarRepository voluntarRepo;
        private ICazCaritabilRepository cazCaritabilRepo;
        private IDonatorRepository donatorRepo;
        private IDonatieRepository donatieRepo;
        private IValidator<Donator> validatorDonator;
        private IValidator<Donatie> validatorDonatie;
        private readonly IDictionary<int, IObserver> loggedClients;

        public ServerImplementation(IVoluntarRepository voluntarRepo, 
            ICazCaritabilRepository cazCaritabilRepo, 
            IDonatorRepository donatorRepo, 
            IDonatieRepository donatieRepo, IValidator<Donator> validatorDonator,
            IValidator<Donatie> validatorDonatie)
        {
            this.voluntarRepo = voluntarRepo;
            this.cazCaritabilRepo = cazCaritabilRepo;
            this.donatorRepo = donatorRepo;
            this.donatieRepo = donatieRepo;
            this.validatorDonator = validatorDonator;
            this.validatorDonatie = validatorDonatie;
            loggedClients = new Dictionary<int, IObserver>();
        }

        public void login(Voluntar voluntar, IObserver client)
        {
            Voluntar voluntarOk = voluntarRepo.findBy(voluntar.Id,voluntar.Parola);
            if (voluntarOk != null)
            {
                if (loggedClients.ContainsKey(voluntar.Id))
                    throw new MyException("Voluntar already logged in.");
                loggedClients[voluntar.Id] = client;
                
            }
            else
                throw new MyException("Authentication failed.");
        }
 

        public void logout(Voluntar voluntar, IObserver client)
        {
            IObserver localClient = loggedClients[voluntar.Id];
            if (localClient == null)
                throw new MyException("Voluntar " + voluntar.Id + " is not logged in.");
            loggedClients.Remove(voluntar.Id);
            
        }


        public Donator[] getDonatori()
        {
            IEnumerable<Donator> donatori = donatorRepo.findAll();
            IList<Donator> result = new List<Donator>();
            result = donatori.ToList();
            Console.WriteLine("All donatori");

            Console.WriteLine("Size " + result.Count);
            return result.ToArray();
        }

        public CazCaritabil[] getCazuri()
        {
            IEnumerable<CazCaritabil> cazuri = cazCaritabilRepo.findAll();

            Console.WriteLine("Size " + cazuri.ToList().Count);
            return cazuri.ToArray();
        }

        public Donatie[] getDonatii()
        {
            IEnumerable<Donatie> donatii = donatieRepo.findAll();

            Console.WriteLine("Size " + donatii.ToList().Count);
            return donatii.ToArray();
        }
        public void addDonator(Donator donator)
        {
            IEnumerable<Voluntar> allVol = voluntarRepo.findAll();
            

           foreach (Voluntar vol in allVol)
            {
                if (loggedClients.ContainsKey(vol.Id))
                {
                    IObserver Client = loggedClients[vol.Id];
                    Task.Run(() => Client.updateDonator(donator));
                }
            }
            
            donatorRepo.save(donator);
        }

        public void addDonatie(Donatie donatie)
        {
            
            donatieRepo.save(donatie);
        }


        public void updateCazCaritabil(CazCaritabil entity)
        {
            IEnumerable<Voluntar> allVol = voluntarRepo.findAll();
            

            foreach (Voluntar vol in allVol)
            {
                if (loggedClients.ContainsKey(vol.Id))
                {
                    IObserver Client = loggedClients[vol.Id];
                    Task.Run(() => Client.updateSC(entity));
                }
            }
            cazCaritabilRepo.update2(entity);
        }


    }
}