using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
	public class AllProperties
	{
	   public int PropertyID { get; set; } = 0;
	   public int AgentID { get; set; } = 0;

		public int PropertyCategoryID { get; set; } = 0;

		public int PropertyTypeID { get; set; } = 0;
		public string PropertyName { get; set; } = String.Empty;
		public string Overview { get; set; } = String.Empty;
		public decimal TotalPrice { get; set; } = 0;

		public int Bedrooms { get; set; } = 0;
		public int Bathrooms { get; set; } = 0; 
		public int FloorAreaSize { get; set; } = 0;
		public string DevelopmentInfo { get; set; } = String.Empty;


		public string Region { get; set; } = String.Empty;
		public string Municipality { get; set; } = String.Empty;
		public string City { get; set; } = String.Empty;
		public string Barangay { get; set; } = String.Empty;
		public string Street { get; set; } = String.Empty; 
		public string ZipCode { get; set; } = String.Empty;

		public bool PropertyStatus { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}
