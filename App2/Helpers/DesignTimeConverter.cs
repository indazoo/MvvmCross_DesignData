using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WINDOWS_PHONE || WPF
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
#endif
#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
#endif
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;


namespace App2
{
	public class DesignFactory
	{
		private App2.MyApp app;

		public DesignFactory()
		{
		}

		public IMvxViewModel Create(string typeName)
		{

			if (app==null)
			{
				//MvxSimpleIoCContainer is initialised in Core.Helpers.DesignTimeHelper() class.
				//MvxSimpleIoCContainer.Initialize();  //old style

				//Dies wird sonst via DoSetup() gemacht
				//durch aufruf von CreateApp()
				app = new App2.MyApp();
				app.Initialize();

				Mvx.RegisterType<IDataService,DesignData>();
			}

			var type = app.FindViewModelTypeByName(typeName);

			if (type == null) return null;

			var req = MvxViewModelRequest.GetDefaultRequest(type);
			if (req == null) return null;

			var locator = app.FindViewModelLocator(req);
			if (locator == null) return null;

			return locator.Load(type, null, null);
		}


	}

	public class DesignTimeConverter : IValueConverter
	{
		public DesignTimeConverter()
		{ }


		#if WINDOWS_PHONE || WPF
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Convert(value, targetType, parameter);
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
#endif
#if NETFX_CORE
		public object Convert(object value, Type targetType, object parameter, string culture)
		{
			return Convert(value, targetType, parameter);
		}
		public object ConvertBack(object value, Type targetType, object parameter, string culture)
		{
			return value;
		}
		#endif

		private object Convert(object value, Type targetType, object parameter)
		{
			var typeName = parameter as string;
			if (string.IsNullOrWhiteSpace(typeName)) return null;

			var factory = value as DesignFactory;
			System.Diagnostics.Debug.WriteLine(typeName.ToString());
			return factory.Create(typeName);
		}


	}
}
