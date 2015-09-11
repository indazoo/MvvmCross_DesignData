
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Windows.UI.Xaml.Controls;

using Cirrious.MvvmCross.WindowsCommon.Platform;


namespace App2
{


	public class Setup : MvxWindowsSetup
	{
		// See https://github.com/MvvmCross/MvvmCross/issues/656 for MvxWindowsSetup

		public Setup(Frame rootFrame) : base(rootFrame)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App2.MyApp();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}

	}
}
