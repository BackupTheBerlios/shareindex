using System;

namespace ShareIndex.ScanEngine.Configuration
{
	/// <summary>
	/// Exception thrown when the configuration could
	/// not be read for some sort of reason
	/// </summary>
	public class ConfigurationReadException : Exception
	{
		private String message;

		/// <summary>
		/// Show detailed messages
		/// </summary>
		public override string Message
		{
			get
			{
				Exception inner = this.InnerException;
				while ( inner != null )
				{
					message += Environment.NewLine + "Caused by: " + inner.Message;
					inner = inner.InnerException;
				}
				return message;
			}
		}

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="message"></param>
		public ConfigurationReadException( String message ) : base( message )
		{
			this.message = message;
		}

		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public ConfigurationReadException( String message, Exception inner ) : base( message, inner )
		{
			this.message = message;
		}
	}
}