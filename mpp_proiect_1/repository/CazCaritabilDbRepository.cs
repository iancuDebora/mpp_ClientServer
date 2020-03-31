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
    public class CazCaritabilDbRepository : ICazCaritabilRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CazCaritabilDbRepository()
        {
            log.Info("Creating CazCaritabilTaskDbRepository");
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CazCaritabil> findAll()
        {
            log.Info("Entering findAll - CazCaritabil");
            IDbConnection con = DBUtils.getConnection();
            IList<CazCaritabil> cazuri = new List<CazCaritabil>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, denumire, sumaTotala from cazuriCaritabile";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String denumire = dataR.GetString(1);
                        Double sumaTotala = dataR.GetDouble(2);

                        CazCaritabil caz = new CazCaritabil(id, denumire, sumaTotala);
                        cazuri.Add(caz);
                    }
                }
            }
            log.Info("Exiting findAll - CazCaritabil");
            return cazuri;
        }

        public CazCaritabil findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(CazCaritabil entity)
        {

            log.InfoFormat("Entering save with entity {0}", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into cazuriCaritabile values (@id, @denumire, @sumaTotala)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramDenumire = comm.CreateParameter();
                paramDenumire.ParameterName = "@denumire";
                paramDenumire.Value = entity.Denumire;
                comm.Parameters.Add(paramDenumire);

                var paramSumaTotala = comm.CreateParameter();
                paramSumaTotala.ParameterName = "@sumaTotala";
                paramSumaTotala.Value = entity.SumaTotala;
                comm.Parameters.Add(paramSumaTotala);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No cazCaritabil added !");
            }
            log.Info("Exiting save - CazCaritabil");
        }

        public void update2(CazCaritabil entity)
        {
            log.InfoFormat("Entering update with values {0},{1} - CazCaritabil", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update cazuriCaritabile set denumire=@denumire, sumaTotala=@sumaTotala where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramDenumire = comm.CreateParameter();
                paramDenumire.ParameterName = "@denumire";
                paramDenumire.Value = entity.Denumire;
                comm.Parameters.Add(paramDenumire);

                var paramSumaTotala = comm.CreateParameter();
                paramSumaTotala.ParameterName = "@sumaTotala";
                paramSumaTotala.Value = entity.SumaTotala;
                comm.Parameters.Add(paramSumaTotala);
                

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No case updated !");
            }

            log.Info("Exiting update - CazCaritabil");
        }

        public void update(CazCaritabil old, CazCaritabil entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
