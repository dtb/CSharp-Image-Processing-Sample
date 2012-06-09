namespace Shock
{
	partial class PerfAnalyzer
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
			this.nOps = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.results = new System.Windows.Forms.TextBox();
			this.GS = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nOps
			// 
			this.nOps.Location = new System.Drawing.Point(122, 13);
			this.nOps.Name = "nOps";
			this.nOps.Size = new System.Drawing.Size(51, 20);
			this.nOps.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.GS);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.nOps);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(47, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 87);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test Control";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Operations";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(109, 55);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Go!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// results
			// 
			this.results.Location = new System.Drawing.Point(12, 105);
			this.results.Multiline = true;
			this.results.Name = "results";
			this.results.ReadOnly = true;
			this.results.Size = new System.Drawing.Size(260, 147);
			this.results.TabIndex = 2;
			// 
			// GS
			// 
			this.GS.AutoSize = true;
			this.GS.Location = new System.Drawing.Point(9, 32);
			this.GS.Name = "GS";
			this.GS.Size = new System.Drawing.Size(152, 17);
			this.GS.TabIndex = 2;
			this.GS.Text = "Include GetPixel\\SetPixel?";
			this.GS.UseVisualStyleBackColor = true;
			// 
			// PerfAnalyzer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.results);
			this.Controls.Add(this.groupBox1);
			this.Name = "PerfAnalyzer";
			this.Text = "PerfAnalyzer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox nOps;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox results;
		private System.Windows.Forms.CheckBox GS;
	}
}