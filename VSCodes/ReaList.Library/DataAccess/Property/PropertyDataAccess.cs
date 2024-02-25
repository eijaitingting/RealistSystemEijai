using ReaList.Library.Model.Properties;
using ReaList.Library.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.DataAccess.Property
{
    public class PropertyDataAccess : IPropertyDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        public PropertyDataAccess(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #region Getter
        public async Task<IEnumerable<PropertyModel>> GetAllProperties()
           => await _dataAccess.LoadData<PropertyModel, dynamic>("sp_GetAllProperties", new { });
        public async Task<IEnumerable<PropertyModel>> GetAllPropertiesForSale()
            => await _dataAccess.LoadData<PropertyModel, dynamic>("sp_GetAllPropertiesForSale", new { });
        public async Task<IEnumerable<PropertyModel>> GetAllPropertiesForRent()
            => await _dataAccess.LoadData<PropertyModel, dynamic>("sp_GetAllPropertiesForRent", new { });

        public async Task<PropertyModel> GetSpecificProperty(int id)
            => await _dataAccess.LoadSingle<PropertyModel, dynamic>("sp_GetSpecificProperty", new { id });
        #endregion
        public async Task<bool> IsPropertyExist(string PropertyName)
        {
            var propertyName = await _dataAccess.LoadSingle<PropertyModel, dynamic>("sp_GetPropertyName", new { PropertyName });
            return propertyName != null;
        }

        public async Task AddProperty(PropertyModel model)
        {
            var parameters = new
            {
                model.PropertyID,
                model.AgentID,
                model.PropertyCategoryID,
                model.PropertyTypeID,
                model.PropertyName,
                model.Overview,
                model.TotalPrice,
                model.Bedrooms,
                model.Bathrooms,
                model.FloorAreaSize,
                model.DevelopmentInfo,

                model.Region,
                model.Municipality,
                model.City,
                model.Barangay,
                model.Street,
                model.ZipCode,

                AmenitiesName = model.AmenitiesName != null ? string.Join(",", model.AmenitiesName) : null,
                FeaturesName = model.FeaturesName != null ? string.Join(",", model.FeaturesName) : null,

                model.RoadRatings,
                model.SafetyRatings,
                model.CleanlinessRatings,
                model.ParkingRatings,
                model.TrafficRatings,
                model.SchoolRatings,
                model.RestaurantRatings,
                model.TotalRatings,

                model.MainPhoto,
                model.SecondPhoto,
                model.ThirdPhoto,
                model.FourthPhoto,
                model.FifthPhoto,
                model.SixthPhoto,
                model.SeventhPhoto,
                model.EightPhoto,
                model.NinthPhoto,
                model.TenthPhoto,

                model.PropertyStatus,
                model.DateCreated
            };
            await _dataAccess.ExecuteQuery("sp_AddProperty", parameters);
        }

        public async Task EditProperty(PropertyModel model)
        {
            var parameters = new
            {
                model.PropertyID,
                model.PropertyCategoryID,
                model.PropertyTypeID,
                model.PropertyName,
                model.Overview,
                model.TotalPrice,
                model.Bedrooms,
                model.Bathrooms,
                model.FloorAreaSize,
                model.DevelopmentInfo,

                model.Region,
                model.Municipality,
                model.City,
                model.Barangay,
                model.Street,
                model.ZipCode,

                AmenitiesName = model.AmenitiesName != null ? string.Join(",", model.AmenitiesName) : null,
                FeaturesName = model.FeaturesName != null ? string.Join(",", model.FeaturesName) : null,

                model.RoadRatings,
                model.SafetyRatings,
                model.CleanlinessRatings,
                model.ParkingRatings,
                model.TrafficRatings,
                model.SchoolRatings,
                model.RestaurantRatings,
                model.TotalRatings,

                model.MainPhoto,
                model.SecondPhoto,
                model.ThirdPhoto,
                model.FourthPhoto,
                model.FifthPhoto,
                model.SixthPhoto,
                model.SeventhPhoto,
                model.EightPhoto,
                model.NinthPhoto,
                model.TenthPhoto,

                model.DateUpdated
            };
            await _dataAccess.ExecuteQuery("sp_EditProperty", parameters);
        }

        public async Task MarkProperty(PropertyModel model)
        {
            var parameters = new
            {
                model.PropertyID,
                model.PropertyStatus
            };
            await _dataAccess.ExecuteQuery("sp_UpdatePropertyStatus", parameters);
        }
    }
}
