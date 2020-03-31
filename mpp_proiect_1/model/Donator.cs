using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.model
{
    public class Donator : HasId<int>
    {
        private int id;
        private String nume;
        private String adresa;
        private long nrTelefon;

        public Donator(int id, string nume, string adresa, long nrTelefon)
        {
            this.id = id;
            this.nume = nume;
            this.adresa = adresa;
            this.nrTelefon = nrTelefon;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }

        public String Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public long NrTelefon
        {
            get { return nrTelefon; }
            set { nrTelefon = value; }
        }

        public override bool Equals(object obj)
        {
            var donator = obj as Donator;
            return donator != null &&
                   Id == donator.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[Donator: Id={0}, Nume={1}, Adresa={2}, NrTelefon={3}]", Id, Nume, Adresa, NrTelefon);
        }
    }
}
