using System;
using System.IO;
using System.Reflection;
using ShareIndex.ScanEngine.Configuration;

namespace ShareIndex.ScanEngine
{
	/// <summary>
	/// Summary description for EngineGlobals.
	/// </summary>
	public class ShareIndexEngine
	{
		// flag wich tells that the engine was started
		private static bool started = false;

		// the logging utility
		private static LogWriter logger = EventLogWriter.CreateLog( "ShareIndex");

		public static LogWriter Log
		{
			get{ return logger;}
		}

		// configuration options
		private static EngineOptions engineOptions;

		public EngineOptions Options
		{
			get{ return engineOptions;}
		}

		/// <summary>
		/// Starts up the scan engine. Default configuration path.
		/// </summary>
		public static void StartUp()
		{
			// read config
			Configuration.ConfigurationManager.Read();
			started = true;
		}

		public static void StartUp( String configurationPath)
		{
			
		}
	}
}
