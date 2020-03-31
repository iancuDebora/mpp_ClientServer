using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
    [Serializable]
    public class CazCaritabilDTO
    {
        private int id;
        private String denumire;
        private double sumaTotala;

		public CazCaritabilDTO(int id, string denumire, double sumaTotala)
		{
			this.id = id;
			this.denumire = denumire;
			this.sumaTotala = sumaTotala;
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

		public virtual string Denumire
		{
			get
			{
				return denumire;
			}
		}

		public virtual double SumaTotala
		{
			get
			{
				return sumaTotala;
			}
		}


	}
}
