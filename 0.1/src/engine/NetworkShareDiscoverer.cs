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
	using System.Runtime.InteropServices;

	/// <summary>
	/// This utility class discovers all network
	/// shares 
	/// </summary>
	public class NetworkShareDiscoverer
	{
		[DllImport( "mpr.dll", CharSet=CharSet.Auto )]
		public static extern int WNetEnumResource(
			IntPtr hEnum,
			ref int lpcCount,
			IntPtr lpBuffer,
			ref int lpBufferSize );

		[DllImport( "mpr.dll", CharSet=CharSet.Auto )]
		public static extern int WNetOpenEnum(
			RESOURCE_SCOPE dwScope,
			RESOURCE_TYPE dwType,
			RESOURCE_USAGE dwUsage,
			[MarshalAs( UnmanagedType.AsAny )]
			[In] Object lpNetResource,
			out IntPtr lphEnum );

		[DllImport( "mpr.dll", CharSet=CharSet.Auto )]
		public static extern int WNetCloseEnum( IntPtr hEnum );


		public enum RESOURCE_SCOPE
		{
			RESOURCE_CONNECTED = 0x00000001,
			RESOURCE_GLOBALNET = 0x00000002,
			RESOURCE_REMEMBERED = 0x00000003,
			RESOURCE_RECENT = 0x00000004,
			RESOURCE_CONTEXT = 0x00000005
		}

		public enum RESOURCE_TYPE
		{
			RESOURCETYPE_ANY = 0x00000000,
			RESOURCETYPE_DISK = 0x00000001,
			RESOURCETYPE_PRINT = 0x00000002,
			RESOURCETYPE_RESERVED = 0x00000008,
		}

		public enum RESOURCE_USAGE
		{
			RESOURCEUSAGE_CONNECTABLE = 0x00000001,
			RESOURCEUSAGE_CONTAINER = 0x00000002,
			RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
			RESOURCEUSAGE_SIBLING = 0x00000008,
			RESOURCEUSAGE_ATTACHED = 0x00000010,
			RESOURCEUSAGE_ALL = ( RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED ),
		}

		public enum RESOURCE_DISPLAYTYPE
		{
			RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,
			RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,
			RESOURCEDISPLAYTYPE_SERVER = 0x00000002,
			RESOURCEDISPLAYTYPE_SHARE = 0x00000003,
			RESOURCEDISPLAYTYPE_FILE = 0x00000004,
			RESOURCEDISPLAYTYPE_GROUP = 0x00000005,
			RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,
			RESOURCEDISPLAYTYPE_ROOT = 0x00000007,
			RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,
			RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,
			RESOURCEDISPLAYTYPE_TREE = 0x0000000A,
			RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B
		}

		public struct NETRESOURCE
		{
			public RESOURCE_SCOPE dwScope;
			public RESOURCE_TYPE dwType;
			public RESOURCE_DISPLAYTYPE dwDisplayType;
			public RESOURCE_USAGE dwUsage;
			[MarshalAs( UnmanagedType.LPTStr )] public string lpLocalName;
			[MarshalAs( UnmanagedType.LPTStr )] public string lpRemoteName;
			[MarshalAs( UnmanagedType.LPTStr )] public string lpComment;
			[MarshalAs( UnmanagedType.LPTStr )] public string lpProvider;
		}

		public enum NERR
		{
			NERR_Success = 0, /* Success */
			ERROR_MORE_DATA = 234, // dderror
			ERROR_NO_BROWSER_SERVERS_FOUND = 6118,
			ERROR_INVALID_LEVEL = 124,
			ERROR_ACCESS_DENIED = 5,
			ERROR_INVALID_PARAMETER = 87,
			ERROR_NOT_ENOUGH_MEMORY = 8,
			ERROR_NETWORK_BUSY = 54,
			ERROR_BAD_NETPATH = 53,
			ERROR_NO_NETWORK = 1222,
			ERROR_INVALID_HANDLE_STATE = 1609,
			ERROR_EXTENDED_ERROR = 1208
		}

		/// <summary>
		/// Returns all shares from the 
		/// Microsoft Windows Network
		/// </summary>
		/// <returns>An array list of strings containing share names</returns>
		public ArrayList GetShares( Object o )
		{
			IntPtr pHandle = new IntPtr();
			int entries = -1, buffer = 16536;
			IntPtr pBuffer = Marshal.AllocHGlobal( buffer );
			ArrayList ret = new ArrayList();

			WNetOpenEnum( RESOURCE_SCOPE.RESOURCE_GLOBALNET,
			              RESOURCE_TYPE.RESOURCETYPE_ANY,
			              RESOURCE_USAGE.RESOURCEUSAGE_ALL,
			              o,
			              out pHandle );

			WNetEnumResource( pHandle,
			                  ref entries,
			                  pBuffer,
			                  ref buffer );

			NETRESOURCE nr = new NETRESOURCE();
			for(Int32 ptr = pBuffer.ToInt32(); entries-- >= 1; ptr += Marshal.SizeOf( nr ))
			{
				nr = (NETRESOURCE) Marshal.PtrToStructure( new IntPtr( ptr ), typeof(NETRESOURCE) );
				if( ( nr.dwUsage & RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER )
					== RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER )
				{
					ArrayList res = GetShares( nr );
					if( res != null )
					{
						ret.AddRange( res );
					}
				}
				else
				{
					ret.Add( nr.lpRemoteName );
				}
			}
			Marshal.FreeHGlobal( pBuffer );
			return ret;
		}
	}
}