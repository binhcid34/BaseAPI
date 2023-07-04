using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IConfiguration _configuration;
        private string _connectString = "";
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DataBase");
        }

        public IEnumerable<T> GetAll()
        {

            using (var conn = new MySqlConnection(_connectString))
            {
                try
                {
                    conn.Open();
                    var sqlQuery = $"Select * from {typeof(T).Name}";
                    var res = conn.Query<T>(sqlQuery).ToList();
                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally { conn.Close(); }
            }

        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T ExcuteProcedure(string procedure, DynamicParameters parameters)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                try
                {
                    conn.Open();
                    var res = conn.Query<T>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally { conn.Close(); }
            }
        }

        public T ExcuteCommandLine(string query)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                try
                {
                    conn.Open();
                    var res = conn.Query<T>(query).FirstOrDefault();
                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally { conn.Close(); }
            }
        }

        public IEnumerable<T> ExcuteProcedureToList(string procedure, DynamicParameters parameters)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                try
                {
                    conn.Open();
                    var res = conn.Query<T>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally { conn.Close(); }
            }
        }

        public T ExcuteProcedure<T>(string procedure, DynamicParameters parameters)
        {
            using (var conn = new MySqlConnection(_connectString))
            {
                try
                {
                    conn.Open();
                    var res = conn.Query<T>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally { conn.Close(); }
            }
        }
    }
}
