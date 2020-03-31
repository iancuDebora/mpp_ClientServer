using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
	using VoluntarDTO2 = mpp_proiect_1.networking.VoluntarDTO;
	using DonatorDTO2 = mpp_proiect_1.networking.DonatorDTO;
	using DonatieDTO2 = mpp_proiect_1.networking.DonatieDTO;

	public interface Request
	{
	}


	[Serializable]
	public class LoginRequest : Request
	{
		private VoluntarDTO2 user;

		public LoginRequest(VoluntarDTO2 user)
		{
			this.user = user;
		}

		public virtual VoluntarDTO2 User
		{
			get
			{
				return user;
			}
		}
	}

	[Serializable]
	public class LogoutRequest : Request
	{
		private VoluntarDTO2 user;

		public LogoutRequest(VoluntarDTO2 user)
		{
			this.user = user;
		}

		public virtual VoluntarDTO2 User
		{
			get
			{
				return user;
			}
		}
	}


	[Serializable]
	public class SaveDonatorRequest : Request
	{
		private DonatorDTO donator;

		public SaveDonatorRequest(DonatorDTO2 donator)
		{
			this.donator = donator;
		}

		public virtual DonatorDTO Add
		{
			get
			{
				return donator;
			}
		}

	}

	[Serializable]
	public class SaveDonatieRequest : Request
	{
		private DonatieDTO donatie;

		public SaveDonatieRequest(DonatieDTO donatie)
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

	public class GetDonatoriRequest : Request
	{
		public GetDonatoriRequest() { }

		public virtual DonatorDTO2 All
		{
			get
			{
				return All;
			}
		}

	}

	[Serializable]
	public class GetCazuriRequest : Request
	{
		public GetCazuriRequest() { }

	}

	[Serializable]
	public class GetDonatiiRequest : Request
	{
		public GetDonatiiRequest() { }

		public virtual DonatieDTO2 All
		{
			get
			{
				return All;
			}
		}

	}

	[Serializable]
	public class UpdateCazRequest : Request
	{
		private CazCaritabilDTO caz;

		public UpdateCazRequest(CazCaritabilDTO caz)
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
