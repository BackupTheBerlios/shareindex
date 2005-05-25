using System;
using System.ComponentModel;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Summary description for ServiceStatusCheck.
	/// </summary>
	public class ServiceControllerFrm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Label lblAction;
		private PictureBox pictureBox1;

		/// <summary>
		/// The service status
		/// </summary>
		private ServiceControllerStatus status;

		public ServiceControllerFrm( )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent( );

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof ( ServiceControllerFrm ) );
			this.lblAction = new System.Windows.Forms.Label( );
			this.pictureBox1 = new System.Windows.Forms.PictureBox( );
			this.SuspendLayout( );
			// 
			// lblAction
			// 
			this.lblAction.Location = new System.Drawing.Point( 72, 32 );
			this.lblAction.Name = "lblAction";
			this.lblAction.Size = new System.Drawing.Size( 208, 32 );
			this.lblAction.TabIndex = 0;
			this.lblAction.Text = "Service Controller running. Please Wait...";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "pictureBox1.Image" ) ) );
			this.pictureBox1.Location = new System.Drawing.Point( 16, 16 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 48, 50 );
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// ServiceControllerFrm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 292, 82 );
			this.ControlBox = false;
			this.Controls.Add( this.pictureBox1 );
			this.Controls.Add( this.lblAction );
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ServiceControllerFrm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout( false );

		}

		#endregion

		/// <summary>
		/// Runs the service status check
		/// </summary>
		/// <returns>The service status</returns>
		public ServiceControllerStatus CheckServiceStatus( )
		{
			Thread checkThread = new Thread( new ThreadStart( CheckService ) );
			checkThread.Start( );
			// at this point the status is updated ( or should be)
			return this.status;
		}

		/// <summary>
		/// Checks the ShareIndex service status
		/// </summary>
		private void CheckService( )
		{
			try
			{
				this.Show( );

				this.lblAction.Text = "Checking service status. Please wait...";
				ServiceController controller = new ServiceController( );
				controller.MachineName = "localhost";
				controller.ServiceName = "ShareIndex";
				this.status = controller.Status;
				this.Close( );
			}
			catch ( Exception e )
			{
				ReportExceptionDlg.Report( e );
			}
		}
	}
}