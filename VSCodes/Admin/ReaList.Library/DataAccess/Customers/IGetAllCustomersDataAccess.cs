using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Customers
{
    public interface IGetAllCustomersDataAccess
    {
        Task<IEnumerable<AllCustomers>> GetAllCustomerAccount();
    }
}
