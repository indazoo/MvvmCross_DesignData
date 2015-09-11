﻿using System;
using System.Diagnostics;
using Cirrious.CrossCore.Platform;

namespace App2
{
	/// <summary>
	/// DebugTrace class
	/// 
	/// </summary>
	public class DebugTrace : IMvxTrace
	{
		// http://stackoverflow.com/questions/22853894/is-there-any-error-logging-framework-in-mvvmcross
		// 
		// Is being registered during setup (setup.cs).


		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			Debug.WriteLine(tag + ":" + level + ":" + message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			Debug.WriteLine(tag + ":" + level + ":" + message);
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
				Debug.WriteLine(string.Format(tag + ":" + level + ":" + message, args));
			}
			catch (FormatException)
			{
				Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message);
			}
		}
	}
}
