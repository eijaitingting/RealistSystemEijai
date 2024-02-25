using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Properties
{
    public class PropertyModel
    {
        public int PropertyID { get; set; } = 0;
        public int AgentID { get; set; }
        public int PropertyCategoryID { get; set; } = 1;
        public int PropertyTypeID { get; set; } = 1;

        [Required]
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Overview")]
        public string Overview { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Total Price (in PHP)")]
        public decimal? TotalPrice { get; set; }

        [Required]
        [Display(Name = "Bedrooms")]
        public int? Bedrooms { get; set; }

        [Required]
        [Display(Name = "Bathrooms")]
        public int? Bathrooms { get; set; }

        [Required]
        [Display(Name = "Region")]
        public string Region { get;set; } = string.Empty;

        [Required]
        [Display(Name = "Municipality")]
        public string Municipality { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Barangay")]
        public string Barangay { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Floor Area Size (in sqm)")]
        public int? FloorAreaSize { get; set; }

        [Required]
        [Display(Name = "Development/Developer Information")]
        public string DevelopmentInfo { get; set; } = string.Empty;
        public byte VSPhotos { get; set; }
        public int PropertyStatus { get; set; } = 1;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        /* AMENITIES */
        public int AmenitiesID { get; set; } = 0;
        public List<string>? AmenitiesName { get; set; }
        public string Amenities { get; set; } = string.Empty;

        /* FEATURES */
        public int FeaturesID { get; set; } = 0;
        public List<string>? FeaturesName { get; set; }
        public string Features { get; set; } = string.Empty;

        /* RATINGS */
        public int PropertyRatingsID { get; set; } = 0;
        public int RoadRatings { get; set; } = 0;
        public int SafetyRatings { get; set; } = 0;
        public int CleanlinessRatings { get; set; } = 0;
        public int ParkingRatings { get; set; } = 0;
        public int TrafficRatings { get; set; } = 0;
        public int SchoolRatings { get; set; } = 0;
        public int RestaurantRatings { get; set; } = 0;
        public decimal? TotalRatings { get; set; }

        /**/
        public string? MainPhoto { get; set; }
        public IFormFile? Main { get; set; }
        public string? SecondPhoto { get; set; }
        public IFormFile? Second { get; set; }
        public string? ThirdPhoto { get; set; }
        public IFormFile? Third { get; set; }
        public string? FourthPhoto { get; set; }
        public IFormFile? Fourth { get; set; }
        public string? FifthPhoto { get; set; }
        public IFormFile? Fifth { get; set; }
        public string? SixthPhoto { get; set; }
        public IFormFile? Sixth { get; set; }
        public string? SeventhPhoto { get; set; }
        public IFormFile? Seventh { get; set; }
        public string? EightPhoto { get; set; }
        public IFormFile? Eight { get; set; }
        public string? NinthPhoto { get; set; }
        public IFormFile? Ninth { get; set; }
        public string? TenthPhoto { get; set; }
        public IFormFile? Tenth { get; set; }

        /**/
        [Display(Name = "Agent Name")]
        public string AgentName { get; set; } = string.Empty;

        [Display(Name = "Agent Type")]
        public string AgentType { get; set; } = string.Empty;

        [Display(Name = "Property Category")]
        public string PropertyCategoryName { get; set; } = string.Empty;

        [Display(Name = "Property Type")]
        public string PropertyTypeName { get; set; } = string.Empty;

        [Display(Name = "Location")]
        public string Location { get; set; } = string.Empty;
    }
}
