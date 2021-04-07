using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMobileShopCodeFirstFromDB
{
	// All string overrides are here. Note that max length of all nvarchar columns (strings)
	// are identified in const's here. These are then used in annotations for the particular entity class.

	partial class Inventory
	{
		/// <summary>
		/// Max length of student name. Is used to set column size in StudentRegistrationEntities.
		/// </summary>
		//public const int StudentNameMaxLength = 50;
		/// <summary>
		/// For debugging
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"{ProductId}: {Name} cat:{CategoryId} Qty {Quantity} Cost{Cost} Price {Price} \n{Description}";
		}
	}

	/// <summary>
	/// For debugging
	/// </summary>
	/// <returns></returns>
	partial class Category
	{
		/// <summary>
		/// Max length of course name. Is used to set column size in StudentRegistrationEntities.
		/// </summary>
		//public const int CourseNameMaxLength = 50;
		public override string ToString()
		{
			return $"{CategoryId} : {CategoryCode} {CategoryName}";
		}
	}

	/// <summary>
	/// For debugging
	/// </summary>
	/// <returns></returns>
	partial class TransactionProduct
	{
		/// <summary>
		/// Max length of department code. Is used to set column size in StudentRegistrationEntities.
		/// </summary>
		//public const int DepartmentCodeMaxLength = 10;
		/// <summary>
		/// Max length of department name. Is used to set column size in StudentRegistrationEntities.
		/// </summary>
		//public const int DepartmentNameMaxLength = 50;
		public override string ToString()
		{
			return $"Transaction {TransactionId} : Item {ProductId} Quantity {Quantity} Discount {Discount}";
		}
	}
}
