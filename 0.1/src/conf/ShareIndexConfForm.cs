using System;
using System.ComponentModel;
using System.ServiceProcess;
using System.Windows.Forms;
using ShareIndex.ScanEngine;
using ShareIndex.ScanEngine.Configuration;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Load, edit and save configuration files
	/// </summary>
	public class ShareIndexConfForm : Form
	{
		private TabControl tabConfig;
		private TabPage tabPageLog;
		private TabPage tabPageNetwork;
		private TabPage tabPageStorage;
		private PictureBox bmpLog;
		private Label label1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private RadioButton logToEventLog;
		private RadioButton logToFile;
		private CheckedListBox chklbOptions;
		private MainMenu mainMenu1;
		private MenuItem menuExit;
		private MenuItem menuAbout;
		private TabPage tabPageService;
		private PictureBox pictureBox1;
		private Label label2;
		private GroupBox groupBox3;
		private Label label3;
		private LinkLabel btnRefresh;
		private LinkLabel btnSettings;
		private GroupBox groupBox4;
		private Label label4;
		private Label lblStatus;
		private Label lblChoice;
		private LinkLabel linkStart;
		private LinkLabel linkStop;
		private LinkLabel linkPause;
		private LinkLabel linkLabel1;
		private Label lblOr1;
		private LinkLabel linkLabel2;
		private Label lblIt1;
		private Label lblIt2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// This flag tells the service state
		/// </summary>
		private ServiceControllerStatus status = ServiceControllerStatus.Running;

		public ShareIndexConfForm( )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent( );
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				if ( components != null )
				{
					components.Dispose( );
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof ( ShareIndexConfForm ) );
			this.tabConfig = new System.Windows.Forms.TabControl( );
			this.tabPageService = new System.Windows.Forms.TabPage( );
			this.groupBox3 = new System.Windows.Forms.GroupBox( );
			this.label3 = new System.Windows.Forms.Label( );
			this.label2 = new System.Windows.Forms.Label( );
			this.pictureBox1 = new System.Windows.Forms.PictureBox( );
			this.groupBox4 = new System.Windows.Forms.GroupBox( );
			this.lblIt1 = new System.Windows.Forms.Label( );
			this.linkLabel2 = new System.Windows.Forms.LinkLabel( );
			this.lblOr1 = new System.Windows.Forms.Label( );
			this.lblIt2 = new System.Windows.Forms.Label( );
			this.linkLabel1 = new System.Windows.Forms.LinkLabel( );
			this.linkPause = new System.Windows.Forms.LinkLabel( );
			this.linkStop = new System.Windows.Forms.LinkLabel( );
			this.linkStart = new System.Windows.Forms.LinkLabel( );
			this.lblChoice = new System.Windows.Forms.Label( );
			this.lblStatus = new System.Windows.Forms.Label( );
			this.label4 = new System.Windows.Forms.Label( );
			this.btnRefresh = new System.Windows.Forms.LinkLabel( );
			this.tabPageNetwork = new System.Windows.Forms.TabPage( );
			this.tabPageStorage = new System.Windows.Forms.TabPage( );
			this.tabPageLog = new System.Windows.Forms.TabPage( );
			this.chklbOptions = new System.Windows.Forms.CheckedListBox( );
			this.groupBox1 = new System.Windows.Forms.GroupBox( );
			this.btnSettings = new System.Windows.Forms.LinkLabel( );
			this.logToEventLog = new System.Windows.Forms.RadioButton( );
			this.logToFile = new System.Windows.Forms.RadioButton( );
			this.label1 = new System.Windows.Forms.Label( );
			this.bmpLog = new System.Windows.Forms.PictureBox( );
			this.groupBox2 = new System.Windows.Forms.GroupBox( );
			this.mainMenu1 = new System.Windows.Forms.MainMenu( );
			this.menuExit = new System.Windows.Forms.MenuItem( );
			this.menuAbout = new System.Windows.Forms.MenuItem( );
			this.tabConfig.SuspendLayout( );
			this.tabPageService.SuspendLayout( );
			this.groupBox3.SuspendLayout( );
			this.groupBox4.SuspendLayout( );
			this.tabPageLog.SuspendLayout( );
			this.groupBox1.SuspendLayout( );
			this.SuspendLayout( );
			// 
			// tabConfig
			// 
			this.tabConfig.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabConfig.Controls.Add( this.tabPageService );
			this.tabConfig.Controls.Add( this.tabPageNetwork );
			this.tabConfig.Controls.Add( this.tabPageStorage );
			this.tabConfig.Controls.Add( this.tabPageLog );
			this.tabConfig.Location = new System.Drawing.Point( 8, 8 );
			this.tabConfig.Multiline = true;
			this.tabConfig.Name = "tabConfig";
			this.tabConfig.SelectedIndex = 0;
			this.tabConfig.Size = new System.Drawing.Size( 400, 384 );
			this.tabConfig.TabIndex = 0;
			// 
			// tabPageService
			// 
			this.tabPageService.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageService.Controls.Add( this.groupBox3 );
			this.tabPageService.Controls.Add( this.label2 );
			this.tabPageService.Controls.Add( this.pictureBox1 );
			this.tabPageService.Controls.Add( this.groupBox4 );
			this.tabPageService.Controls.Add( this.btnRefresh );
			this.tabPageService.Location = new System.Drawing.Point( 23, 4 );
			this.tabPageService.Name = "tabPageService";
			this.tabPageService.Size = new System.Drawing.Size( 373, 376 );
			this.tabPageService.TabIndex = 3;
			this.tabPageService.Text = "Service";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add( this.label3 );
			this.groupBox3.Location = new System.Drawing.Point( 8, 80 );
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size( 352, 96 );
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Statistics";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point( 8, 24 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 336, 64 );
			this.label3.TabIndex = 0;
			this.label3.Text = "Querying service state...";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point( 80, 16 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 280, 56 );
			this.label2.TabIndex = 2;
			this.label2.Text = "This page shows statistics of the indexing process and lets you manage the ShareI" +
				"ndex Windows service";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "pictureBox1.Image" ) ) );
			this.pictureBox1.Location = new System.Drawing.Point( 8, 16 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 48, 50 );
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add( this.lblIt1 );
			this.groupBox4.Controls.Add( this.linkLabel2 );
			this.groupBox4.Controls.Add( this.lblOr1 );
			this.groupBox4.Controls.Add( this.lblIt2 );
			this.groupBox4.Controls.Add( this.linkLabel1 );
			this.groupBox4.Controls.Add( this.linkPause );
			this.groupBox4.Controls.Add( this.linkStop );
			this.groupBox4.Controls.Add( this.linkStart );
			this.groupBox4.Controls.Add( this.lblChoice );
			this.groupBox4.Controls.Add( this.lblStatus );
			this.groupBox4.Controls.Add( this.label4 );
			this.groupBox4.Location = new System.Drawing.Point( 8, 192 );
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size( 352, 112 );
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Service Control";
			// 
			// lblIt1
			// 
			this.lblIt1.Location = new System.Drawing.Point( 176, 72 );
			this.lblIt1.Name = "lblIt1";
			this.lblIt1.Size = new System.Drawing.Size( 16, 16 );
			this.lblIt1.TabIndex = 10;
			this.lblIt1.Text = "it?";
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point( 208, 72 );
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size( 32, 16 );
			this.linkLabel2.TabIndex = 9;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "stop";
			// 
			// lblOr1
			// 
			this.lblOr1.Location = new System.Drawing.Point( 176, 72 );
			this.lblOr1.Name = "lblOr1";
			this.lblOr1.Size = new System.Drawing.Size( 16, 23 );
			this.lblOr1.TabIndex = 8;
			this.lblOr1.Text = "or";
			// 
			// lblIt2
			// 
			this.lblIt2.Location = new System.Drawing.Point( 248, 72 );
			this.lblIt2.Name = "lblIt2";
			this.lblIt2.Size = new System.Drawing.Size( 16, 16 );
			this.lblIt2.TabIndex = 7;
			this.lblIt2.Text = "it?";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point( 120, 72 );
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size( 48, 23 );
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "resume";
			// 
			// linkPause
			// 
			this.linkPause.Location = new System.Drawing.Point( 120, 72 );
			this.linkPause.Name = "linkPause";
			this.linkPause.Size = new System.Drawing.Size( 48, 23 );
			this.linkPause.TabIndex = 5;
			this.linkPause.TabStop = true;
			this.linkPause.Text = "pause";
			// 
			// linkStop
			// 
			this.linkStop.Location = new System.Drawing.Point( 120, 72 );
			this.linkStop.Name = "linkStop";
			this.linkStop.Size = new System.Drawing.Size( 48, 23 );
			this.linkStop.TabIndex = 4;
			this.linkStop.TabStop = true;
			this.linkStop.Text = "stop";
			// 
			// linkStart
			// 
			this.linkStart.Location = new System.Drawing.Point( 120, 72 );
			this.linkStart.Name = "linkStart";
			this.linkStart.Size = new System.Drawing.Size( 48, 23 );
			this.linkStart.TabIndex = 3;
			this.linkStart.TabStop = true;
			this.linkStart.Text = "start";
			// 
			// lblChoice
			// 
			this.lblChoice.Location = new System.Drawing.Point( 16, 72 );
			this.lblChoice.Name = "lblChoice";
			this.lblChoice.TabIndex = 2;
			this.lblChoice.Text = "Would you like to";
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( System.Byte ) ( 0 ) ) );
			this.lblStatus.Location = new System.Drawing.Point( 200, 48 );
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 56, 23 );
			this.lblStatus.TabIndex = 1;
			this.lblStatus.Text = "status";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point( 16, 48 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 184, 24 );
			this.label4.TabIndex = 0;
			this.label4.Text = "Currently the ShareIndex Service is ";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point( 216, 320 );
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size( 144, 16 );
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.TabStop = true;
			this.btnRefresh.Text = "Refresh service information";
			this.btnRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.onRefresh );
			// 
			// tabPageNetwork
			// 
			this.tabPageNetwork.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageNetwork.Location = new System.Drawing.Point( 23, 4 );
			this.tabPageNetwork.Name = "tabPageNetwork";
			this.tabPageNetwork.Size = new System.Drawing.Size( 373, 376 );
			this.tabPageNetwork.TabIndex = 1;
			this.tabPageNetwork.Text = "Network";
			// 
			// tabPageStorage
			// 
			this.tabPageStorage.Location = new System.Drawing.Point( 23, 4 );
			this.tabPageStorage.Name = "tabPageStorage";
			this.tabPageStorage.Size = new System.Drawing.Size( 373, 376 );
			this.tabPageStorage.TabIndex = 2;
			this.tabPageStorage.Text = "Storage";
			// 
			// tabPageLog
			// 
			this.tabPageLog.BackColor = System.Drawing.SystemColors.Control;
			this.tabPageLog.Controls.Add( this.chklbOptions );
			this.tabPageLog.Controls.Add( this.groupBox1 );
			this.tabPageLog.Controls.Add( this.label1 );
			this.tabPageLog.Controls.Add( this.bmpLog );
			this.tabPageLog.Controls.Add( this.groupBox2 );
			this.tabPageLog.Location = new System.Drawing.Point( 23, 4 );
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Size = new System.Drawing.Size( 373, 376 );
			this.tabPageLog.TabIndex = 0;
			this.tabPageLog.Text = "Log";
			// 
			// chklbOptions
			// 
			this.chklbOptions.CheckOnClick = true;
			this.chklbOptions.Items.AddRange( new object[]
				{
					"Log host found event",
					"Log path found event",
					"Log batch export event",
					"Log statistics "
				} );
			this.chklbOptions.Location = new System.Drawing.Point( 24, 200 );
			this.chklbOptions.Name = "chklbOptions";
			this.chklbOptions.Size = new System.Drawing.Size( 328, 124 );
			this.chklbOptions.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.btnSettings );
			this.groupBox1.Controls.Add( this.logToEventLog );
			this.groupBox1.Controls.Add( this.logToFile );
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point( 8, 72 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 360, 88 );
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Log destination";
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point( 304, 64 );
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size( 48, 16 );
			this.btnSettings.TabIndex = 5;
			this.btnSettings.TabStop = true;
			this.btnSettings.Text = "Settings";
			this.btnSettings.Click += new System.EventHandler( this.onSettingsClick );
			// 
			// logToEventLog
			// 
			this.logToEventLog.Location = new System.Drawing.Point( 16, 48 );
			this.logToEventLog.Name = "logToEventLog";
			this.logToEventLog.Size = new System.Drawing.Size( 192, 24 );
			this.logToEventLog.TabIndex = 4;
			this.logToEventLog.Text = "Log to Windows Event Log";
			// 
			// logToFile
			// 
			this.logToFile.Checked = true;
			this.logToFile.Location = new System.Drawing.Point( 16, 24 );
			this.logToFile.Name = "logToFile";
			this.logToFile.TabIndex = 3;
			this.logToFile.TabStop = true;
			this.logToFile.Text = "Log to file";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point( 88, 16 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 272, 40 );
			this.label1.TabIndex = 1;
			this.label1.Text = "While scanning and storing scan results, fairly large amount of log messages can " +
				"be generated. Here you can cutomize the log behaviour of the application";
			// 
			// bmpLog
			// 
			this.bmpLog.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "bmpLog.Image" ) ) );
			this.bmpLog.Location = new System.Drawing.Point( 8, 16 );
			this.bmpLog.Name = "bmpLog";
			this.bmpLog.Size = new System.Drawing.Size( 56, 50 );
			this.bmpLog.TabIndex = 0;
			this.bmpLog.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point( 8, 176 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 360, 168 );
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Verbosity";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange( new System.Windows.Forms.MenuItem[]
				{
					this.menuExit,
					this.menuAbout
				} );
			// 
			// menuExit
			// 
			this.menuExit.Index = 0;
			this.menuExit.Text = "Exit";
			this.menuExit.Click += new System.EventHandler( this.onExitClick );
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 1;
			this.menuAbout.Text = "About";
			this.menuAbout.Click += new System.EventHandler( this.onAboutClick );
			// 
			// ShareIndexConfForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 418, 395 );
			this.Controls.Add( this.tabConfig );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "ShareIndexConfForm";
			this.Text = "ShareIndex Configuration";
			this.Load += new System.EventHandler( this.onLoad );
			this.tabConfig.ResumeLayout( false );
			this.tabPageService.ResumeLayout( false );
			this.groupBox3.ResumeLayout( false );
			this.groupBox4.ResumeLayout( false );
			this.tabPageLog.ResumeLayout( false );
			this.groupBox1.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main( )
		{
			Application.Run( new ShareIndexConfForm( ) );
		}

		/// <summary>
		/// The "Settings" button has been hit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onSettingsClick( object sender, EventArgs e )
		{
			// open appropiate dialog
			if ( this.logToFile.Checked )
			{
				FileLogSettingsDlg fls = new FileLogSettingsDlg( );
				fls.ShowDialog( );
			}
			else
			{
				EvLogSettingsDlg els = new EvLogSettingsDlg( );
				els.ShowDialog( );
			}
		}

		/// <summary>
		/// Exit the application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onExitClick( object sender, EventArgs e )
		{
			Application.Exit( );
		}

		/// <summary>
		/// Show the about dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onAboutClick( object sender, EventArgs e )
		{
			AboutDlg adlg = new AboutDlg( );
			adlg.ShowDialog( );
			adlg.Dispose( );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onLoad( object sender, EventArgs e )
		{
			try
			{
				ServiceControllerFrm dlg = new ServiceControllerFrm( );
				dlg.CheckServiceStatus( );
			}
			catch ( Exception ex )
			{
				ReportExceptionDlg.Report( ex );
			}
			try
			{
				// read configuration
			}
			catch ( Exception ex )
			{
				ReportExceptionDlg.Report( ex );
			}
		}

		/// <summary>
		/// Update service information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onRefresh( object sender, LinkLabelLinkClickedEventArgs e )
		{
			ServiceControllerFrm dlg = new ServiceControllerFrm( );
			status = dlg.CheckServiceStatus( );
		}
	}
}