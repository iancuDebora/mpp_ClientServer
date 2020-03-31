using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{


	public class DTOUtils
	{
		public static Voluntar getFromDTO(VoluntarDTO voldto)
		{
			int id = voldto.Id;
			string pass = voldto.Parola;
			
			return new Voluntar(id, pass);

		}

		public static Donator getFromDTO(DonatorDTO donDTO)
		{
			int id = donDTO.Id;
			string nume = donDTO.Nume;
			string adresa = donDTO.Adresa;
			long nrTelefon = donDTO.NeTelefon;
			return new Donator(id, nume, adresa, nrTelefon);
		}

		public static CazCaritabil getFromDTO(CazCaritabilDTO cazDTO)
		{
			int id = cazDTO.Id;
			string denumire = cazDTO.Denumire;
			double sumaTotala = cazDTO.SumaTotala;
			return new CazCaritabil(id, denumire, sumaTotala);
		}

		public static VoluntarDTO getDTO(Voluntar voluntar)
		{
			int id = voluntar.Id;
			string pass = voluntar.Parola;
			return new VoluntarDTO(id, pass);
		}

		public static CazCaritabilDTO getDTO(CazCaritabil caz)
		{
			int id = caz.Id;
			string denumire = caz.Denumire;
			double sumaTotala = caz.SumaTotala;
			return new CazCaritabilDTO(id, denumire,sumaTotala);
		}

		public static DonatorDTO getDTO(Donator donator)
		{
			int id = donator.Id;
			string nume = donator.Nume;
			string adresa = donator.Adresa;
			long nrTelefon = donator.NrTelefon;
			return new DonatorDTO(id, nume, adresa, nrTelefon);
		}

		public static DonatieDTO getDTO(Donatie donatie)
		{
			int id = donatie.Id;
			int idD = donatie.IdD;
			int idC = donatie.IdC;
			double sumaDonatie = donatie.Suma;
			return new DonatieDTO(id, idD, idC, sumaDonatie);
		}

		public static Donatie getFromDTO(DonatieDTO donatie)
		{
			int id = donatie.Id;
			int idD = donatie.IdD;
			int idC = donatie.IdC;
			double sumaDonatie = donatie.SumaDonatie;
			return new Donatie(id, idD, idC, sumaDonatie);
		}
		public static VoluntarDTO[] getDTO(Voluntar[] voluntari)
		{
			VoluntarDTO[] frDTO = new VoluntarDTO[voluntari.Length];
			for (int i = 0; i < voluntari.Length; i++)
			{
				frDTO[i] = getDTO(voluntari[i]);
			}
			return frDTO;
		}

		public static DonatorDTO[] getDTO(Donator[] donatori)
		{
			DonatorDTO[] frDTO = new DonatorDTO[donatori.Length];
			for (int i=0;i<donatori.Length;i++)
			{
				frDTO[i] = getDTO(donatori[i]);
			}
			return frDTO;
		}

		public static DonatieDTO[] getDTO(Donatie[] donatii)
		{
			DonatieDTO[] frDTO = new DonatieDTO[donatii.Length];
			for (int i = 0; i < donatii.Length; i++)
			{
				frDTO[i] = getDTO(donatii[i]);
			}
			return frDTO;
		}

		public static CazCaritabilDTO[] getDTO(CazCaritabil[] cazuri)
		{
			CazCaritabilDTO[] frDTO = new CazCaritabilDTO[cazuri.Length];
			for (int i=0;i<cazuri.Length;i++)
			{
				frDTO[i] = getDTO(cazuri[i]);
			}
			return frDTO;
		}

		public static Voluntar[] getFromDTO(VoluntarDTO[] voluntari)
		{
			Voluntar[] allVol = new Voluntar[voluntari.Length];
			for (int i = 0; i < voluntari.Length; i++)
			{
				allVol[i] = getFromDTO(voluntari[i]);
			}
			return allVol;
		}

		public static Donator[] getFromDTO(DonatorDTO[] donatori)
		{
			Donator[] don = new Donator[donatori.Length];
			for (int i = 0; i<donatori.Length;i++)
			{
				don[i] = getFromDTO(donatori[i]);
			}
			return don;
		}

		public static Donatie[] getFromDTO(DonatieDTO[] donatii)
		{
			Donatie[] don = new Donatie[donatii.Length];
			for (int i = 0; i < donatii.Length; i++)
			{
				don[i] = getFromDTO(donatii[i]);
			}
			return don;
		}

		public static CazCaritabil[] getFromDTO(CazCaritabilDTO[] cazuri)
		{
			CazCaritabil[] cazuri2 = new CazCaritabil[cazuri.Length];
			for (int i = 0; i < cazuri.Length; i++)
			{
				cazuri2[i] = getFromDTO(cazuri[i]);
			}
			return cazuri2;
		}
	}

}