using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using ReaList.Library.DataAccess.Property;
using ReaList.Library.DataAccess.Subscription;
using ReaList.Library.Helper;
using ReaList.Library.Model;
using ReaList.Library.Model.Properties;
using ReaList.Library.Model.Subscription;
using ReaList.Library.Model.UserAccounts;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace ReaList.Web.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ISqlDataAccess _db;
        private readonly IPropertyDataAccess _dataAccess; 
        private readonly ISubscriptionDataAccess _dataAccessSubscription;
        public RealistsVM rvm = new RealistsVM();
        public PropertyController(ISqlDataAccess db, IPropertyDataAccess dataAccess, ISubscriptionDataAccess dataAccessSubscription)
        {
            _db = db;
            _dataAccess = dataAccess;
            _dataAccessSubscription = dataAccessSubscription;
        }

        public async Task<IActionResult> ListingsForSale()
        {
            var activeProperties = await _dataAccess.GetAllPropertiesForSale();

            var propertyList = new List<PropertyModel>();

            foreach (var property in activeProperties)
            {
                var PropertyID = property.PropertyID;
                var AgentName = property.AgentName;
                var AgentType = property.AgentType;
                var PropertyCategoryName = property.PropertyCategoryName;
                var PropertyTypeName = property.PropertyTypeName;
                var PropertyName = property.PropertyName;
                var TotalPrice = property.TotalPrice;
                var Location = property.Location;
                var MainPhoto = property.MainPhoto;

                var propertyViewModel = new PropertyModel
                {
                    PropertyID = PropertyID,
                    AgentName = AgentName,
                    AgentType = AgentType,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    PropertyName = PropertyName,
                    TotalPrice = TotalPrice,
                    Location = Location,
                    MainPhoto = MainPhoto,
                };

                propertyList.Add(propertyViewModel);
            }

            ModelState.Clear();
            return View(propertyList);
        }

        public async Task<IActionResult> ListingsForRent()
        {
            var activeProperties = await _dataAccess.GetAllPropertiesForRent();

            var propertyList = new List<PropertyModel>();

            foreach (var property in activeProperties)
            {
                var PropertyID = property.PropertyID;
                var AgentName = property.AgentName;
                var AgentType = property.AgentType;
                var PropertyCategoryName = property.PropertyCategoryName;
                var PropertyTypeName = property.PropertyTypeName;
                var PropertyName = property.PropertyName;
                var TotalPrice = property.TotalPrice;
                var Location = property.Location;
                var MainPhoto = property.MainPhoto;

                var propertyViewModel = new PropertyModel
                {
                    PropertyID = PropertyID,
                    AgentName = AgentName,
                    AgentType = AgentType,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    PropertyName = PropertyName,
                    TotalPrice = TotalPrice,
                    Location = Location,
                    MainPhoto = MainPhoto,
                };

                propertyList.Add(propertyViewModel);
            }

            ModelState.Clear();
            return View(propertyList);
        }

        public async Task<IActionResult> ActiveListings(string message)
        {
            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { agentID };
            var activeProperties = await _db.LoadData<PropertyModel, dynamic>("sp_GetAllActivePropertiesbyAgent", param);

            var propertyList = new List<PropertyModel>();

            foreach (var property in activeProperties)
            {
                var PropertyID = property.PropertyID;
                var AgentName = property.AgentName;
                var AgentType = property.AgentType;
                var PropertyCategoryName = property.PropertyCategoryName;
                var PropertyTypeName = property.PropertyTypeName;
                var PropertyName = property.PropertyName;
                var TotalPrice = property.TotalPrice;
                var Location = property.Location;
                var MainPhoto = property.MainPhoto;

                var propertyViewModel = new PropertyModel
                {
                    PropertyID = PropertyID,
                    AgentName = AgentName,
                    AgentType = AgentType,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    PropertyName = PropertyName,
                    TotalPrice = TotalPrice,
                    Location = Location,
                    MainPhoto = MainPhoto
                };

                propertyList.Add(propertyViewModel);
            }

            ModelState.Clear();
            return View(propertyList);
        }

        public async Task<IActionResult> PropertyDetails(PropertyModel model, string message, int id)
        {
            model.PropertyID = id;

            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var param = new { model.PropertyID };
            var propertyInfo = await _db.LoginUser<PropertyModel, dynamic>("sp_GetSpecificPropertyDetails", param);

            if (propertyInfo != null)
            {
                model.PropertyID = propertyInfo.PropertyID;
                model.AgentName = propertyInfo.AgentName;
                model.AgentType = propertyInfo.AgentType;
                model.PropertyCategoryName = propertyInfo.PropertyCategoryName;
                model.PropertyTypeName = propertyInfo.PropertyTypeName;
                model.PropertyName = propertyInfo.PropertyName;
                model.Overview = propertyInfo.Overview;
                model.TotalPrice = propertyInfo.TotalPrice;
                model.Bedrooms = propertyInfo.Bedrooms;
                model.Bathrooms = propertyInfo.Bathrooms;
                model.Location = propertyInfo.Location;
                model.FloorAreaSize = propertyInfo.FloorAreaSize;
                model.DevelopmentInfo = propertyInfo.DevelopmentInfo;

                model.Amenities = propertyInfo.Amenities;
                model.AmenitiesName = model.Amenities.Split(',').ToList();

                model.Features = propertyInfo.Features;
                model.FeaturesName = model.Features.Split(',').ToList();

                model.RoadRatings = propertyInfo.RoadRatings;
                model.SafetyRatings = propertyInfo.SafetyRatings;
                model.CleanlinessRatings = propertyInfo.CleanlinessRatings;
                model.ParkingRatings = propertyInfo.ParkingRatings;
                model.TrafficRatings = propertyInfo.TrafficRatings;
                model.SchoolRatings = propertyInfo.SchoolRatings;
                model.RestaurantRatings = propertyInfo.RestaurantRatings;
                model.TotalRatings = propertyInfo.TotalRatings;

                model.MainPhoto = propertyInfo.MainPhoto;
                model.SecondPhoto = propertyInfo.SecondPhoto;
                model.ThirdPhoto = propertyInfo.ThirdPhoto;
                model.FourthPhoto = propertyInfo.FourthPhoto;
                model.FifthPhoto = propertyInfo.FifthPhoto;
                model.SixthPhoto = propertyInfo.SixthPhoto;
                model.SeventhPhoto = propertyInfo.SeventhPhoto;
                model.EightPhoto = propertyInfo.EightPhoto;
                model.NinthPhoto = propertyInfo.NinthPhoto;
                model.TenthPhoto = propertyInfo.TenthPhoto;

                model.DateCreated = propertyInfo.DateCreated;
            }

            ModelState.Clear();
            return View(model);
        }

        public async Task<IActionResult> SoldListings()
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);
            var soldProperties = await _db.LoadData<PropertyModel, dynamic>("sp_GetAllSoldPropertiesbyAgent", param);

            var propertyList = new List<PropertyModel>();

            foreach (var property in soldProperties)
            {
                var PropertyID = property.PropertyID;
                var AgentName = property.AgentName;
                var AgentType = property.AgentType;
                var PropertyCategoryName = property.PropertyCategoryName;
                var PropertyTypeName = property.PropertyTypeName;
                var PropertyName = property.PropertyName;
                var TotalPrice = property.TotalPrice;
                var Location = property.Location;
                var MainPhoto = property.MainPhoto;

                var propertyViewModel = new PropertyModel
                {
                    PropertyID = PropertyID,
                    AgentName = AgentName,
                    AgentType = AgentType,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    PropertyName = PropertyName,
                    TotalPrice = TotalPrice,
                    Location = Location,
                    MainPhoto = MainPhoto,
                };

                propertyList.Add(propertyViewModel);
            }
            rvm.subscriptionList = (List<SubscriptionModel>)await _dataAccessSubscription.GetAllSubscription();
            rvm.agentAccountModel = agentInfo;
            rvm.propertyList= propertyList;
            ModelState.Clear();
            return View(rvm);
        }

        public async Task<IActionResult> RentedListings()
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);
            var rentedProperties = await _db.LoadData<PropertyModel, dynamic>("sp_GetAllRentedPropertiesbyAgent", param);

            var propertyList = new List<PropertyModel>();

            foreach (var property in rentedProperties)
            {
                var PropertyID = property.PropertyID;
                var AgentName = property.AgentName;
                var AgentType = property.AgentType;
                var PropertyCategoryName = property.PropertyCategoryName;
                var PropertyTypeName = property.PropertyTypeName;
                var PropertyName = property.PropertyName;
                var TotalPrice = property.TotalPrice;
                var Location = property.Location;
                var MainPhoto = property.MainPhoto;

                var propertyViewModel = new PropertyModel
                {
                    PropertyID = PropertyID,
                    AgentName = AgentName,
                    AgentType = AgentType,
                    PropertyCategoryName = PropertyCategoryName,
                    PropertyTypeName = PropertyTypeName,
                    PropertyName = PropertyName,
                    TotalPrice = TotalPrice,
                    Location = Location,
                    MainPhoto = MainPhoto
                };

                propertyList.Add(propertyViewModel);
            }
            rvm.subscriptionList = (List<SubscriptionModel>)await _dataAccessSubscription.GetAllSubscription();
            rvm.agentAccountModel = agentInfo;
            rvm.propertyList = propertyList;
            ModelState.Clear();
            return View(rvm);
        }

        public async Task<IActionResult> AddProperty(RealistsVM model, string message)
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var param = new { agentID };
            var agentInfo = await _db.LoginUser<AgentAccountModel, dynamic>("sp_GetSpecificAgentAccount", param);

            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            ModelState.Clear();
            model.subscriptionList = (List<SubscriptionModel>)await _dataAccessSubscription.GetAllSubscription();
            model.agentAccountModel = agentInfo;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProperty(PropertyModel propertyModel)
        {
            var agentID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            propertyModel.AgentID = agentID;

            if (await _dataAccess.IsPropertyExist(propertyModel.PropertyName))
            {
                var errorMessage = "Property already exists!";
                ModelState.AddModelError("Property", errorMessage);
                return RedirectToAction("AddProperty", new { message = errorMessage });
            }

            if (propertyModel.AmenitiesName != null)
            {
                var selectedAmenities = string.Join(",", propertyModel.AmenitiesName);
                propertyModel.AmenitiesName = selectedAmenities.Split(',').ToList();
            }

            if (propertyModel.FeaturesName != null)
            {
                var selectedFeatures = string.Join(",", propertyModel.FeaturesName);
                propertyModel.FeaturesName = selectedFeatures.Split(',').ToList();
            }

            var fileNames = new string[10];
            var filePaths = new string[10];

            var properties = new[]
            {
                (PropertyName: "Main", PhotoName: "MainPhoto"),
                (PropertyName: "Second", PhotoName: "SecondPhoto"),
                (PropertyName: "Third", PhotoName: "ThirdPhoto"),
                (PropertyName: "Fourth", PhotoName: "FourthPhoto"),
                (PropertyName: "Fifth", PhotoName: "FifthPhoto"),
                (PropertyName: "Sixth", PhotoName: "SixthPhoto"),
                (PropertyName: "Seventh", PhotoName: "SeventhPhoto"),
                (PropertyName: "Eight", PhotoName: "EightPhoto"),
                (PropertyName: "Ninth", PhotoName: "NinthPhoto"),
                (PropertyName: "Tenth", PhotoName: "TenthPhoto")
            };

            for (int i = 0; i < properties.Length; i++)
            {
                var fileProperty = typeof(PropertyModel).GetProperty(properties[i].PropertyName);
                var modelProperty = fileProperty?.GetValue(propertyModel) as IFormFile;

                if (modelProperty != null)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + modelProperty.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", fileName);

                    fileNames[i] = fileName;
                    filePaths[i] = filePath;

                    Debug.WriteLine(filePath);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await modelProperty.CopyToAsync(fileStream);
                    }

                    typeof(PropertyModel).GetProperty(properties[i].PhotoName)?.SetValue(propertyModel, fileName);
                }
            }

            propertyModel.MainPhoto = fileNames[0];
            propertyModel.SecondPhoto = fileNames[1];
            propertyModel.ThirdPhoto = fileNames[2];
            propertyModel.FourthPhoto = fileNames[3];
            propertyModel.FifthPhoto = fileNames[4];
            propertyModel.SixthPhoto = fileNames[5];
            propertyModel.SeventhPhoto = fileNames[6];
            propertyModel.EightPhoto = fileNames[7];
            propertyModel.NinthPhoto = fileNames[8];
            propertyModel.TenthPhoto = fileNames[9];

            int roads = propertyModel.RoadRatings;
            int safety = propertyModel.SafetyRatings;
            int cleanliness = propertyModel.CleanlinessRatings;
            int parking = propertyModel.ParkingRatings;
            int traffic = propertyModel.TrafficRatings;
            int schools = propertyModel.SchoolRatings;
            int restaurants = propertyModel.RestaurantRatings;

            int sum = roads + safety + cleanliness + parking + traffic + schools + restaurants;
            int ave = sum / 7;

            propertyModel.TotalRatings = ave;

            await _dataAccess.AddProperty(propertyModel);
            TempData["SuccessMessage"] = "Property added successfully!";
            return RedirectToAction("ActiveListings");
        }

        public async Task <IActionResult> EditProperty(PropertyModel model, string message, int id)
        {
            model.PropertyID = id;

            if (TempData.ContainsKey("SuccessMessage"))
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();

            if (!string.IsNullOrEmpty(message))
                ViewBag.ErrorMessage = message;

            var param = new { model.PropertyID };
            var propertyInfo = await _db.LoginUser<PropertyModel, dynamic>("sp_GetSpecificProperty", param);

            if (propertyInfo != null)
            {
                model.PropertyID  = propertyInfo.PropertyID;
                model.PropertyCategoryID = propertyInfo.PropertyCategoryID;
                model.PropertyTypeID = propertyInfo.PropertyTypeID;
                model.PropertyName = propertyInfo.PropertyName;
                model.Overview = propertyInfo.Overview;
                model.TotalPrice = propertyInfo.TotalPrice;
                model.Bedrooms = propertyInfo.Bedrooms;
                model.Bathrooms = propertyInfo.Bathrooms;
                model.Region = propertyInfo.Region;
                model.Municipality = propertyInfo.Municipality;
                model.City = propertyInfo.City;
                model.Barangay = propertyInfo.Barangay;
                model.Street = propertyInfo.Street;
                model.ZipCode = propertyInfo.ZipCode;
                model.FloorAreaSize = propertyInfo.FloorAreaSize;
                model.DevelopmentInfo = propertyInfo.DevelopmentInfo;

                model.Amenities = propertyInfo.Amenities;
                model.AmenitiesName = model.Amenities.Split(',').ToList();

                model.Features = propertyInfo.Features;
                model.FeaturesName = model.Features.Split(',').ToList();

                model.RoadRatings = propertyInfo.RoadRatings;
                model.SafetyRatings = propertyInfo.SafetyRatings;
                model.CleanlinessRatings = propertyInfo.CleanlinessRatings;
                model.ParkingRatings = propertyInfo.ParkingRatings;
                model.TrafficRatings = propertyInfo.TrafficRatings;
                model.SchoolRatings = propertyInfo.SchoolRatings;
                model.RestaurantRatings = propertyInfo.RestaurantRatings;

                model.MainPhoto = propertyInfo.MainPhoto;
                model.SecondPhoto = propertyInfo.SecondPhoto;
                model.ThirdPhoto = propertyInfo.ThirdPhoto;
                model.FourthPhoto = propertyInfo.FourthPhoto;
                model.FifthPhoto = propertyInfo.FifthPhoto;
                model.SixthPhoto = propertyInfo.SixthPhoto;
                model.SeventhPhoto = propertyInfo.SeventhPhoto;
                model.EightPhoto = propertyInfo.EightPhoto;
                model.NinthPhoto = propertyInfo.NinthPhoto;
                model.TenthPhoto = propertyInfo.TenthPhoto;
            }

            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProperty(PropertyModel model)
        {
            /*if (await _dataAccessProperty.IsPropertyExist(model.PropertyName))
            {
                var errorMessage = "Property already exists!";
                ModelState.AddModelError("Property", errorMessage);
                return RedirectToAction("AddProperty", new { message = errorMessage });
            }*/

            var fileNames = new string[10];
            var filePaths = new string[10];

            var properties = new[]
            {
                (PropertyName: "Main", PhotoName: "MainPhoto"),
                (PropertyName: "Second", PhotoName: "SecondPhoto"),
                (PropertyName: "Third", PhotoName: "ThirdPhoto"),
                (PropertyName: "Fourth", PhotoName: "FourthPhoto"),
                (PropertyName: "Fifth", PhotoName: "FifthPhoto"),
                (PropertyName: "Sixth", PhotoName: "SixthPhoto"),
                (PropertyName: "Seventh", PhotoName: "SeventhPhoto"),
                (PropertyName: "Eight", PhotoName: "EightPhoto"),
                (PropertyName: "Ninth", PhotoName: "NinthPhoto"),
                (PropertyName: "Tenth", PhotoName: "TenthPhoto")
            };

            for (int i = 0; i < properties.Length; i++)
            {
                var fileProperty = typeof(PropertyModel).GetProperty(properties[i].PropertyName);
                var modelProperty = fileProperty?.GetValue(model) as IFormFile;

                if (modelProperty != null)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + modelProperty.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", fileName);

                    fileNames[i] = fileName;
                    filePaths[i] = filePath;

                    Debug.WriteLine(filePath);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await modelProperty.CopyToAsync(fileStream);
                    }

                    typeof(PropertyModel).GetProperty(properties[i].PhotoName)?.SetValue(model, fileName);
                }
            }

            model.MainPhoto = model.MainPhoto ?? fileNames[0];
            model.SecondPhoto = model.SecondPhoto ?? fileNames[1];
            model.ThirdPhoto = model.ThirdPhoto ?? fileNames[2];
            model.FourthPhoto = model.FourthPhoto ?? fileNames[3];
            model.FifthPhoto = model.FifthPhoto ?? fileNames[4];
            model.SixthPhoto = model.SixthPhoto ?? fileNames[5];
            model.SeventhPhoto = model.SeventhPhoto ?? fileNames[6];
            model.EightPhoto = model.EightPhoto ?? fileNames[7];
            model.NinthPhoto = model.NinthPhoto ?? fileNames[8];
            model.TenthPhoto = model.TenthPhoto ?? fileNames[9];

            int roads = model.RoadRatings;
            int safety = model.SafetyRatings;
            int cleanliness = model.CleanlinessRatings;
            int parking = model.ParkingRatings;
            int traffic = model.TrafficRatings;
            int schools = model.SchoolRatings;
            int restaurants = model.RestaurantRatings;

            int sum = roads + safety + cleanliness + parking + traffic + schools + restaurants;
            int ave = sum / 7;

            model.TotalRatings = ave;

            await _dataAccess.EditProperty(model);
            TempData["SuccessMessage"] = "Property updated successfully!";
            return RedirectToAction("EditProperty", new { id = model.PropertyID });
        }

        public async Task<IActionResult> MarkProperty(PropertyModel model, int id)
        {
            model.PropertyID = id;

            var param = new { model.PropertyID };
            var propertyInfo = await _db.LoginUser<PropertyModel, dynamic>("sp_GetSpecificProperty", param);

            if (propertyInfo.PropertyCategoryID == 1)
                model.PropertyStatus = 3;

            if (propertyInfo.PropertyCategoryID == 2)
                model.PropertyStatus = 2;

            if (propertyInfo.PropertyStatus == 2 || propertyInfo.PropertyStatus == 3)
                model.PropertyStatus = 1;

            await _dataAccess.MarkProperty(model);
            TempData["SuccessMessage"] = "Property marked successfully!";
            return RedirectToAction("ActiveListings");
        }
    }
}
