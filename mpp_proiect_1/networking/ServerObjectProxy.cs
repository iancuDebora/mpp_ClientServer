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
	
	public class ServerProxy : IServices
	{
		private string host;
		private int port;

		private IObserver client;

		private NetworkStream stream;

		private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
		private EventWaitHandle _waitHandle;
		public ServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses = new Queue<Response>();
		}

		public virtual void login(Voluntar voluntar, IObserver client)
		{
			initializeConnection();
			VoluntarDTO vdto = DTOUtils.getDTO(voluntar);
			sendRequest(new LoginRequest(vdto));
			Response response = readResponse();
			if (response is OkResponse)
			{
				this.client = client;

				return;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				closeConnection();
				throw new MyException(err.Message);
			}
		}

		public virtual void logout(Voluntar voluntar, IObserver client)
		{
			VoluntarDTO udto = DTOUtils.getDTO(voluntar);
			sendRequest(new LogoutRequest(udto));
			Response response = readResponse();
			closeConnection();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
		}


		public virtual Donator[] getDonatori()
		{
			sendRequest(new GetDonatoriRequest());
			Response response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
			GetDonatoriResponse resp = (GetDonatoriResponse)response;
			DonatorDTO[] frDTO = resp.Donatori;

			Donator[] donatori = DTOUtils.getFromDTO(frDTO);
			return donatori;
		}

		public virtual CazCaritabil[] getCazuri()
		{
			sendRequest(new GetCazuriRequest());
			Response response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
			GetCazuriResponse resp = (GetCazuriResponse)response;
			CazCaritabilDTO[] frDTO = resp.Cazuri;

			CazCaritabil[] donatori = DTOUtils.getFromDTO(frDTO);
			return donatori;
		}

		public virtual Donatie[] getDonatii()
		{
			sendRequest(new GetDonatiiRequest());
			Response response = readResponse();
			if (response is ErrorResponse)
			{

				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
            }
			GetDonatiiResponse resp = (GetDonatiiResponse)response;
			DonatieDTO[] frDTO = resp.Donatii;

			Donatie[] donatii = DTOUtils.getFromDTO(frDTO);
			return donatii;
		}

		private void closeConnection()
		{
			finished = true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
				_waitHandle.Close();
				client = null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
				formatter.Serialize(stream, request);
				stream.Flush();
			}
			catch (Exception e)
			{
				throw new MyException("Error sending object " + e);
			}

		}

		private Response readResponse()
		{
			Response response = null;
			try
			{
				_waitHandle.WaitOne();
				lock (responses)
				{
					//Monitor.Wait(responses); 
					response = responses.Dequeue();

				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{

			try
			{
				connection = new TcpClient(host, port);
				stream = connection.GetStream();
				formatter = new BinaryFormatter();
				finished = false;
				_waitHandle = new AutoResetEvent(false);
				startReader();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}
		private void startReader()
		{
			Thread tw = new Thread(run);
			tw.Start();
		}


		private void handleUpdate(UpdateResponse update)
		{
			if (update is UpdateCazResponse)
			{
				UpdateCazResponse frUpd = (UpdateCazResponse)update;
				CazCaritabil caz = DTOUtils.getFromDTO(frUpd.Caz);
				Console.WriteLine("Updated caz " + caz);
				try
				{
					client.updateSC(caz);
				}
				catch (MyException e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
			if (update is SaveDonatorResponse)
			{
				SaveDonatorResponse donRes = (SaveDonatorResponse)update;
				Donator donator = DTOUtils.getFromDTO(donRes.Donator);
				try
				{
					client.updateDonator(donator);
				}
				catch (MyException e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}

			if (update is SaveDonatieResponse)
			{
				SaveDonatieResponse donRes = (SaveDonatieResponse)update;
				Donatie donatie = DTOUtils.getFromDTO(donRes.Add);
				try
				{
					client.donatieAdded(donatie);
				}
				catch (MyException e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
		}

		public virtual void run()
		{
			while (!finished)
			{
				try
				{
					object response = formatter.Deserialize(stream);
					Console.WriteLine("response received " + response);
					if (response is UpdateResponse)
					{
						handleUpdate((UpdateResponse)response);
					}

					else
					{

						lock (responses)
						{


							responses.Enqueue((Response)response);

						}
						_waitHandle.Set();
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("Reading error " + e);
				}

			}
		}

		public void addDonator(Donator donator)
		{
			DonatorDTO donatorDTO = DTOUtils.getDTO(donator);
			sendRequest(new SaveDonatorRequest(donatorDTO));
			Response response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
		}

		public void addDonatie(Donatie donatie)
		{
			DonatieDTO donatieDTO = DTOUtils.getDTO(donatie);
			sendRequest(new SaveDonatieRequest(donatieDTO));
			Response response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
		}

		public void updateCazCaritabil(CazCaritabil nou)
		{
			CazCaritabilDTO newDTO = DTOUtils.getDTO(nou);
			sendRequest(new UpdateCazRequest(newDTO));
			Response response = readResponse();
			if (response is ErrorResponse)
			{
				ErrorResponse err = (ErrorResponse)response;
				throw new MyException(err.Message);
			}
		}

		//}
	}

}