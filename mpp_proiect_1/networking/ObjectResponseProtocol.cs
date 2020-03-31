using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
	using VoluntarDTO2 = mpp_proiect_1.networking.VoluntarDTO;
	using DonatorDTO2 = mpp_proiect_1.networking.DonatorDTO;
	using CazCaritabilDTO2 = mpp_proiect_1.networking.CazCaritabilDTO;
	using DonatieDTO2 = mpp_proiect_1.networking.DonatieDTO;

	public interface Response
	{
	}

	[Serializable]
	public class OkResponse : Response
	{

	}

	[Serializable]
	public class ErrorResponse : Response
	{
		private string message;

		public ErrorResponse(string message)
		{
			this.message = message;
		}

		public virtual string Message
		{
			get
			{
				return message;
			}
		}
	}

	public interface UpdateResponse : Response
	{
	}

	[Serializable]
	public class GetDonatoriResponse : Response
	{
		private DonatorDTO2[] donatori;

		public GetDonatoriResponse(DonatorDTO2[] donatori)
		{
			this.donatori = donatori;
		}

		public virtual DonatorDTO2[] Donatori
		{
			get
			{
				return donatori;
			}
		}

	}

	[Serializable]
	public class GetCazuriResponse : Response
	{
		private CazCaritabilDTO2[] cazuri;

		public GetCazuriResponse(CazCaritabilDTO[] cazuri)
		{
			this.cazuri = cazuri;
		}

		public virtual CazCaritabilDTO2[] Cazuri
		{
			get
			{
				return cazuri;
			}
		}

	}

	[Serializable]
	public class GetDonatiiResponse : Response
	{
		private DonatieDTO2[] donatii;

		public GetDonatiiResponse(DonatieDTO2[] donatii)
		{
			this.donatii = donatii;
		}

		public virtual DonatieDTO2[] Donatii
		{
			get
			{
				return donatii;
			}
		}
	}


	
	[Serializable]
	public class SaveDonatorResponse : UpdateResponse
	{
		private DonatorDTO donator;

		public SaveDonatorResponse(DonatorDTO2 donator)
		{
			this.donator = donator;
		}

		public virtual DonatorDTO Donator
		{
			get
			{
				return donator;
			}
		}
	}

	[Serializable]
	public class SaveDonatieResponse : UpdateResponse
	{
		private DonatieDTO donatie;

		public SaveDonatieResponse(DonatieDTO donatie)
		{
			this.donatie = donatie;
		}

		public virtual DonatieDTO Add
		{
			get
			{
				return donatie;
			}

		}
	}

	[Serializable]
	public class UpdateCazResponse : UpdateResponse
	{
		private CazCaritabilDTO caz;

		public UpdateCazResponse(CazCaritabilDTO2 caz)
		{
			this.caz = caz;
		}

		public virtual CazCaritabilDTO Caz
		{
			get
			{
				return caz;
			}
		}
	}

}
