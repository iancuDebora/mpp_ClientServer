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
    public class VoluntarDbRepository : IVoluntarRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public VoluntarDbRepository()
        {
            log.Info("Creating VoluntarTaskDbRepository");
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Voluntar> findAll()
        {
            log.Info("Entering findAll - Voluntari");
            IDbConnection con = DBUtils.getConnection();
            IList<Voluntar> voluntari = new List<Voluntar>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,email, parola from voluntari";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String email = dataR.GetString(2);
                        String parola = dataR.GetString(3);
                     
                        Voluntar voluntar = new Voluntar(id, nume, email, parola);
                        voluntari.Add(voluntar);
                    }
                }
            }
            log.Info("Exiting findAll - Voluntari");
            return voluntari;
        }

        public Voluntar findBy(int id, string parola)
        {
            Console.WriteLine("VoluntarDB [findBy]");
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select nume,email from voluntari where id=@id and parola=@pass";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@pass";
                paramPass.Value = parola;
                comm.Parameters.Add(paramPass);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Voluntar voluntar = new Voluntar(id);
                        voluntar.Nume = dataR.GetString(0);
                        voluntar.Email = dataR.GetString(1);
                        return voluntar;
                    }
                }
            }

            return null;
        }

        public Voluntar findOne(int id)
        {

            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume, email,parola from voluntari where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String email = dataR.GetString(2);
                        String parola = dataR.GetString(3);

                        Voluntar vol = new Voluntar(idV, nume, email, parola);
                        log.InfoFormat("Exiting findOne with value {0}", vol);
                        return vol;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Voluntar entity)
        {
            log.InfoFormat("Entering save with entity {0}", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into voluntari values (@id, @nume, @email, @parola)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.Email;
                comm.Parameters.Add(paramEmail);

                var paramParola = comm.CreateParameter();
                paramParola.ParameterName = "@parola";
                paramParola.Value = entity.Parola;
                comm.Parameters.Add(paramParola);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No voluntar added !");
            }
            log.Info("Exiting save - Voluntar");
        }

        public void update(Voluntar old, Voluntar entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
