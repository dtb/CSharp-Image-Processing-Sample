using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessor
{
	public class Processor
	{
		protected Image _image;

		public Image Image
		{
			get
			{
				return _image;
			}
			set
			{
				_image = value;
			}
		}

		public Image ThresholdMM(float thresh)
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height),ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			int size=bData.Stride * bData.Height;
			byte[] data = new byte[size];

			System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);

			for (int i = 0; i < size; i+=bitsPerPixel/8)
			{
				double magnitude = Math.Sqrt(Math.Pow(data[i], 2) + Math.Pow(data[i + 1], 2) + Math.Pow(data[i + 2], 2));
				if (magnitude < thresh)
				{
					data[i] = 0;
					data[i + 1] = 0;
					data[i + 2] = 0;
				}
				else
				{
					data[i] = 255;
					data[i + 1] = 255;
					data[i + 2] = 255;
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);

			b.UnlockBits(bData);

			return b;

		}

		private byte GetBitsPerPixel(PixelFormat pixelFormat)
		{
			switch (pixelFormat)
			{
				case PixelFormat.Format24bppRgb:
					return 24;
					break;
				case PixelFormat.Format32bppArgb:
				case PixelFormat.Format32bppPArgb:
				case PixelFormat.Format32bppRgb:
					return 32;
					break;
				default:
					throw new ArgumentException("Only 24 and 32 bit images are supported");

			}
		}

		/*No unsafe keyword!*/
		public Image ThresholdMA(float thresh)
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			/* GetBetsPerPixel just does a switch on the PixelFormat and returns the number */
			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			/*the size of the image in bytes */
			int size = bData.Stride * bData.Height;

			/*Allocate buffer for image*/
			byte[] data = new byte[size];

			/*This overload copies data of /size/ into /data/ from location specified (/Scan0/*/
			System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);

			for (int i = 0; i < size; i += bitsPerPixel / 8)
			{
				double magnitude = 1/3d*(data[i] +data[i + 1] +data[i + 2]);
				if (magnitude < thresh)
				{
					data[i] = 0;
					data[i + 1] = 0;
					data[i + 2] = 0;
				}
				else
				{
					data[i] = 255;
					data[i + 1] = 255;
					data[i + 2] = 255;
				}
			}

			/* This override copies the data back into the location specified */
			System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);

			b.UnlockBits(bData);

			return b;
		}

		public unsafe Image ThresholdUM(float thresh)
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);
						
			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			int size = bData.Stride * bData.Height;

			byte* scan0 = (byte *)bData.Scan0.ToPointer();

			int colWidth = bData.Width * bitsPerPixel / 8;

			for (int i = 0; i < bData.Height; ++i)
			{
				for (int j = 0; j < bData.Width; ++j)
				{
					byte* data = scan0 + i*bData.Stride+j*bitsPerPixel / 8;

					double magnitude = Math.Sqrt(Math.Pow(data[0], 2) + Math.Pow(data[1], 2) + Math.Pow(data[2], 2));
					if (magnitude < thresh)
					{
						data[0] = 0;
						data[1] = 0;
						data[2] = 0;
					}
					else
					{
						data[0] = 255;
						data[1] = 255;
						data[2] = 255;
					}
				}
			}

			b.UnlockBits(bData);

			return b;
		}

		/*Note unsafe keyword*/
		public unsafe Image ThresholdUA(float thresh)
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			/*This time we convert the IntPtr to a ptr*/
			byte* scan0 = (byte*)bData.Scan0.ToPointer();

			for (int i = 0; i < bData.Height; ++i)
			{
				for (int j = 0; j < bData.Width; ++j)
				{
					byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

					double magnitude = 1/3d*(data[0] + data[1] + data[2]);
					/*Just write the data into memory*/
					if (magnitude < thresh)
					{
						data[0] = 0;
						data[1] = 0;
						data[2] = 0;
					}
					else
					{
						data[0] = 255;
						data[1] = 255;
						data[2] = 255;
					}
				}
			}

			b.UnlockBits(bData);

			return b;
		}

		
		public Image ThresholdGS(float thresh)
		{
			Bitmap b = new Bitmap(_image);

			for (int i = 0; i < b.Height; ++i)
			{
				for (int j = 0; j < b.Width; ++j)
				{
					Color c = b.GetPixel(j, i);

					double magnitude = 1 / 3d * (c.B+c.G+c.R);
					
					if (magnitude < thresh)
					{
						b.SetPixel(j,i,Color.FromArgb(0,0,0));
					}
					else
					{
						b.SetPixel(j,i, Color.FromArgb(255,255,255));
					}
				}
			}

			return b;
		}

		public unsafe Image GrayscaleA()
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			int size = bData.Stride * bData.Height;

			byte* scan0 = (byte*)bData.Scan0.ToPointer();

			int colWidth = bData.Width * bitsPerPixel / 8;

			for (int i = 0; i < bData.Height; ++i)
			{
				for (int j = 0; j < bData.Width; ++j)
				{
					byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

					byte magnitude = (byte)(1 / 3d * (data[0] + data[1] + data[2]));
					data[0] = (byte)magnitude;
					data[1] = (byte)magnitude;
					data[2] = (byte)magnitude;
					
				}
			}

			b.UnlockBits(bData);

			return b;

		}

		public unsafe Image GrayscaleM()
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			int size = bData.Stride * bData.Height;

			byte* scan0 = (byte*)bData.Scan0.ToPointer();

			int colWidth = bData.Width * bitsPerPixel / 8;

			for (int i = 0; i < bData.Height; ++i)
			{
				for (int j = 0; j < bData.Width; ++j)
				{
					byte* data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

					byte magnitude = (byte)(Math.Sqrt(data[0] * data[0] + data[1]*data[1] + data[2]*data[2]));
					data[0] = (byte)magnitude;
					data[1] = (byte)magnitude;
					data[2] = (byte)magnitude;

				}
			}

			b.UnlockBits(bData);

			return b;

		}

		public unsafe Image Convolve(short [,] weights)
		{
			Bitmap source = new Bitmap(_image);

			Bitmap destination = new Bitmap((Image)_image.Clone());

			BitmapData srcData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);

			BitmapData destData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.ReadWrite, destination.PixelFormat);

			byte bytesPerPixel = (byte)(1/8d*GetBitsPerPixel(srcData.PixelFormat));

			int size = srcData.Stride * srcData.Height;

			byte* srcScan0 = (byte*)srcData.Scan0.ToPointer();
			byte* destScan0 = (byte*)destData.Scan0.ToPointer();

			int startX = weights.GetLength(0);
			int startY = weights.GetLength(1);

			int middleX = (int)Math.Floor(startX/2f);
			int middleY = (int)Math.Floor(startY/2f);

			int normFactor = SumWeights(weights);

			int [] value = new int[3];

			for (int i = middleY; i < srcData.Height-middleY; ++i)
			{
				for (int j = middleX; j < srcData.Width-middleX; ++j)
				{
					byte* srcCurrPx = srcScan0 + i * srcData.Stride + j * bytesPerPixel;
					byte* destCurrPx = destScan0 + i * destData.Stride + j * bytesPerPixel;

					for (int q = 0; q < startY; ++q)
					{
						for (int z = 0; z < startX; ++z)
						{
							byte *data = srcCurrPx + srcData.Stride * (q - middleY) + bytesPerPixel * (z - middleX);
							
							value[0] = value[0]+data[0] * weights[z, q];
							value[1] = value[1]+data[1] * weights[z, q];
							value[2] = value[2]+data[2] * weights[z, q];
						}
					}

					if (normFactor != 0)
					{
						value[0] = value[0] / normFactor;
						value[1] = value[1] / normFactor;
						value[2] = value[2] / normFactor;
					}
					else
					{
						value[0] = value[0] + 128;
						value[1] = value[1] + 128;
						value[2] = value[2] + 128;
					}

					if (value[0] > 255) value[0] = 255;
					if (value[1] > 255) value[1] = 255;
					if (value[2] > 255) value[2] = 255;

					if (value[0] < 0) value[0] = 0;
					if (value[1] < 0) value[1] = 0;
					if (value[2] < 0) value[2] = 0;

					destCurrPx[0] = (byte)value[0];
					destCurrPx[1] = (byte)value[1];
					destCurrPx[2] = (byte)value[2];

					value = new int[3];
				}
			}

			source.UnlockBits(srcData);
			destination.UnlockBits(destData);

			return destination;
		}

		public unsafe Image ConvolveThresh(short[,] weights, double thresh)
		{
						Bitmap source = new Bitmap(_image);

			Bitmap destination = new Bitmap((Image)_image.Clone());

			BitmapData srcData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);

			BitmapData destData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.ReadWrite, destination.PixelFormat);

			byte bytesPerPixel = (byte)(1/8d*GetBitsPerPixel(srcData.PixelFormat));

			int size = srcData.Stride * srcData.Height;

			byte* srcScan0 = (byte*)srcData.Scan0.ToPointer();
			byte* destScan0 = (byte*)destData.Scan0.ToPointer();

			int startX = weights.GetLength(0);
			int startY = weights.GetLength(1);

			int middleX = (int)Math.Floor(startX/2f);
			int middleY = (int)Math.Floor(startY/2f);

			int normFactor = SumWeights(weights);

			int [] value = new int[3];

			for (int i = middleY; i < srcData.Height-middleY; ++i)
			{
				for (int j = middleX; j < srcData.Width-middleX; ++j)
				{
					byte* srcCurrPx = srcScan0 + i * srcData.Stride + j * bytesPerPixel;
					byte* destCurrPx = destScan0 + i * destData.Stride + j * bytesPerPixel;

					for (int q = 0; q < startY; ++q)
					{
						for (int z = 0; z < startX; ++z)
						{
							byte *data = srcCurrPx + srcData.Stride * (q - middleY) + bytesPerPixel * (z - middleX);
							
							value[0] = value[0]+data[0] * weights[z, q];
							value[1] = value[1]+data[1] * weights[z, q];
							value[2] = value[2]+data[2] * weights[z, q];
						}
					}

					if (normFactor != 0)
					{
						value[0] = value[0] / normFactor;
						value[1] = value[1] / normFactor;
						value[2] = value[2] / normFactor;
					}
					else
					{
						value[0] = value[0] + 128;
						value[1] = value[1] + 128;
						value[2] = value[2] + 128;
					}

					if (value[0] > thresh) value[0] = 255;
					if (value[1] > thresh) value[1] = 255;
					if (value[2] > thresh) value[2] = 255;

					if (value[0] < thresh) value[0] = 0;
					if (value[1] < thresh) value[1] = 0;
					if (value[2] < thresh) value[2] = 0;

					destCurrPx[0] = (byte)value[0];
					destCurrPx[1] = (byte)value[1];
					destCurrPx[2] = (byte)value[2];

					value = new int[3];
				}
			}

			source.UnlockBits(srcData);
			destination.UnlockBits(destData);

			return destination;
		}

		private int SumWeights(short[,] weights)
		{
			int sum=0;
			for(int i=0;i<weights.GetLength(0); i++)
				for(int j=0;j<weights.GetLength(1);j++)
					sum+=weights[i,j];

			return sum;
		}

		public unsafe Image SetPixel(int x, int y)
		{
			Bitmap b = new Bitmap(_image);

			BitmapData bData = b.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

			byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);

			byte* scan0 = (byte*)bData.Scan0.ToPointer();

			scan0[y * bData.Stride + x * 4] = 0;
			scan0[y * bData.Stride + x * 4 + 1] = 255;
			scan0[y * bData.Stride + x * 4 + 2] = 0;

			b.UnlockBits(bData);

			return b;
		}
	}
}
