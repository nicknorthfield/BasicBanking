/*
 * Created by SharpDevelop.
 * User: Y7NNORTH
 * Date: 22/07/2016
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BasicBanking3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label FileLocationLabel;
		private System.Windows.Forms.TextBox inputFileLocationTextBox;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ListBox spendsListBox;
		private System.Windows.Forms.ListBox otherListBox;
		private System.Windows.Forms.Label spendsLabel;
		private System.Windows.Forms.Label otherLabel;
		private System.Windows.Forms.CheckBox saveToFileCheckbox;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.FileLocationLabel = new System.Windows.Forms.Label();
			this.inputFileLocationTextBox = new System.Windows.Forms.TextBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.RunButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.spendsListBox = new System.Windows.Forms.ListBox();
			this.otherListBox = new System.Windows.Forms.ListBox();
			this.spendsLabel = new System.Windows.Forms.Label();
			this.otherLabel = new System.Windows.Forms.Label();
			this.saveToFileCheckbox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// FileLocationLabel
			// 
			this.FileLocationLabel.Location = new System.Drawing.Point(13, 13);
			this.FileLocationLabel.Name = "FileLocationLabel";
			this.FileLocationLabel.Size = new System.Drawing.Size(100, 23);
			this.FileLocationLabel.TabIndex = 0;
			this.FileLocationLabel.Text = "Input file location";
			// 
			// inputFileLocationTextBox
			// 
			this.inputFileLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.inputFileLocationTextBox.Location = new System.Drawing.Point(13, 40);
			this.inputFileLocationTextBox.Name = "inputFileLocationTextBox";
			this.inputFileLocationTextBox.Size = new System.Drawing.Size(651, 20);
			this.inputFileLocationTextBox.TabIndex = 1;
			// 
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point(500, 8);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(75, 23);
			this.BrowseButton.TabIndex = 2;
			this.BrowseButton.Text = "Browse";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButtonClick);
			// 
			// RunButton
			// 
			this.RunButton.Location = new System.Drawing.Point(581, 8);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(75, 23);
			this.RunButton.TabIndex = 3;
			this.RunButton.Text = "Run";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.RunButtonClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// spendsListBox
			// 
			this.spendsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.spendsListBox.FormattingEnabled = true;
			this.spendsListBox.Location = new System.Drawing.Point(13, 93);
			this.spendsListBox.Name = "spendsListBox";
			this.spendsListBox.Size = new System.Drawing.Size(651, 277);
			this.spendsListBox.TabIndex = 4;
			// 
			// otherListBox
			// 
			this.otherListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.otherListBox.FormattingEnabled = true;
			this.otherListBox.Location = new System.Drawing.Point(13, 403);
			this.otherListBox.Name = "otherListBox";
			this.otherListBox.Size = new System.Drawing.Size(651, 173);
			this.otherListBox.TabIndex = 5;
			// 
			// spendsLabel
			// 
			this.spendsLabel.Location = new System.Drawing.Point(13, 67);
			this.spendsLabel.Name = "spendsLabel";
			this.spendsLabel.Size = new System.Drawing.Size(100, 23);
			this.spendsLabel.TabIndex = 6;
			this.spendsLabel.Text = "Spends";
			// 
			// otherLabel
			// 
			this.otherLabel.Location = new System.Drawing.Point(12, 377);
			this.otherLabel.Name = "otherLabel";
			this.otherLabel.Size = new System.Drawing.Size(100, 23);
			this.otherLabel.TabIndex = 7;
			this.otherLabel.Text = "Other";
			// 
			// saveToFileCheckbox
			// 
			this.saveToFileCheckbox.Location = new System.Drawing.Point(390, 7);
			this.saveToFileCheckbox.Name = "saveToFileCheckbox";
			this.saveToFileCheckbox.Size = new System.Drawing.Size(104, 24);
			this.saveToFileCheckbox.TabIndex = 8;
			this.saveToFileCheckbox.Text = "Save to file?";
			this.saveToFileCheckbox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 591);
			this.Controls.Add(this.saveToFileCheckbox);
			this.Controls.Add(this.otherLabel);
			this.Controls.Add(this.spendsLabel);
			this.Controls.Add(this.otherListBox);
			this.Controls.Add(this.spendsListBox);
			this.Controls.Add(this.RunButton);
			this.Controls.Add(this.BrowseButton);
			this.Controls.Add(this.inputFileLocationTextBox);
			this.Controls.Add(this.FileLocationLabel);
			this.Name = "MainForm";
			this.Text = "BasicBanking3";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
