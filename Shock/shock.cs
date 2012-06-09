using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ImageProcessor;

namespace Shock
{
	public partial class Shock : Form
	{
		Processor p;
		public Shock()
		{
			InitializeComponent();
			p = new Processor();
		}

		int X=0;
		int Y=0;
		int referenceLine=0;

		public enum State
		{
			RefLine, X, Y, None
		};

		public System.Drawing.Drawing2D.GraphicsState s;

		private State DrawingState = State.None;

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] filename = new string[] { };
			string[] f = e.Data.GetFormats();
			Image s = null;
			try
			{
				if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
				{
					filename = (string[])e.Data.GetData(DataFormats.FileDrop);
					this.Text = Path.GetFileName(filename[0]);
					s = Image.FromFile(filename[0]);
				}

			}
			catch (Exception x) { MessageBox.Show(x.Message); }
			
			if(s!=null)
			{
				try
				{
					pictureBox1.Image = s;
					p.Image = pictureBox1.Image;
				}
				catch (Exception x) { }
			}
		}

		private void thresh_ValueChanged(object sender, EventArgs e)
		{
			if(GS.Checked)
				pictureBox1.Image = p.ThresholdGS(255 * thresh.Value / thresh.Maximum);
			else if(MA.Checked)
				pictureBox1.Image = p.ThresholdMA(255 * thresh.Value / thresh.Maximum);
			else if(UM.Checked)
				pictureBox1.Image = p.ThresholdUM(255 * thresh.Value / thresh.Maximum);
			else if(UA.Checked)
				pictureBox1.Image = p.ThresholdUA(255 * thresh.Value / thresh.Maximum);
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = p.GrayscaleA();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = p.GrayscaleM();
		}

		delegate Image ConvolveDelegate(short [,] weights);
		ConvolveDelegate deg2;

		private void button1_Click(object sender, EventArgs e)
		{
			short[,] weights = new short[7, 7]{{ 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 4, 4, 4, 1, 1},
												{ 1, 3, 4, 5, 4, 3, 1},
												{ 1, 1, 4, 4, 4, 3, 1},
												{ 1, 1, 1, 3, 3, 3, 1},
												{ 1, 1, 1, 1, 1, 1, 6}};

			deg2 = p.Convolve;
			deg2.BeginInvoke(weights, Callback2, null);

		}

		public void Callback2(IAsyncResult r)
		{
			pictureBox1.Image = deg2.EndInvoke(r);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (pictureBox1.Image == null)
				return;

			PerfAnalyzer perfy = new PerfAnalyzer(pictureBox1.Image);

			perfy.Show();
		}
		delegate Image ConvolveThreshDelegate(short[,] weights, double threshhold);
		ConvolveThreshDelegate deg;
		private void button2_Click_1(object sender, EventArgs e)
		{
			short[,] weights = new short[15, 15]{{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
												{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};

			double t = 255 * thresh.Value / thresh.Maximum;
			
			deg = p.ConvolveThresh;
			deg.BeginInvoke(weights, t, Callback, null);
		}

		public void Callback(IAsyncResult r)
		{
			pictureBox1.Image = deg.EndInvoke(r);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			p.Image = pictureBox1.Image;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			DrawingState = State.X;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			double angle = 180/Math.PI*Math.Atan(Y / (double)X);

			textBox1.Text = angle.ToString();
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			switch (this.DrawingState)
			{
				case State.RefLine:
					DrawRefLine(sender, e);
					break;
				case State.X:
					DrawX(sender, e);
					break;
				case State.Y:
					DrawY(sender, e);
					break;
			}
		}
		Point Y1;
		Point Y2;
		private void DrawY(object sender, MouseEventArgs e)
		{
			Graphics g = pictureBox1.CreateGraphics();
			
			int y=0;
			if (Math.Abs(e.Y - referenceLine) / (double)referenceLine < .10)
				y = referenceLine;
			else
				y = e.Y;

			if (Y1 == Point.Empty)
				Y1 = new Point(e.X, y);
			else if (X2 == Point.Empty)
			{
				Y2 = new Point(Y1.X, y);
				g.DrawLine(new Pen(Brushes.Blue, 1), Y1, Y2);
				Y = Y2.Y - Y1.Y;
			}

		}

		Point X1;
		Point X2;
		private void DrawX(object sender, MouseEventArgs e)
		{
			Graphics g = pictureBox1.CreateGraphics();

			int x;
			if (Y1 != Point.Empty && Math.Abs(e.X - Y1.X) / (double)Y1.X < .10)
				x = Y1.X;
			else
				x = e.X;
			
			if (X1 == Point.Empty)
				X1 = new Point(e.X, referenceLine);
			else if (X2 == Point.Empty)
			{
				X2 = new Point(e.X, referenceLine);
				g.DrawLine(new Pen(Brushes.Blue, 1), X1, X2);
				X = X2.X - X1.X;
			}
		}

		private void DrawRefLine(object sender, MouseEventArgs e)
		{
			Graphics g = pictureBox1.CreateGraphics();

			g.DrawLine(new Pen(Brushes.Red, 1f), new Point(0, e.Y), new Point(pictureBox1.Width, e.Y));
			
			referenceLine = e.Y;
		}

		private void button4_MouseDown(object sender, MouseEventArgs e)
		{
			DrawingState = State.RefLine;
		}

		private void button4_Click_2(object sender, EventArgs e)
		{
			DrawingState = State.RefLine;
		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			DrawingState = State.Y;
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (referenceLine != 0) e.Graphics.DrawLine(new Pen(Brushes.Red), new Point(0, referenceLine), new Point(pictureBox1.Width, referenceLine));

			if (Y1 != Point.Empty && Y2 != Point.Empty)
				e.Graphics.DrawLine(new Pen(Brushes.Blue), Y1, Y2);

			if (X1 != Point.Empty && X2 != Point.Empty)
				e.Graphics.DrawLine(new Pen(Brushes.Blue), X1, X2);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			X1 = X2 = Y1 = Y2 = Point.Empty;
			referenceLine = 0;
			X = 0;
			Y = 0;

			pictureBox1.Invalidate();
		}
	}
}