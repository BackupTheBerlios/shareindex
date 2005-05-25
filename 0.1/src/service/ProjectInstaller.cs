using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace ShareIndex.Service
{
	
	/// <summary>
	/// ProjectInstaller for the ShareIndex service
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller shareindexServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller shareIndexServiceInstaller;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.shareindexServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.shareIndexServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// shareindexServiceProcessInstaller
			// 
			this.shareindexServiceProcessInstaller.Account = ServiceAccount.NetworkService;
			this.shareindexServiceProcessInstaller.Password = null;
			this.shareindexServiceProcessInstaller.Username = null;
			this.shareindexServiceProcessInstaller.AfterInstall += new InstallEventHandler( SetServiceDescription);
			// 
			// shareIndexServiceInstaller
			// 
			this.shareIndexServiceInstaller.ServiceName = "ShareIndex";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																					  this.shareindexServiceProcessInstaller,
																					  this.shareIndexServiceInstaller});

		}
		
		private void SetServiceDescription( object o, InstallEventArgs e)
		{
			System.Console.WriteLine("Setting service description");
			ServiceUtil.SetServiceDescription( "ShareIndex", "The ShareIndex Service");
		}
		#endregion
	}

	public class ServiceUtil
	{
		// ugly, I know, but we'd really want to describe the service...
		[DllImport("AdvApi32", SetLastError = true, EntryPoint = "ChangeServiceConfig2")]
		static extern bool Win32_ChangeServiceConfig2(System.IntPtr hService,int dwInfoLevel,System.IntPtr lpInfo);

		[DllImport("AdvApi32", SetLastError = true, EntryPoint = "OpenSCManager")]
		static extern IntPtr Win32_OpenSCManager( IntPtr machineName, IntPtr scDb, Int64 rights);

		[DllImport("AdvApi32", SetLastError = true, EntryPoint = "OpenService")]
		static extern IntPtr Win32_OpenService( IntPtr scManager, IntPtr srvName, Int64 access);

		[DllImport("AdvApi32", SetLastError = true, EntryPoint = "CloseServiceHandle")]
		static extern bool Win32_CloseService( IntPtr handle);

		private const System.Int32 SERVICE_CONFIG_DESCRIPTION = 1 ;
		private const System.Int32 SERVICE_CHANGE_CONFIG = 0x0002 ;

		private const System.Int32 STANDARD_RIGHTS_REQUIRED = 0x000F0000 ;

		private const System.Int32 SC_MANAGER_CONNECT = 0x0001 ;
		private const System.Int32 SC_MANAGER_CREATE_SERVICE = 0x0002 ;
		private const System.Int32 SC_MANAGER_ENUMERATE_SERVICE = 0x0004 ;
		private const System.Int32 SC_MANAGER_LOCK = 0x0008 ;
		private const System.Int32 SC_MANAGER_QUERY_LOCK_STATUS = 0x0010 ;
		private const System.Int32 SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020 ;

		struct SERVICE_DESCRIPTION
		{
			public System.IntPtr description;
		}

		public unsafe static void SetServiceDescription( String name, String description)
		{
			// prepare
			byte *_name = stackalloc byte[ name.Length];
			byte *_desc = stackalloc byte[ description.Length];
			char[] cname = name.ToCharArray();
			char[] cdesc = description.ToCharArray();
			// copy the name
			for( int i = 0; i < name.Length; i++) _name[i] = (byte)cname[i];
			_name[ name.Length] = 0;
			for( int i = 0; i < description.Length; i++) _desc[i] = (byte)cdesc[i];
			_desc[ description.Length] = 0;
			
			IntPtr srvName = new IntPtr( _name);
			SERVICE_DESCRIPTION info = new SERVICE_DESCRIPTION();
			info.description = new IntPtr( _desc);


			// open the SC manager db
			IntPtr scHandle = Win32_OpenSCManager( new IntPtr(null),  new IntPtr(null), 
								STANDARD_RIGHTS_REQUIRED |
								SC_MANAGER_CONNECT |
								SC_MANAGER_CREATE_SERVICE |
								SC_MANAGER_ENUMERATE_SERVICE |
								SC_MANAGER_LOCK |
								SC_MANAGER_QUERY_LOCK_STATUS |
								SC_MANAGER_MODIFY_BOOT_CONFIG );
			// open the service
			IntPtr srvHandle = Win32_OpenService( scHandle, srvName, SERVICE_CHANGE_CONFIG);
			// set service description
			Win32_ChangeServiceConfig2( srvHandle, SERVICE_CONFIG_DESCRIPTION, new IntPtr( &info));
			// close service
			Win32_CloseService( srvHandle);
			// close SC manager db
		}
	}
}
