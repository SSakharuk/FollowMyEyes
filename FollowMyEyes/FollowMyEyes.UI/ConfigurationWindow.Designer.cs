using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this._followEyesButton = new System.Windows.Forms.Button();
			this._processesComboBox = new System.Windows.Forms.ComboBox();
			this._processLabel = new System.Windows.Forms.Label();
			this._gridView = new System.Windows.Forms.DataGridView();
			this._imageBox = new Emgu.CV.UI.ImageBox();
			this._upDownControl = new System.Windows.Forms.DomainUpDown();
			this._saveImage = new System.Windows.Forms.Button();
			this._name = new System.Windows.Forms.TextBox();
			this._status = new System.Windows.Forms.Label();
			this._checkEyes = new System.Windows.Forms.CheckBox();
			this._checkFaceRecognition = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this._gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._imageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// _followEyesButton
			// 
			this._followEyesButton.Location = new System.Drawing.Point(39, 352);
			this._followEyesButton.Name = "_followEyesButton";
			this._followEyesButton.Size = new System.Drawing.Size(75, 23);
			this._followEyesButton.TabIndex = 0;
			this._followEyesButton.UseVisualStyleBackColor = true;
			this._followEyesButton.Click += new System.EventHandler(this._followEyesButton_Click);
			// 
			// _processesComboBox
			// 
			this._processesComboBox.DisplayMember = "ProcessName";
			this._processesComboBox.FormattingEnabled = true;
			this._processesComboBox.Location = new System.Drawing.Point(650, 21);
			this._processesComboBox.Name = "_processesComboBox";
			this._processesComboBox.Size = new System.Drawing.Size(245, 21);
			this._processesComboBox.TabIndex = 2;
			this._processesComboBox.ValueMember = "ProcessId";
			// 
			// _processLabel
			// 
			this._processLabel.AutoSize = true;
			this._processLabel.Location = new System.Drawing.Point(36, 21);
			this._processLabel.Name = "_processLabel";
			this._processLabel.Size = new System.Drawing.Size(0, 13);
			this._processLabel.TabIndex = 3;
			// 
			// _gridView
			// 
			this._gridView.AllowUserToAddRows = false;
			this._gridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this._gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this._gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this._gridView.DefaultCellStyle = dataGridViewCellStyle2;
			this._gridView.Location = new System.Drawing.Point(39, 21);
			this._gridView.Name = "_gridView";
			this._gridView.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this._gridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this._gridView.Size = new System.Drawing.Size(566, 245);
			this._gridView.TabIndex = 4;
			// 
			// _imageBox
			// 
			this._imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._imageBox.Location = new System.Drawing.Point(650, 59);
			this._imageBox.Name = "_imageBox";
			this._imageBox.Size = new System.Drawing.Size(301, 207);
			this._imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this._imageBox.TabIndex = 5;
			this._imageBox.TabStop = false;
			// 
			// _upDownControl
			// 
			this._upDownControl.Items.Add("0.01");
			this._upDownControl.Items.Add("0.05");
			this._upDownControl.Items.Add("0.1");
			this._upDownControl.Items.Add("0.2");
			this._upDownControl.Items.Add("0.3");
			this._upDownControl.Items.Add("0.5");
			this._upDownControl.Items.Add("1.0");
			this._upDownControl.Items.Add("2.0");
			this._upDownControl.Items.Add("3.0");
			this._upDownControl.Items.Add("5.0");
			this._upDownControl.Location = new System.Drawing.Point(39, 287);
			this._upDownControl.Name = "_upDownControl";
			this._upDownControl.Size = new System.Drawing.Size(120, 20);
			this._upDownControl.TabIndex = 6;
			this._upDownControl.Text = "0.1";
			// 
			// _saveImage
			// 
			this._saveImage.Location = new System.Drawing.Point(471, 349);
			this._saveImage.Name = "_saveImage";
			this._saveImage.Size = new System.Drawing.Size(75, 23);
			this._saveImage.TabIndex = 7;
			this._saveImage.Text = "Save";
			this._saveImage.UseVisualStyleBackColor = true;
			this._saveImage.Click += new System.EventHandler(this._saveImage_Click);
			// 
			// _name
			// 
			this._name.Location = new System.Drawing.Point(332, 349);
			this._name.Name = "_name";
			this._name.Size = new System.Drawing.Size(100, 20);
			this._name.TabIndex = 8;
			// 
			// _status
			// 
			this._status.AutoSize = true;
			this._status.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._status.Location = new System.Drawing.Point(335, 419);
			this._status.Name = "_status";
			this._status.Size = new System.Drawing.Size(0, 35);
			this._status.TabIndex = 9;
			// 
			// _checkEyes
			// 
			this._checkEyes.AutoSize = true;
			this._checkEyes.Location = new System.Drawing.Point(341, 287);
			this._checkEyes.Name = "_checkEyes";
			this._checkEyes.Size = new System.Drawing.Size(83, 17);
			this._checkEyes.TabIndex = 10;
			this._checkEyes.Text = "Check Eyes";
			this._checkEyes.UseVisualStyleBackColor = true;
			this._checkEyes.CheckedChanged += new System.EventHandler(this._checkEyes_CheckedChanged);
			// 
			// _checkFaceRecognition
			// 
			this._checkFaceRecognition.AutoSize = true;
			this._checkFaceRecognition.Location = new System.Drawing.Point(341, 311);
			this._checkFaceRecognition.Name = "_checkFaceRecognition";
			this._checkFaceRecognition.Size = new System.Drawing.Size(105, 17);
			this._checkFaceRecognition.TabIndex = 11;
			this._checkFaceRecognition.Text = "Face recognition";
			this._checkFaceRecognition.UseVisualStyleBackColor = true;
			this._checkFaceRecognition.CheckedChanged += new System.EventHandler(this._checkFaceRecognition_CheckedChanged);
			// 
			// ConfigurationWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 610);
			this.Controls.Add(this._checkFaceRecognition);
			this.Controls.Add(this._checkEyes);
			this.Controls.Add(this._status);
			this.Controls.Add(this._name);
			this.Controls.Add(this._saveImage);
			this.Controls.Add(this._upDownControl);
			this.Controls.Add(this._gridView);
			this.Controls.Add(this._processLabel);
			this.Controls.Add(this._processesComboBox);
			this.Controls.Add(this._followEyesButton);
			this.Controls.Add(this._imageBox);
			this.Name = "ConfigurationWindow";
			((System.ComponentModel.ISupportInitialize)(this._gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._imageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _followEyesButton;
		private System.Windows.Forms.ComboBox _processesComboBox;
		private System.Windows.Forms.Label _processLabel;
		private System.Windows.Forms.DataGridView _gridView;
		private Emgu.CV.UI.ImageBox _imageBox;
		private System.Windows.Forms.DomainUpDown _upDownControl;

		private Capture _capture;
		private DispatcherTimer _dispatcherTimer;

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
			set { _followEyesButton.Text = value; }
		}

		public IEnumerable<IProcessInfo> Processes
		{
			set
			{
				_gridView.DataSource = value;
				_processesComboBox.DataSource = value;
			}
		}

		public IImage ImageSource
		{
			set { _imageBox.Image = value; }
		}

		private void _followEyesButton_Click(object sender, System.EventArgs e)
		{
			presenter.StartFollowEyes((int)_processesComboBox.SelectedValue);
		}

		private void _saveImage_Click(object sender, System.EventArgs e)
		{
			presenter.SaveFace(_name.Text);
		}

		private System.Windows.Forms.Button _saveImage;
		private System.Windows.Forms.TextBox _name;
		private System.Windows.Forms.Label _status;
		private System.Windows.Forms.CheckBox _checkEyes;
		private System.Windows.Forms.CheckBox _checkFaceRecognition;
	}
}