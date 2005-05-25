using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShareIndex.ConfigurationGUI
{
	/// <summary>
	/// Summary description for ReportExceptionDlg.
	/// </summary>
	public class ReportExceptionDlg : Form
	{
		private TextBox textDetails;

		// we'd like only one error dlg at a time
		private static Exception exception = new Exception();
		private Panel panel1;
		private Label label4;
		private LinkLabel linkShowDetails;
		private LinkLabel linkTerminate;
		private LinkLabel linkContinue;
		private Label label3;
		private Label label2;
		private Label lblType;
		private Label label1;
		private PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textMessage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ReportExceptionDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReportExceptionDlg));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.linkShowDetails = new System.Windows.Forms.LinkLabel();
			this.linkTerminate = new System.Windows.Forms.LinkLabel();
			this.linkContinue = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textMessage = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.textMessage);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.linkShowDetails);
			this.panel1.Controls.Add(this.linkTerminate);
			this.panel1.Controls.Add(this.linkContinue);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.lblType);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 272);
			this.panel1.TabIndex = 11;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(96, 96);
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(216, 16);
			this.label4.TabIndex = 17;
			this.label4.Text = "With the following error message:";
			// 
			// linkShowDetails
			// 
			this.linkShowDetails.Location = new System.Drawing.Point(312, 248);
			this.linkShowDetails.Name = "linkShowDetails";
			this.linkShowDetails.Size = new System.Drawing.Size(120, 23);
			this.linkShowDetails.TabIndex = 16;
			this.linkShowDetails.TabStop = true;
			this.linkShowDetails.Text = "Show error details >>";
			this.linkShowDetails.Click += new System.EventHandler(this.OnShowDetails);
			// 
			// linkTerminate
			// 
			this.linkTerminate.Location = new System.Drawing.Point(168, 248);
			this.linkTerminate.Name = "linkTerminate";
			this.linkTerminate.Size = new System.Drawing.Size(152, 16);
			this.linkTerminate.TabIndex = 15;
			this.linkTerminate.TabStop = true;
			this.linkTerminate.Text = "Terminate the application";
			this.linkTerminate.Click += new System.EventHandler(this.OnTerminate);
			// 
			// linkContinue
			// 
			this.linkContinue.Location = new System.Drawing.Point(8, 248);
			this.linkContinue.Name = "linkContinue";
			this.linkContinue.Size = new System.Drawing.Size(168, 23);
			this.linkContinue.TabIndex = 14;
			this.linkContinue.TabStop = true;
			this.linkContinue.Text = "Continue using the application";
			this.linkContinue.Click += new System.EventHandler(this.OnContinue);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 13;
			this.label3.Text = "Would you like to:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(8, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(392, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "If you choose to continue, the application may not work correctly!";
			// 
			// lblType
			// 
			this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblType.ForeColor = System.Drawing.Color.Red;
			this.lblType.Location = new System.Drawing.Point(112, 56);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(320, 32);
			this.lblType.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(112, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "ShareIndex GUI encountered an error of type:";
			// 
			// textMessage
			// 
			this.textMessage.BackColor = System.Drawing.SystemColors.Control;
			this.textMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.textMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			this.textMessage.Location = new System.Drawing.Point(8, 136);
			this.textMessage.Multiline = true;
			this.textMessage.Name = "textMessage";
			this.textMessage.ReadOnly = true;
			this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textMessage.Size = new System.Drawing.Size(424, 56);
			this.textMessage.TabIndex = 18;
			this.textMessage.Text = "";
			// 
			// ReportExceptionDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 279);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ReportExceptionDlg";
			this.Text = "ShareIndex Configuration GUI - Error";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// Reports the exception
		/// </summary>
		/// <param name="e"></param>
		public static void Report(Exception e)
		{
			lock (exception)
			{
				exception = e;
				ReportExceptionDlg dlg = new ReportExceptionDlg();
				dlg.lblType.Text = e.GetType().ToString();
				dlg.textMessage.Text = e.Message;
				dlg.ShowDialog();
			}
		}

		/// <summary>
		/// Continue running the application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnContinue(object sender, EventArgs e)
		{
			// hide the dialog
			this.Close();
		}

		/// <summary>
		/// Exits the application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTerminate(object sender, EventArgs e)
		{
			// exit
			this.Close();
			Application.Exit();
		}

		/// <summary>
		/// Shows/hides detailed exception details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShowDetails(object sender, EventArgs e)
		{
			this.SuspendLayout();

			if (this.linkShowDetails.Text.StartsWith("Show"))
			{
				this.linkShowDetails.Text = "Hide error details <<";
				this.Size = new Size(this.Size.Width, this.Size.Height + 100);

				// create the textbox
				this.textDetails = new TextBox();
				this.textDetails.Location = new Point( 0, this.Size.Height - 130);
				this.textDetails.Size = new Size( this.Size.Width - 20, 100);
				this.textDetails.ReadOnly = true;
				this.textDetails.Multiline = true;
				this.textDetails.ScrollBars = ScrollBars.Both;
				this.textDetails.Visible = true;
	
				// fill it
				this.textDetails.Text = "Exception type: " + exception.GetType() + Environment.NewLine
								+ "Message: " + exception.Message + Environment.NewLine
								+ "In: " + exception.Source + Environment.NewLine
								+ "At: " + exception.TargetSite + Environment.NewLine 
								+ "Stack trace: " + exception.StackTrace;

				// add it
				this.Controls.Add( this.textDetails);
			}
			else if (this.linkShowDetails.Text.StartsWith("Hide"))
			{
				// resize back
				this.linkShowDetails.Text = "Show error details >>";
				this.Size = new Size(this.Size.Width, this.Size.Height - 100);

				// remove the control
				this.Controls.Remove( this.textDetails);
			}

			// request update
			this.ResumeLayout(false);
			this.Update();
		}
	}
}