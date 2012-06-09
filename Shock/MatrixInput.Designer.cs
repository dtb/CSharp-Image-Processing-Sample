namespace Shock
{
	partial class MatrixInput
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
			this.label1 = new System.Windows.Forms.Label();
			this.matrixBox = new System.Windows.Forms.TextBox();
			this.presetBox = new System.Windows.Forms.ComboBox();
			this.parse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(205, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter a matrix formatted as a C# 2-d array.";
			// 
			// matrixBox
			// 
			this.matrixBox.AcceptsReturn = true;
			this.matrixBox.AcceptsTab = true;
			this.matrixBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.matrixBox.Location = new System.Drawing.Point(12, 52);
			this.matrixBox.Multiline = true;
			this.matrixBox.Name = "matrixBox";
			this.matrixBox.Size = new System.Drawing.Size(381, 285);
			this.matrixBox.TabIndex = 1;
			// 
			// presetBox
			// 
			this.presetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.presetBox.FormattingEnabled = true;
			this.presetBox.Items.AddRange(new object[] {
            "Gaussian Blur",
            "Motion Blur",
            "Sharpen"});
			this.presetBox.Location = new System.Drawing.Point(15, 25);
			this.presetBox.Name = "presetBox";
			this.presetBox.Size = new System.Drawing.Size(121, 21);
			this.presetBox.TabIndex = 2;
			// 
			// parse
			// 
			this.parse.Location = new System.Drawing.Point(318, 343);
			this.parse.Name = "parse";
			this.parse.Size = new System.Drawing.Size(75, 23);
			this.parse.TabIndex = 3;
			this.parse.Text = "Enter Matrix";
			this.parse.UseVisualStyleBackColor = true;
			// 
			// MatrixInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 375);
			this.Controls.Add(this.parse);
			this.Controls.Add(this.presetBox);
			this.Controls.Add(this.matrixBox);
			this.Controls.Add(this.label1);
			this.Name = "MatrixInput";
			this.Text = "MatrixInput";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox matrixBox;
		private System.Windows.Forms.ComboBox presetBox;
		private System.Windows.Forms.Button parse;

	}
}