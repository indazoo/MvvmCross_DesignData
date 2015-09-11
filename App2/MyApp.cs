using System;
using System.Linq;

using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;

namespace App2
{
	/// <summary>
	/// Define the App type.
	/// </summary>
	public class MyApp : MvxApplication
	{

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public override void Initialize()
		{
			this.CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			//// Start the app with the Main View Model.
			this.RegisterAppStart<App2.ViewModels.MainViewModel>();


		}

		public Type FindViewModelTypeByName(string typeName)
		{
			return CreatableTypes().FirstOrDefault(t => t.Name == typeName);
		}

		#region Logging
		// http://stackoverflow.com/questions/22853894/is-there-any-error-logging-framework-in-mvvmcross

		public static void NetTrace(string message, params object[] args)
		{
			Mvx.TaggedTrace("App2Net", message, args);
		}

		public static void NetError(string message, params object[] args)
		{
			Mvx.TaggedError("App2NetErr", message, args);
		}

		public static void VmTrace(string message, params object[] args)
		{
			Mvx.TaggedTrace("App2Vm", message, args);
		}

		public static void VmError(string message, params object[] args)
		{
			Mvx.TaggedError("App2VmErr", message, args);
		}
		#endregion

	}
}