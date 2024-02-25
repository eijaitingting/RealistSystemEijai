using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Customers
{
    public class GetAllCustomersDataAccess : IGetAllCustomersDataAccess
    {
        private readonly ISqlDataAccess _dataAccess1;
        public GetAllCustomersDataAccess(ISqlDataAccess dataAccess1)
        {
            _dataAccess1 = dataAccess1;
        }
        public async Task<IEnumerable<AllCustomers>> GetAllCustomerAccount()
    => await _dataAccess1.LoadData<AllCustomers, dynamic>("sp_GetAllCustomerAccount", new { });
    }
}
