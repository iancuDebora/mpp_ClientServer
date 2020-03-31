using log4net;
using mpp_proiect_1.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_proiect_1.repository
{
    public class DonatieDbRepository : IDonatieRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DonatieDbRepository()
        {
            log.Info("Creating DonatorTaskDbRepository");
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Donatie> findAll()
        {
            log.Info("Entering findAll - Donatie");
            IDbConnection con = DBUtils.getConnection();
            IList<Donatie> donatii = new List<Donatie>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,idD,idC,suma from donatii";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int idD = dataR.GetInt32(1);
                        int idC = dataR.GetInt32(2);
                        Double suma = dataR.GetDouble(3);

                        Donatie donatie = new Donatie(id, idD, idC, suma);
                        donatii.Add(donatie);
                    }
                }
            }
            log.Info("Exiting findAll - Donatii");
            return donatii;
        }

        public Donatie findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Donatie entity)
        {
            log.InfoFormat("Entering save with entity {0}", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into donatii values (@id, @idD, @idC, @suma)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                Console.WriteLine("44444444444444444444444444444"+entity.Id);
                comm.Parameters.Add(paramId);

                var paramIdD = comm.CreateParameter();
                paramIdD.ParameterName = "@idD";
                paramIdD.Value = entity.IdD;
                comm.Parameters.Add(paramIdD);

                var paramIdC = comm.CreateParameter();
                paramIdC.ParameterName = "@idC";
                paramIdC.Value = entity.IdC;
                comm.Parameters.Add(paramIdC);

                var paramSuma = comm.CreateParameter();
                paramSuma.ParameterName = "@suma";
                paramSuma.Value = entity.Suma;
                comm.Parameters.Add(paramSuma);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No task added !");
            }
            log.Info("Exiting save - Donatie");
        }

        public void update(Donatie old, Donatie entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
