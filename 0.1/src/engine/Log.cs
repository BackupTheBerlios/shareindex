/*
//  ShareIndex version 0.1 
//  CopyrRight(C) 2005 of Radu Chindris
//
//  This file is part of ShareIndex.
//
//   ShareIndex is free software; you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation; either version 2 of the License, or
//   (at your option) any later version.
//
//   ShareIndex is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with ShareIndex; if not, write to the Free Software
//   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

namespace ShareIndex.ScanEngine
{
	using System;
	using System.Diagnostics;

	public enum LogLevel :int
	{
		INF,
		WAR,
		ERR
	}

	/// <summary>
	/// Log writer interface
	/// </summary>
	public interface LogWriter
	{
		void Write( LogLevel level, String message);
	}

	/// <summary>
	/// Implements the logging utility
	/// </summary>
	public sealed class EventLogWriter: LogWriter
	{
		private EventLog evLog = null;

		public static EventLogWriter CreateLog( String name)
		{
			return new EventLogWriter();
		}

		private EventLogWriter( )
		{
			evLog = new EventLog();
			evLog.BeginInit();
			evLog.Log = "Application";
			evLog.Source = "ShareIndexService";
			evLog.EndInit();
		}

		/// <summary>
		/// Logs a message using event log
		/// </summary>
		/// <param name="message">The message to log.</param>
		/// <param name="level">The Log level.</param>
		public void Write( LogLevel level, String message)
		{
			EventLogEntryType etype = EventLogEntryType.Information;
			switch(level)
			{
				case LogLevel.WAR:
					etype = EventLogEntryType.Warning;
					break;
				case LogLevel.ERR:
					etype = EventLogEntryType.Error;
					break;
			}
			evLog.WriteEntry( message, etype );
		}
	}
}