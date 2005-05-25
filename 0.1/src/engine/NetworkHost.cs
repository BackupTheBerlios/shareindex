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
	using System.Collections;
	using System.Net;

	/// <summary>
	/// This represents a NetworkHost identified by an IP address
	/// </summary>
	public class NetworkHost : IDisposable
	{
		public static readonly String LOCALHOST = "127.0.0.1";
		private const int DEFAULT_PING_TIMEOUT = 1000;

		private IPAddress ipAddress = null;
		private String dnsName = "";

		/// <summary>
		/// Checks to see if the host is alive
		/// </summary>
		/// <param name="ip">the IP of the host</param>
		/// <returns>true/false</returns>
		private static bool IsAlive( IPAddress ip )
		{
			bool alive = true;
			try
			{
				new Ping().PingHost( ip, DEFAULT_PING_TIMEOUT );
			}
			catch(Exception e)
			{
				ShareIndexEngine.Log.Write( LogLevel.WAR, e.Message + "\n" + e.StackTrace);
				alive = false;
			}
			return alive;
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public NetworkHost( )
		{
			// defaults to localhost
			ipAddress = IpAddrCache.GetIpAddr( LOCALHOST );
			dnsName = "localhost";
		}

		/// <summary>
		/// Constructor with an IP
		/// </summary>
		/// <param name="ip">the IP</param>
		public NetworkHost( String ip )
		{
			// get a reference for the ip from the cache
			ipAddress = IpAddrCache.GetIpAddr( ip );
			try
			{ 
				// get the DNS name associated with the IP
				IPHostEntry ipe = Dns.GetHostByAddress( ipAddress );
				dnsName = (String) ( ipe.HostName ).Clone();
			}
			catch(Exception e)
			{
				// this is not critical. just report it.
				ShareIndexEngine.Log.Write( LogLevel.WAR, e.Message + e.StackTrace );
			}
		}

		/// <summary>
		/// Constructor with a hostname
		/// </summary>
		/// <param name="hostName">the hostname</param>
		public NetworkHost( String hostName, /* only for constr. overloading */int dummy )
		{
			IPHostEntry ipHE = null;
			try
			{
				ipHE = Dns.GetHostByName( hostName );
			}
			catch(Exception)
			{
				throw new Exception( "No host with this name: " + hostName );
			}
			// get the first address
			if( ipHE.AddressList != null )
			{
				IPAddress addr = (IPAddress) ipHE.AddressList.GetValue( 0 );
				ipAddress = IpAddrCache.GetIpAddr( addr.ToString() );
			}
			// keep the host name
			dnsName = hostName;
		}

		///<summary>
		/// Copy constructor
		///</summary>
		public NetworkHost( NetworkHost other )
		{
			ipAddress = other.ipAddress;
			dnsName = other.dnsName;
		}		

		public void Dispose( )
		{
			ipAddress = null;
		}

		public bool Alive
		{
			get { return IsAlive( this.ipAddress ); }
		}

		public String IP
		{
			get { return ipAddress.ToString(); }
		}

		public String Name
		{
			get { return dnsName; }
		}

		/// <summary>
		/// This class implements a IP address
		/// caching mechanism
		/// </summary>
		private class IpAddrCache
		{
			private static Hashtable cache = new Hashtable();

			/// <summary>
			/// Checks if an IP is cached
			/// </summary>
			/// <param name="ip">The string representation of the IP</param>
			/// <returns>true/false, wheter it is cached or not</returns>
			public static bool IsCached( String ip )
			{
				return cache[ ip ] != null;
			}

			/// <summary>
			/// Returns an IPAddress from an string.
			/// If it is not cached, it is added to the cache
			/// before it is returned.
			/// </summary>
			/// <param name="ipAddr">The string representation of the IP addr</param>
			/// <returns></returns>
			public static IPAddress GetIpAddr( String ipAddr )
			{
				if( IsCached( ipAddr ) )
				{
					return CachedIp( ipAddr );
				}
				else
				{
					return AddToCache( ipAddr );
				}
			}

			/// <summary>
			/// Returns a cached IPAddress
			/// </summary>
			/// <param name="ip">The string representation of the IP</param>
			/// <returns></returns>
			public static IPAddress CachedIp( String ip )
			{
				return (IPAddress) cache[ ip ];
			}

			/// <summary>
			/// Adds an IPAddress to the cache
			/// </summary>
			public static IPAddress AddToCache( String ip )
			{
				IPAddress ipAddr = IPAddress.Parse( ip );
				cache.Add( ip.Clone(), ipAddr );
				return ipAddr;
			}

			/// <summary>
			/// Debugging purposes. Returns a status message.
			/// </summary>
			/// <returns></returns>
			public static String GetCacheInfo( )
			{
				return "Cache contains: " + cache.Count + " addresses";
			}
		}
	}
}