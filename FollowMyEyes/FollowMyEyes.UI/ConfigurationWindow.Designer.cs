using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.UI;
using FollowMyEyes.ModelTemplate;

namespace FollowMyEyes.UI
{
	partial class ConfigurationWindow : IConfigurationView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private ConfigurationPresenter presenter;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
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
			this.components = new System.ComponentModel.Container();
			this.FollowEyesButton = new System.Windows.Forms.Button();
			this.ProcessesComboBox = new System.Windows.Forms.ComboBox();
			this.ProcessLabel = new System.Windows.Forms.Label();
			this.GridView = new System.Windows.Forms.DataGridView();
			this.ImageBox = new Emgu.CV.UI.ImageBox();
			this.UpDown = new System.Windows.Forms.DomainUpDown();
			((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// FollowEyesButton
			// 
			this.FollowEyesButton.Location = new System.Drawing.Point(39, 352);
			this.FollowEyesButton.Name = "FollowEyesButton";
			this.FollowEyesButton.Size = new System.Drawing.Size(75, 23);
			this.FollowEyesButton.TabIndex = 0;
			this.FollowEyesButton.UseVisualStyleBackColor = true;
			// 
			// ProcessesComboBox
			// 
			this.ProcessesComboBox.FormattingEnabled = true;
			this.ProcessesComboBox.Location = new System.Drawing.Point(650, 21);
			this.ProcessesComboBox.Name = "ProcessesComboBox";
			this.ProcessesComboBox.Size = new System.Drawing.Size(245, 21);
			this.ProcessesComboBox.TabIndex = 2;
			// 
			// ProcessLabel
			// 
			this.ProcessLabel.AutoSize = true;
			this.ProcessLabel.Location = new System.Drawing.Point(36, 21);
			this.ProcessLabel.Name = "ProcessLabel";
			this.ProcessLabel.Size = new System.Drawing.Size(0, 13);
			this.ProcessLabel.TabIndex = 3;
			// 
			// GridView
			// 
			this.GridView.AllowUserToAddRows = false;
			this.GridView.AllowUserToDeleteRows = false;
			this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.GridView.Location = new System.Drawing.Point(39, 21);
			this.GridView.Name = "GridView";
			this.GridView.ReadOnly = true;
			this.GridView.Size = new System.Drawing.Size(566, 245);
			this.GridView.TabIndex = 4;
			// 
			// ImageBox
			// 
			this.ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ImageBox.Location = new System.Drawing.Point(650, 59);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(301, 207);
			this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImageBox.TabIndex = 5;
			this.ImageBox.TabStop = false;
			// 
			// UpDown
			// 
			this.UpDown.Items.Add("0.01");
			this.UpDown.Items.Add("0.05");
			this.UpDown.Items.Add("0.1");
			this.UpDown.Items.Add("0.2");
			this.UpDown.Items.Add("0.3");
			this.UpDown.Items.Add("0.5");
			this.UpDown.Items.Add("1.0");
			this.UpDown.Items.Add("2.0");
			this.UpDown.Items.Add("3.0");
			this.UpDown.Items.Add("5.0");
			this.UpDown.Location = new System.Drawing.Point(650, 305);
			this.UpDown.Name = "UpDown";
			this.UpDown.Size = new System.Drawing.Size(120, 20);
			this.UpDown.TabIndex = 6;
			this.UpDown.Text = "0.1";
			// 
			// ConfigurationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 610);
			this.Controls.Add(this.UpDown);
			this.Controls.Add(this.GridView);
			this.Controls.Add(this.ProcessLabel);
			this.Controls.Add(this.ProcessesComboBox);
			this.Controls.Add(this.FollowEyesButton);
			this.Controls.Add(this.ImageBox);
			this.Name = "ConfigurationWindow";
			((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button FollowEyesButton;
		private System.Windows.Forms.ComboBox ProcessesComboBox;
		private System.Windows.Forms.Label ProcessLabel;
		private System.Windows.Forms.DataGridView GridView;
		private Emgu.CV.UI.ImageBox ImageBox;
		private System.Windows.Forms.DomainUpDown UpDown;
		

		public ConfigurationPresenter Presenter
		{
			get { return presenter; }
			set { presenter = value; }
		}

		public int WindowWidth
		{
			set { this.Width = value; }
		}

		public int WindowHeight
		{
			set { this.Height = value; }
		}

		public string WindowName
		{
			set { this.Text = value; }
		}

		public string ActionButtonName
		{
			set { FollowEyesButton.Text = value; }
		}

		public IEnumerable<IProcessInfo> Processes
		{
			set
			{
				GridView.DataSource = value;
				ProcessesComboBox.DataSource = value;
			}
		}

		public IImage ImageSource
		{
			set { ImageBox.Image = value; }
		}
	}
}