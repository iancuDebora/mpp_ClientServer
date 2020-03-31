using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{

	[Serializable]
	public class VoluntarDTO
	{
		private int id;
		private string parola;

		public VoluntarDTO(int id) : this(id, "")
		{
		}

		public VoluntarDTO(int id, string parola)
		{
			this.id = id;
			this.parola = parola;
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


		public virtual string Parola
		{
			get
			{
				return parola;
			}
		}
	}

}