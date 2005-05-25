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
	using System.IO;
	using System.Threading;

	/// <summary>
	/// This is a network share.
	/// </summary>
	public class NetworkShare
	{
		private String unc = null;
		private NetworkHost host = null;
		private String remotePath = null;


		/// <summary>
		/// Default constructor
		/// </summary>
		public NetworkShare( )
		{
			unc = "";
			host = new NetworkHost();
			remotePath = "";
		}

		/// <summary>
		/// Constructor with UNC
		/// </summary>
		/// <param name="path">The share name - UNC</param>
		public NetworkShare( String path )
		{
			String hostName = "";
			// check if the UNC is valid
			unc = (String) path.Clone();
			if( path.StartsWith( @"\\" ) )
			{
				path = path.Remove( 0, 2 );
				int i = path.IndexOf( @"\" );
				if( i < 0 )
				{
					goto _abort;
				}
				hostName = path.Substring( 0, path.IndexOf( @"\" ) );
				path = path.Remove( 0, i );
				if( path == null || path.Length < 1 )
				{
					goto _abort;
				}
				// remove the first "\"
				remotePath = (String) path.Remove( 0, 1 );
				if( remotePath == null || remotePath.Length < 1 )
				{
					goto _abort;
				}
				goto _ok;
			}
			_abort:
			throw new Exception( "Invalid UNC path: " + unc );
			_ok:
			{
				host = new NetworkHost( hostName, 0 /* dummy */ );
			}
		}

		/// <summary>
		/// Explores the network share and finds all the
		/// files.
		/// </summary>
		public void Dig( )
		{
			if( host.Alive )
			{
				//Logger.Log( "Digging: " + host.Name + " (" + host.IP + "), UNC: " + unc);
				Thread t = new Thread( new ThreadStart( DigThread ) );
				t.Start();
			}
		}

		/// <summary>
		/// The thread proc
		/// </summary>
		private void DigThread( )
		{
			DigDir( unc );
		}

		/// <summary>
		/// Gets all the files from a share
		/// TODO: add max levels
		/// </summary>
		/// <param name="path"></param>
		private void DigDir( String path )
		{
			try
			{
				if( Directory.Exists( path ) )
				{
					string[] dirs = Directory.GetDirectories( path );
					for(int i = 0; i < dirs.Length; i++)
					{
						if( !path.Equals( dirs[ i ] ) )
						{
							DigDir( dirs[ i ] + @"\" );
						}
					}
					string[] files = Directory.GetFiles( path );
					for(int i = 0; i < files.Length; i++)
					{
						// trim control caracters
						files[ i ].Trim( new char[] {'\n', '\t'} );
						// record the file
						//Exporter.StorePath( host.Name, files[ i ], this.host.IP );
					}
				}
			}
			catch(Exception)
			{
				// This usually means that we don't have
				// permission to access the shared file.
				// Do nothing
			}
		}
	}
}