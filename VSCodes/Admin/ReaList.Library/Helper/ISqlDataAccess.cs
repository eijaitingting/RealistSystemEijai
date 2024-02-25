using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Helper
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(String storedProcedure, U parameters, String connectionId = "Default");
        Task<T> LoadSingle<T, U>(String storedProcedure, U parameters, String connectionId = "Default");
        Task ExecuteQuery<T>(String storedProcedure, T parameters, String connectionId = "Default");
        Task<int> ExecuteReturnID<T>(String storedProcedure, T parameters, String connectionId = "Default");
        Task<T> LoginUser<T, U>(String storedProcedure, U parameter, String connectionId = "Default");
    }
}
