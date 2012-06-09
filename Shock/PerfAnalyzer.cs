using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ImageProcessor;

namespace Shock
{
	public partial class PerfAnalyzer : Form
	{
		private Image _img;

		private IAsyncResult _reso;

		private DoTestDeg _deg;

		public PerfAnalyzer(Image img)
		{
			_img = img;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int numOps=0;
			if(!Int32.TryParse(nOps.Text, out numOps))
				return;

			results.Text = "Performing " + nOps.Text + " operations on 2 algorithms."+Environment.NewLine;

			_deg = DoTest;

			_reso = _deg.BeginInvoke(numOps, GS.Checked, IAsyncCallBack, null);
			
		}

		delegate void DoTestDeg(int numOps, bool doGS);

		private void DoTest(int numOps, bool doGS)
		{
			Processor p = new Processor();
			p.Image = _img;

			
			DisplayMessage("Starting managed average method"+Environment.NewLine);

			Stopwatch s = Stopwatch.StartNew();
			for (int i = 0; i < numOps; ++i)
				p.ThresholdMA(125);
			s.Stop();

			DisplayMessage("Managed average method took "+s.ElapsedMilliseconds.ToString()+" milliseconds, for an average of "+(s.ElapsedMilliseconds/(float)numOps)+" per threshold."+Environment.NewLine);

			s.Reset();

			DisplayMessage("Starting unsafe average method" + Environment.NewLine);
			s.Start();
			for (int i = 0; i < numOps; ++i)
				p.ThresholdUA(125);
			s.Stop();
			DisplayMessage("Unsafe average method took " + s.ElapsedMilliseconds + " milliseconds, for an average of " + (s.ElapsedMilliseconds / (float)numOps) + " per threshold." + Environment.NewLine);

			s.Reset();

			if (doGS)
			{
				DisplayMessage("Starting GetPixel\\SetPixel average method" + Environment.NewLine);
				s.Start();
				for (int i = 0; i < numOps; ++i)
					p.ThresholdGS(125);
				s.Stop();
				DisplayMessage("GetPixel\\SetPixel average method took " + s.ElapsedMilliseconds + " milliseconds, for an average of " + (s.ElapsedMilliseconds / (float)numOps) + " per threshold." + Environment.NewLine);
			}
		}

		delegate void DispDelegate(string msg);

		private void DisplayMessage(string msg)
		{
			if (results.InvokeRequired)
				results.Invoke(new DispDelegate(DisplayMessage), msg);
			else
				results.Text += msg;
		}

		private void IAsyncCallBack(IAsyncResult r)
		{
			_deg.EndInvoke(r);
		}
	}
}