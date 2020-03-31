using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
    [Serializable]
    public class DonatorDTO
    {
        private int id;
        private string nume;
        private string adresa;
        private long nrTelefon;



		public DonatorDTO(int id) : this(id,"","",0)
		{

		}
        public DonatorDTO(int id, string nume, string adresa, long nrTelefon)
        {
            this.id = id;
            this.nume = nume;
            this.adresa = adresa;
            this.nrTelefon = nrTelefon;
        }

		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		public virtual string Nume
		{
			get
			{
				return nume;
			}
		}

		public virtual string Adresa
		{
			get
			{
				return adresa;
			}
		}

		public virtual long NeTelefon
		{
			get
			{
				return nrTelefon;
			}
		}
	}
}
