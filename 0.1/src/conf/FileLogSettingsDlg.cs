using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using SourceGrid2;
using SourceGrid2.Cells.Real;
using SourceGrid2.DataModels;
using SourceGrid2.VisualModels;
using ColumnHeader = SourceGrid2.BehaviorModels.ColumnHeader;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Dialog for file logging settings
	/// </summary>
	public class FileLogSettingsDlg : Form
	{
		private Label label1;
		private Grid grid;
		private LinkLabel linkLabel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public FileLogSettingsDlg( )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent( );

			// initialize the grid
			ColumnHeader headerBehaviour = new ColumnHeader( false );
			FlatHeader headerVisual = new FlatHeader( true );
			EditorTextBoxButton textEditor = new EditorTextBoxButton( typeof ( String ) );
			EditorNumericUpDown numEditor = new EditorNumericUpDown( );

			grid.Redim( 3, 2 );

			grid[ 0, 0 ] = new SourceGrid2.Cells.Real.ColumnHeader( "Name", headerVisual, headerBehaviour );
			grid[ 0, 1 ] = new SourceGrid2.Cells.Real.ColumnHeader( "Value", headerVisual, headerBehaviour );

			grid[ 1, 0 ] = new Cell( "File", textEditor, headerVisual );
			grid[ 1, 0 ].ToolTipText = "The path and file name to log to";
			grid[ 1, 0 ].Invalidate( );
			// TODO: place the old file name here
			grid[ 1, 1 ] = new Link( @"c:\", new PositionEventHandler( this.OpenFile ) );

			grid[ 2, 0 ] = new Cell( "Size (Kb)", textEditor, headerVisual );
			grid[ 2, 0 ].ToolTipText = "The maximum size of the log file.";
			grid[ 2, 0 ].Invalidate( );

			grid[ 2, 1 ] = new Cell( 1024 * 100, numEditor );
			numEditor.Maximum = new decimal( 1024 * 1024 );
			numEditor.Minimum = new decimal( 0 );
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof ( FileLogSettingsDlg ) );
			this.label1 = new System.Windows.Forms.Label( );
			this.grid = new SourceGrid2.Grid( );
			this.linkLabel1 = new System.Windows.Forms.LinkLabel( );
			this.SuspendLayout( );
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point( 16, 8 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 224, 32 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Please specify settings for file logging or accept the defaults";
			// 
			// grid
			// 
			this.grid.AutoSizeMinHeight = 10;
			this.grid.AutoSizeMinWidth = 10;
			this.grid.AutoStretchColumnsToFitWidth = false;
			this.grid.AutoStretchRowsToFitHeight = false;
			this.grid.BackColor = System.Drawing.SystemColors.Window;
			this.grid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			// FileLogSettingsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size( 266, 256 );
			this.ControlBox = false;
			this.Controls.Add( this.linkLabel1 );
			this.Controls.Add( this.grid );
			this.Controls.Add( this.label1 );
			this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.Name = "FileLogSettingsDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Log to File Settings";
			this.ResumeLayout( false );

		}

		#endregion

		/// <summary>
		/// Called when the file link from the grid is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OpenFile( object sender, PositionEventArgs e )
		{
			OpenFileDialog fdlg = new OpenFileDialog( );
			bool chosen = false;

			fdlg.Title = "Choose log file...";
			fdlg.DefaultExt = "*.log";

			while ( ! chosen )
			{
				if ( fdlg.ShowDialog( ) == DialogResult.Cancel )
				{
					return;
				}
				// validate
				if ( File.Exists( fdlg.FileName ) )
				{
					// prompt for overwrite
					if ( MessageBox.Show(
						"The file you've choosen "
							+ Environment.NewLine + Environment.NewLine
							+ "  ( " + fdlg.FileName + ")"
							+ Environment.NewLine + Environment.NewLine
							+ "already exists and it will be appended."
							+ Environment.NewLine
							+ "Press OK to continue using this file or Cancel to choose another one.",
						"Confirm append",
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Exclamation )
						==
						DialogResult.OK )
					{
						chosen = true;
					}

				}
			}
			( ( Link ) sender ).Value = fdlg.FileName;
			grid.AutoSizeView( true );
		}

		/// <summary>
		/// User wants to close the dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void onDoneClick( object sender, LinkLabelLinkClickedEventArgs e )
		{
			this.Close( );
		}
	}
}