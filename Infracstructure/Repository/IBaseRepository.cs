using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Repository
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);

        T ExcuteProcedure(string procedure, DynamicParameters parameters);
        T ExcuteProcedure<T>(string procedure, DynamicParameters parameters);

        T ExcuteCommandLine(string query);
        T ExcuteCommandLine(string query, DynamicParameters parameters);

        IEnumerable<T> ExcuteProcedureToList(string procedure, DynamicParameters parameters);

    }
}