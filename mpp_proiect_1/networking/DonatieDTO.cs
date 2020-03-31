using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
    [Serializable]
    public class DonatieDTO
    {
        private int id;
        private int idD;
        private int idC;
        private double sumaDonatie;

        public DonatieDTO(int id, int idD, int idC, double sumaDonatie)
        {
            this.id = id;
            this.idD = idD;
            this.idC = idC;
            this.sumaDonatie = sumaDonatie;
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


		public virtual int IdD
		{
			get
			{
				return idD;
			}
		}

		public virtual int IdC
		{
			get
			{
				return idC;
			}
		}

		public virtual double SumaDonatie
		{
			get
			{
				return sumaDonatie;
			}
		}

	}
}
