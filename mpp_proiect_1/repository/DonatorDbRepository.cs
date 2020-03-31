using log4net;
using mpp_proiect_1.model;
using mpp_proiect_1.repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace mpp_proiect_1.repository
{
    public class DonatorDbRepository : IDonatorRepository
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DonatorDbRepository()
        {
            log.Info("Creating DonatorTaskDbRepository");
        }

        public Donator findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume, adresa, nrTelefon from donatori where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idD = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String adresa = dataR.GetString(2);
                        long nrTelefon = dataR.GetInt64(3);
                         Donator donator = new Donator(idD, nume, adresa, nrTelefon); 
                        log.InfoFormat("Exiting findOne with value {0}", donator);
                        return donator;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Donator> findAll()
        {
            log.Info("Entering findAll - Donator");
            IDbConnection con = DBUtils.getConnection();
            IList<Donator> donatori = new List<Donator>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,adresa,nrTelefon from donatori";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idD = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String adresa = dataR.GetString(2);
                        long nrTelefon = dataR.GetInt64(3);
                        
                        Donator donator = new Donator(idD, nume, adresa, nrTelefon);
                        donatori.Add(donator);
                    }
                
                }
                
            }
           log.Info("Exiting findAll - Donator");
            return donatori;
        }
        public void save(Donator entity)
        {
            log.InfoFormat("Entering save with entity {0}", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into donatori values (@idD, @nume, @adresa, @nrTelefon)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idD";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramAdresa = comm.CreateParameter();
                paramAdresa.ParameterName = "@adresa";
                paramAdresa.Value = entity.Adresa;
                comm.Parameters.Add(paramAdresa);

                var paramNrTelefon = comm.CreateParameter();
                paramNrTelefon.ParameterName = "@nrTelefon";
                paramNrTelefon.Value = entity.NrTelefon;
                comm.Parameters.Add(paramNrTelefon);
              
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No donator added !");
            }
            log.Info("Exiting save - Donator");

        }
        public void delete(int id)
        {
            log.InfoFormat("Entering save with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from donatori where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No donator deleted!");
            }
            log.Info("Exiting delete - Donator");
        }

        public void update(Donator old, Donator entity)
        {
            log.InfoFormat("Entering save with entities {0},{1}", old,entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update donatori set nume=@nume, adresa=@adresa, nrTelefon=@nrTelefon where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramAdresa = comm.CreateParameter();
                paramAdresa.ParameterName = "@adresa";
                paramAdresa.Value = entity.Adresa;
                comm.Parameters.Add(paramAdresa);

                var paramNrTelefon = comm.CreateParameter();
                paramNrTelefon.ParameterName = "@nrTelefon";
                paramNrTelefon.Value = entity.NrTelefon;
                comm.Parameters.Add(paramNrTelefon);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No donator updated !");
            }
            log.Info("Exiting update - Donator");
        }

        
    }
}
