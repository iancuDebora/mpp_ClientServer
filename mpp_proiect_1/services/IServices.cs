using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.services
{
    public interface IServices

    {
        void login(Voluntar voluntar, IObserver client);
       
        void logout(Voluntar voluntar, IObserver client);
        
        Donator[] getDonatori();

        CazCaritabil[] getCazuri();

        Donatie[] getDonatii();

        void addDonator(Donator donator);

        void addDonatie(Donatie donatie);

        void updateCazCaritabil(CazCaritabil nou);

    }
}
