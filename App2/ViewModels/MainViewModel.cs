using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App2.ViewModels
{

	/// <summary>
	/// Define the MainViewModel type.
	/// </summary>
	public class MainViewModel : MvxViewModel
	{
		private IDataService Data { get; set; }

		public MainViewModel(IDataService data) 
		{
			Data = data; 
		}

		public string DesignTimeHello
		{
			get { return Data != null ? Data.TestData : "Missing"; }
		}



		/// <summary>
		/// Show the view model.
		/// </summary>
		public void Show()
		{
			this.ShowViewModel<MainViewModel>();
		}



		public void Init()
		{
			int i = 0;
			i++;

		}
		

		/// <summary>
		/// Checks if a property already matches a desired value.  Sets the property and
		/// notifies listeners only when necessary.
		/// </summary>
		/// <typeparam name="T">Type of the property.</typeparam>
		/// <param name="backingStore">Reference to a property with both getter and setter.</param>
		/// <param name="value">Desired value for the property.</param>
		/// <param name="property">The property.</param>
		protected void SetProperty<T>(
			ref T backingStore,
			T value,
			Expression<Func<T>> property)
		{
			if (Equals(backingStore, value))
			{
				return;
			}

			backingStore = value;

			this.RaisePropertyChanged(property);
		}
		

		/// <summary>
		/// Backing field for my property.
		/// </summary>
		private string myProperty = "MyProperty value from MainViewModel";
		/// <summary>
		/// Gets or sets my property.
		/// </summary>
		public string MyProperty
		{
			get { return this.myProperty; }
			set { this.SetProperty(ref this.myProperty, value, () => this.MyProperty); }
		}

	}
}
