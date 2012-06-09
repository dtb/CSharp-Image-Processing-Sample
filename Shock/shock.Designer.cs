namespace Shock
{
	partial class Shock
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.thresh = new System.Windows.Forms.TrackBar();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.UA = new System.Windows.Forms.RadioButton();
			this.UM = new System.Windows.Forms.RadioButton();
			this.MA = new System.Windows.Forms.RadioButton();
			this.GS = new System.Windows.Forms.RadioButton();
			this.greyM = new System.Windows.Forms.Button();
			this.greyA = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.startPA = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.thresh)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(977, 739);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.Location = new System.Drawing.Point(745, 848);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Convolve!!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupBox1.Controls.Add(this.thresh);
			this.groupBox1.Location = new System.Drawing.Point(387, 761);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(127, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thresholding";
			// 
			// thresh
			// 
			this.thresh.Location = new System.Drawing.Point(6, 15);
			this.thresh.Maximum = 100;
			this.thresh.Name = "thresh";
			this.thresh.Size = new System.Drawing.Size(116, 45);
			this.thresh.TabIndex = 1;
			this.thresh.TickFrequency = 10;
			this.thresh.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.thresh.Value = 50;
			this.thresh.ValueChanged += new System.EventHandler(this.thresh_ValueChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupBox3.Controls.Add(this.UA);
			this.groupBox3.Controls.Add(this.UM);
			this.groupBox3.Controls.Add(this.MA);
			this.groupBox3.Controls.Add(this.GS);
			this.groupBox3.Location = new System.Drawing.Point(181, 761);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 110);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Threshold Mode";
			// 
			// UA
			// 
			this.UA.AutoSize = true;
			this.UA.Location = new System.Drawing.Point(7, 87);
			this.UA.Name = "UA";
			this.UA.Size = new System.Drawing.Size(102, 17);
			this.UA.TabIndex = 0;
			this.UA.TabStop = true;
			this.UA.Text = "Unsafe Average";
			this.UA.UseVisualStyleBackColor = true;
			// 
			// UM
			// 
			this.UM.AutoSize = true;
			this.UM.Location = new System.Drawing.Point(7, 64);
			this.UM.Name = "UM";
			this.UM.Size = new System.Drawing.Size(112, 17);
			this.UM.TabIndex = 0;
			this.UM.TabStop = true;
			this.UM.Text = "Unsafe Magnitude";
			this.UM.UseVisualStyleBackColor = true;
			// 
			// MA
			// 
			this.MA.AutoSize = true;
			this.MA.Location = new System.Drawing.Point(7, 41);
			this.MA.Name = "MA";
			this.MA.Size = new System.Drawing.Size(113, 17);
			this.MA.TabIndex = 0;
			this.MA.TabStop = true;
			this.MA.Text = "Managed Average";
			this.MA.UseVisualStyleBackColor = true;
			// 
			// GS
			// 
			this.GS.AutoSize = true;
			this.GS.Location = new System.Drawing.Point(7, 18);
			this.GS.Name = "GS";
			this.GS.Size = new System.Drawing.Size(105, 17);
			this.GS.TabIndex = 0;
			this.GS.TabStop = true;
			this.GS.Text = "GetPixel SetPixel";
			this.GS.UseVisualStyleBackColor = true;
			// 
			// greyM
			// 
			this.greyM.Location = new System.Drawing.Point(6, 19);
			this.greyM.Name = "greyM";
			this.greyM.Size = new System.Drawing.Size(38, 23);
			this.greyM.TabIndex = 5;
			this.greyM.Text = "M";
			this.greyM.UseVisualStyleBackColor = true;
			this.greyM.Click += new System.EventHandler(this.button2_Click);
			// 
			// greyA
			// 
			this.greyA.Location = new System.Drawing.Point(50, 19);
			this.greyA.Name = "greyA";
			this.greyA.Size = new System.Drawing.Size(34, 23);
			this.greyA.TabIndex = 6;
			this.greyA.Text = "A";
			this.greyA.UseVisualStyleBackColor = true;
			this.greyA.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupBox2.Controls.Add(this.greyM);
			this.groupBox2.Controls.Add(this.greyA);
			this.groupBox2.Location = new System.Drawing.Point(520, 761);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(92, 48);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Greyscale";
			// 
			// startPA
			// 
			this.startPA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.startPA.Location = new System.Drawing.Point(393, 842);
			this.startPA.Name = "startPA";
			this.startPA.Size = new System.Drawing.Size(116, 23);
			this.startPA.TabIndex = 8;
			this.startPA.Text = "Performance Analysis";
			this.startPA.UseVisualStyleBackColor = true;
			this.startPA.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button2.Location = new System.Drawing.Point(745, 819);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "CThresh";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button3
			// 
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button3.Location = new System.Drawing.Point(745, 786);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "Set Image";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click_1);
			// 
			// button4
			// 
			this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button4.Location = new System.Drawing.Point(664, 757);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "Ref Line";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click_2);
			this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button4_MouseDown);
			// 
			// button5
			// 
			this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button5.Location = new System.Drawing.Point(664, 786);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 12;
			this.button5.Text = "Y";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click_1);
			// 
			// button6
			// 
			this.button6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button6.Location = new System.Drawing.Point(664, 819);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 13;
			this.button6.Text = "X";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button7.Location = new System.Drawing.Point(664, 848);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 14;
			this.button7.Text = "Get Angle";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.textBox1.Location = new System.Drawing.Point(558, 850);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 15;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(745, 757);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 16;
			this.button8.Text = "Reset";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1001, 883);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.startPA);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "Form1";
			this.Text = "Form1";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.thresh)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TrackBar thresh;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton UA;
		private System.Windows.Forms.RadioButton UM;
		private System.Windows.Forms.RadioButton MA;
		private System.Windows.Forms.RadioButton GS;
		private System.Windows.Forms.Button greyM;
		private System.Windows.Forms.Button greyA;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button startPA;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button8;
	}
}

