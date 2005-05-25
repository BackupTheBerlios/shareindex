using System;
using System.ComponentModel;
using System.Windows.Forms;
using SourceGrid2;
using SourceGrid2.Cells.Real;
using SourceGrid2.DataModels;
using SourceGrid2.VisualModels;
using ColumnHeader = SourceGrid2.BehaviorModels.ColumnHeader;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Summary description for EvLogSettingsDlg.
	/// </summary>
	public class EvLogSettingsDlg : Form
	{
		private Label label1;
		private Grid grid = new Grid( );
		private LinkLabel linkLabel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public EvLogSettingsDlg( )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent( );

			ColumnHeader headerBehaviour = new ColumnHeader( false );
			FlatHeader headerVisual = new FlatHeader( true );
			EditorTextBoxButton textEditor = new EditorTextBoxButton( typeof ( String ) );
			EditorNumericUpDown numEditor = new EditorNumericUpDown( );

			grid.Redim( 3, 2 );

			grid[ 0, 0 ] = new SourceGrid2.Cells.Real.ColumnHeader( "Name", headerVisual, headerBehaviour );
			grid[ 0, 1 ] = new SourceGrid2.Cells.Real.ColumnHeader( "Value", headerVisual, headerBehaviour );

			grid[ 1, 0 ] = new Cell( "EventSource Name", textEditor, headerVisual );
			grid[ 1, 0 ].ToolTipText = "The path and file name to log to";
			grid[ 1, 0 ].Invalidate( );
			// TODO: place the old event source here
			grid[ 1, 1 ] = new Cell( "ShareIndex", textEditor );

			grid.AutoStretchColumnsToFitWidth = true;
			grid.StretchColumnsToFitWidth( );
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof ( EvLogSettingsDlg ) );
			this.label1 = new System.Windows.Forms.Label( );
			this.grid = new SourceGrid2.Grid( );
			this.linkLabel1 = new System.Windows.Forms.LinkLabel( );
			this.SuspendLayout( );
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point( 8, 8 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 216, 32 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Please specify settings for Windows EventLog logging or accept the defaults";
			// 
			// grid
			// 
			this.grid.AutoSizeMinHeight = 10;
			this.grid.AutoSizeMinWidth = 10;
			this.grid.AutoStretchColumnsToFitWidth = false;
			this.grid.AutoStretchRowsToFitHeight = false;
			this.grid.BackColor = System.Drawing.SystemColors.Window;
			this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
			this.grid.CustomSort = false;
			this.grid.GridToolTipActive = true;
			this.grid.Location = new System.Drawing.Point( 16, 40 );
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size( 232, 160 );
			this.grid.SpecialKeys = SourceGrid2.GridSpecialKeys.Default;
			this.grid.TabIndex = 3;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point( 216, 216 );
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size( 32, 16 );
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Done";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.onDoneClick );
			// 
			// EvLogSettingsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 268, 259 );
			this.ControlBox = false;
			this.Controls.Add( this.linkLabel1 );
			this.Controls.Add( this.grid );
			this.Controls.Add( this.label1 );
			this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.Name = "EvLogSettingsDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Event Log Settings";
			this.ResumeLayout( false );

		}

		#endregion

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close( );
		}

		/// <summary>
		/// The user wants to close the dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onDoneClick( object sender, LinkLabelLinkClickedEventArgs e )
		{
			this.Close( );
		}
	}
}