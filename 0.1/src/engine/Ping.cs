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
	using System.Net;
	using System.Net.Sockets;

	/// <summary>
	/// Utility class used for pinging a host.
	/// </summary>
	public class Ping
	{
		/// <summary>
		/// The ICMP packet
		/// </summary>
		private class IcmpPacket
		{
			private Byte Type; // type of message
			private Byte SubCode; // type of sub code
			private UInt16 CheckSum; // ones complement checksum of struct
			private UInt16 Identifier; // identifier
			private UInt16 SequenceNumber; // sequence number  
			private Byte[] Data;

			public static IcmpPacket CreatePacket( )
			{
				IcmpPacket packet = new IcmpPacket();
				packet.Type = ICMP_ECHO; //8
				packet.SubCode = 0;
				packet.CheckSum = 0xcd98; // no need to compute it
				packet.Identifier = UInt16.Parse( "45" );
				packet.SequenceNumber = UInt16.Parse( "0" );
				int PingData = 32;
				packet.Data = new Byte[PingData];
				//Initilize the Packet.Data
				for(int i = 0; i < PingData; i++)
				{
					packet.Data[ i ] = (byte) '#';
				}
				return packet;
			}

			/// <summary>
			/// Serialize to a byte array
			/// </summary>
			/// <returns></returns>
			public byte[] GetBytes( )
			{
				byte[] seq = new byte[Data.Length + 8];
				byte[] bType = new byte[1];
				bType[ 0 ] = this.Type;
				byte[] bCode = new byte[1];
				bCode[ 0 ] = this.SubCode;
				byte[] bChecksum = BitConverter.GetBytes( this.CheckSum );
				byte[] bId = BitConverter.GetBytes( this.Identifier );
				byte[] bSeq = BitConverter.GetBytes( this.SequenceNumber );

				int idx = 0;
				// create the buffer
				Array.Copy( bType, 0, seq, idx, bType.Length );
				idx += bType.Length;
				Array.Copy( bCode, 0, seq, idx, bCode.Length );
				idx += bCode.Length;
				Array.Copy( bChecksum, 0, seq, idx, bChecksum.Length );
				idx += bChecksum.Length;
				Array.Copy( bId, 0, seq, idx, bId.Length );
				idx += bId.Length;
				Array.Copy( bSeq, 0, seq, idx, bSeq.Length );
				idx += bSeq.Length;
				Array.Copy( this.Data, 0, seq, idx, this.Data.Length );
				return seq;
			}
		}

		private const int ICMP_ECHO = 8;
		private const int MAX_ACCEPTED = 1024;
		private const int SOCK_ERROR = -1;

		private Socket sock = null;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Ping( )
		{
			sock = new Socket( AddressFamily.InterNetwork, SocketType.Raw,
			                   ProtocolType.Icmp );

		}

		/// <summary>
		/// Ping the given host
		/// </summary>
		/// <param name="ip">The IP to ping</param>
		/// <param name="timeout">The timeout of the operation</param>
		/// <returns>True/false wether the host is alive or not</returns>
		public bool PingHost( IPAddress ip, int timeout )
		{
			EndPoint remote = new IPEndPoint( ip, 8 );
			SocketAddress sa = remote.Serialize();

			// send the echo request
			sock.SendTo( IcmpPacket.CreatePacket().GetBytes(), remote );
			sock.SetSocketOption( SocketOptionLevel.Socket,
			                      SocketOptionName.ReceiveTimeout, timeout );
			bool recv = false;
			byte[] bytes = new byte[MAX_ACCEPTED];
			while(!recv)
			{
				if( sock.ReceiveFrom( bytes, ref remote ) == SOCK_ERROR )
				{
					sock.Close();
					break; // not alive
				}
				else
				{
					recv = true;
				}
			}
			sock.Close();
			return recv;
		}
	}
}