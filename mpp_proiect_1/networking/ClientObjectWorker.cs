using mpp_proiect_1.model;
using mpp_proiect_1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mpp_proiect_1.networking
{
	public class ClientWorker : IObserver 
	{
		private IServices server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public ClientWorker(IServices server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{

				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				connected = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public void donatieAdded(Donatie donatie)
		{
			DonatieDTO dto = DTOUtils.getDTO(donatie);
			Console.WriteLine("Donatie received  " + donatie);
			try
			{
				sendResponse(new SaveDonatieResponse(dto));
			}
			catch (Exception e)
			{
				throw new MyException("Sending error: " + e);
			}
		}

		public virtual void run()
		{
			while (connected)
			{
				try
				{
					object request = formatter.Deserialize(stream);
					object response = handleRequest((Request)request);
					if (response != null)
					{
						sendResponse((Response)response);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}

				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error " + e);
			}
		}

		public void updateDonator(Donator donator)
		{

			DonatorDTO dto = DTOUtils.getDTO(donator);
			Console.WriteLine("Donator received  " + donator);
			try
			{
				sendResponse(new SaveDonatorResponse(dto));
			}
			catch (Exception e)
			{
				throw new MyException("Sending error: " + e);
			}
		}

		public void updateSC(CazCaritabil caz)
		{
			CazCaritabilDTO dto = DTOUtils.getDTO(caz);
			Console.WriteLine("CazCaritabil received  " + caz);
			try
			{
				sendResponse(new UpdateCazResponse(dto));
			}
			catch (Exception e)
			{
				throw new MyException("Sending error: " + e);
			}
		}

		private Response handleRequest(Request request)
		{
			Response response = null;

			if (request is GetCazuriRequest)
			{
				Console.WriteLine("GetCazuriRequest.....");
				GetCazuriRequest getReq = (GetCazuriRequest)request;
				try
				{
					CazCaritabil[] allCazuri;
					lock (server)
					{
						allCazuri = server.getCazuri();
					}

					CazCaritabilDTO[] frDTO = DTOUtils.getDTO(allCazuri);
					return new GetCazuriResponse(frDTO);
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if (request is GetDonatiiRequest)
			{
				Console.WriteLine("GetDonatiiRequest.....");
				GetDonatiiRequest getReq = (GetDonatiiRequest)request;
				try
				{
					Donatie[] allDonatii;
					lock (server)
					{
						allDonatii = server.getDonatii();
					}

					DonatieDTO[] frDTO = DTOUtils.getDTO(allDonatii);
					return new GetDonatiiResponse(frDTO);
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}


			if (request is GetDonatoriRequest)
			{
				Console.WriteLine("GetDonatoriRequest.....");
				GetDonatoriRequest getReq = (GetDonatoriRequest)request;
				try
				{
					Donator[] allDonatori;
					lock (server)
					{
						allDonatori = server.getDonatori();
					}

					DonatorDTO[] frDTO = DTOUtils.getDTO(allDonatori);
					return new GetDonatoriResponse(frDTO);
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq = (LoginRequest)request;
				VoluntarDTO udto = logReq.User;
				Voluntar user = DTOUtils.getFromDTO(udto);
				try
				{
					lock (server)
					{
						server.login(user, this);
					}
					return new OkResponse();
				}
				catch (MyException e)
				{
					connected = false;
					return new ErrorResponse(e.Message);
				}
			}
			if (request is LogoutRequest)
			{
				Console.WriteLine("Logout request");
				LogoutRequest logReq = (LogoutRequest)request;
				VoluntarDTO udto = logReq.User;
				Voluntar user = DTOUtils.getFromDTO(udto);
				try
				{
					lock (server)
					{

						server.logout(user, this);
					}
					connected = false;
					return new OkResponse();

				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}

			if (request is SaveDonatorRequest)
			{
				Console.WriteLine("SaveDonatorRequest ...");
				SaveDonatorRequest senReq = (SaveDonatorRequest)request;
				DonatorDTO mdto = senReq.Add;
				Donator message = DTOUtils.getFromDTO(mdto);
				try
				{
					lock (server)
					{
						server.addDonator(message);
					}
					return new OkResponse();
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is SaveDonatieRequest)
			{
				Console.WriteLine("SaveDonatieRequest ...");
				SaveDonatieRequest senReq = (SaveDonatieRequest)request;
				DonatieDTO mdto = senReq.Add;
				Donatie message = DTOUtils.getFromDTO(mdto);
				try
				{
					lock (server)
					{
						server.addDonatie(message);
					}
					return new OkResponse();
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			if (request is UpdateCazRequest)
			{
				Console.WriteLine("UpdateCazRequest ...");
				UpdateCazRequest upReq = (UpdateCazRequest)request;
				CazCaritabilDTO cazDTO = upReq.Caz;
				CazCaritabil caz = DTOUtils.getFromDTO(cazDTO);
				try
				{
					lock (server)
					{
						server.updateCazCaritabil(caz);
					}
					return new OkResponse();
				}
				catch (MyException e)
				{
					return new ErrorResponse(e.Message);
				}
			}
			return response;
		

		}

		private void sendResponse(Response response)
		{
			Console.WriteLine("sending response " + response);
			formatter.Serialize(stream, response);
			stream.Flush();

		}
	}

}
