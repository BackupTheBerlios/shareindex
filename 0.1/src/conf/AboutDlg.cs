using System.ComponentModel;
using System.Windows.Forms;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Summary description for AboutDlg.
	/// </summary>
	public class AboutDlg : Form
	{
		private PictureBox pictureBox1;
		private Label label1;
		private Label label2;
		private Label label3;
		private LinkLabel linkLabel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public AboutDlg( )
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof ( AboutDlg ) );
			this.pictureBox1 = new System.Windows.Forms.PictureBox( );
			this.label1 = new System.Windows.Forms.Label( );
			this.label2 = new System.Windows.Forms.Label( );
			this.label3 = new System.Windows.Forms.Label( );
			this.linkLabel1 = new System.Windows.Forms.LinkLabel( );
			this.SuspendLayout( );
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "pictureBox1.Image" ) ) );
			this.pictureBox1.Location = new System.Drawing.Point( 8, 8 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 168, 152 );
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font( "Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( System.Byte ) ( 0 ) ) );
			this.label1.Location = new System.Drawing.Point( 184, 16 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 160, 16 );
			this.label1.TabIndex = 2;
			this.label1.Text = "ShareIndex version 0.1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8F );
			this.label2.Location = new System.Drawing.Point( 184, 40 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 184, 23 );
			this.label2.TabIndex = 3;
			this.label2.Text = "Copyright© 2005 of Radu Chindris";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point( 192, 64 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 280, 40 );
			this.label3.TabIndex = 4;
			this.label3.Text = "This work is published under the GPL license, you can use it and modify it accord" +
				"ing to the GPL license terms";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point( 416, 248 );
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size( 48, 16 );
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Close";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkLabel1_LinkClicked );
			// 
			// AboutDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 480, 273 );
			this.ControlBox = false;
			this.Controls.Add( this.linkLabel1 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.pictureBox1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout( false );

		}

		#endregion

		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			this.Close( );
		}
	}
}