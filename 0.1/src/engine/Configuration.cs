using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace ShareIndex.ScanEngine.Configuration
{
	/// <summary>
	/// Implemented by configuration value objects
	/// </summary>
	internal interface IConfValidator
	{
		bool Validate( );
	}

	/// <summary>
	/// Configuration utility class
	/// </summary>
	public class ConfigurationManager
	{
		private static readonly String DefaultConfigFilePath = "config.xml";

		/// <summary>
		/// Reads the configuration from the given file
		/// </summary>
		/// <param name="xmlPath"></param>
		public static EngineOptions ReadFromFile( String xmlPath )
		{
			EngineOptions engineOptions = new EngineOptions();
			// deserialize configuration options
			try
			{
				XmlSerializer serializer = new XmlSerializer( typeof ( EngineOptions ) );
				TextReader reader = new StreamReader( xmlPath );

				engineOptions = ( EngineOptions ) serializer.Deserialize( reader );

				reader.Close( );
			}
			catch ( Exception e )
			{
				throw new ConfigurationReadException( "Error while reading configuration.", e );
			}
			return engineOptions;
		}

		/// <summary>
		/// Reads configuration from the default config file
		/// </summary>
		public static void Read( )
		{
			// get the path for config. defaults to the 
			// directory from wich the assembly is loaded
			Uri uri = new Uri( Assembly.GetExecutingAssembly().CodeBase);

			// red the config
			ReadFromFile( Path.GetDirectoryName(uri.LocalPath) + DefaultConfigFilePath);
		}

		/// <summary>
		/// Stores the configuration to the given file
		/// </summary>
		/// <param name="xmlPath"></param>
		public static void WriteToFile( EngineOptions engineOptions, String xmlPath )
		{
			if ( engineOptions == null )
			{
				return;
			}
			try
			{
				XmlSerializer serializer = new XmlSerializer( typeof ( EngineOptions ) );
				TextWriter writer = new StreamWriter( xmlPath );

				serializer.Serialize( writer, engineOptions );

				writer.Close( );
			}
			catch ( Exception e )
			{
				throw new ConfigurationReadException( "Error while writig configuration.", e );
			}
		}

		/// <summary>
		/// Writes the configuration to the default config file
		/// </summary>
		public static void Write( EngineOptions engineOptions)
		{
			WriteToFile( engineOptions, DefaultConfigFilePath );
		}
	}

	/// <summary>
	/// Configuration value object
	/// </summary>
	[XmlRoot( "config" )]
	public class EngineOptions : IConfValidator
	{
		// log options
		[XmlElement( "log" )] internal LogOptions log;

		public bool Validate( )
		{
			return log.Validate( );
		}
	}

	public class LogOptions : IConfValidator
	{
		[XmlAttribute( "destination" )] public String destination;
		[XmlElement( "file" )] public FileLogOptions fileLog;
		[XmlElement( "eventlog" )] public EventLogOptions eventLog;

		public bool Validate( )
		{
			bool valid = false;

			if ( "file".Equals( destination ) )
			{
				valid = fileLog.Validate( );
			}
			else if ( "eventlog".Equals( destination ) )
			{
				valid = eventLog.Validate( );
			}
			else
			{
				valid = false;
			}
			return valid;
		}
	}

	/// <summary>
	/// File logging options
	/// </summary>
	public class FileLogOptions : IConfValidator
	{
		[XmlAttribute( "path" )] public String filePath;
		[XmlAttribute( "maxsize" )] public long maxSize;

		public bool Validate( )
		{
			return true;
		}
	}

	/// <summary>
	/// EventLog logging options
	/// </summary>
	public class EventLogOptions : IConfValidator
	{
		[XmlAttribute( "eventsource" )] public String name;

		public bool Validate( )
		{
			return true;
		}
	}
}