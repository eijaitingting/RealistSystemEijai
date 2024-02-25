using ReaList.Library.Model.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Property

{
    public interface IPropertyDataAccess
    {
        Task<IEnumerable<PropertyModel>> GetAllProperties();
        Task<IEnumerable<PropertyModel>> GetAllPropertiesForSale();
        Task<IEnumerable<PropertyModel>> GetAllPropertiesForRent();
        Task<PropertyModel> GetSpecificProperty(int id);
        Task AddProperty(PropertyModel model);
        Task EditProperty(PropertyModel model);
        Task MarkProperty(PropertyModel model);
        Task<bool> IsPropertyExist(string PropertyName);
    }
}
