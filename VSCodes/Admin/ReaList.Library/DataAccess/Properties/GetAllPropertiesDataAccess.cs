using ReaList.Library.Helper;
using ReaList.Library.Model.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Properties
{
    public class GetAllPropertiesDataAccess :IGetAllPropertiesDataAccess
    {
        private readonly ISqlDataAccess _dataAccess4;
        public GetAllPropertiesDataAccess(ISqlDataAccess dataAccess4)
        {
            _dataAccess4 = dataAccess4;
        }
        public async Task<IEnumerable<AllProperties>> GetAllReviewProperties()
    => await _dataAccess4.LoadData<AllProperties, dynamic>("sp_GetAllReviewProperties", new { });
    }
}
