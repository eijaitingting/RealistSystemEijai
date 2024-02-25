using ReaList.Library.Helper;
using ReaList.Library.DataAccess.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaList.Library.Model.Pages;

namespace ReaList.Library.DataAccess.Agents
{
    public class GetAllAgentDataAccess : IGetAllAgentDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public GetAllAgentDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<IEnumerable<AllAgents>> GetAllAgentAccount()
    => await _dataAccess.LoadData<AllAgents, dynamic>("sp_GetAllAgentAccount", new { });
    }
}
