using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.server
{
    using mpp_proiect_1.model;
    using mpp_proiect_1.networking;
    using mpp_proiect_1.repository;
    using mpp_proiect_1.services;
    using mpp_proiect_1.validators;
    using server;
    using System.Net.Sockets;
    using System.Threading;

    class StartServer
    {
        static void Main(string[] args)
        {

            VoluntarDbRepository voluntarRepository = new VoluntarDbRepository();
            DonatorDbRepository donatorRepository = new DonatorDbRepository();
            CazCaritabilDbRepository cazCaritabilRepository = new CazCaritabilDbRepository();
            DonatieDbRepository donatieRepository = new DonatieDbRepository();
            IValidator<Donator> valDonator = new DonatorValidator();
            IValidator<Donatie> valDonatie = new DonatieValidator();
            
            IServices serviceImpl = new ServerImplementation(voluntarRepository, cazCaritabilRepository, 
                donatorRepository, donatieRepository, valDonator,valDonatie);

            
            SerialServer server = new SerialServer("127.0.0.1", 55555, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            
            Console.ReadLine();

        }
    }

    public class SerialServer : ConcurrentServer
    {
        private IServices server;
        private ClientWorker worker;
        public SerialServer(string host, int port, IServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            Console.WriteLine("create worker");
            worker = new ClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }

}
