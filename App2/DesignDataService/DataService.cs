using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
	public interface IDataService
	{
		string TestData { get; }
	}

	/// <summary>
	/// <remarks>By default the Initialize method on our App class will look for types 
	/// that end in “Service” and register them, which is why our DesignData doesn’t end 
	/// in “Service”, but it also means we have to manually register it.</remarks>
	/// </summary>
	public class DesignData : IDataService
	{
		public string TestData
		{
			get
			{
				return "Designtime";
			}
		}
	}

	public class DataService : IDataService
	{
		public string TestData
		{
			get
			{
				return "Runtime";
			}
		}
	}
}