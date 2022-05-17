using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipingShare.LCLib.Asn1Processor
{
	public class BinaryView
	{
		private int offsetWidth = 6;

		private int dataWidth = 16;

		private int totalWidth;

		private int hexWidth;

		public int OffsetWidth => offsetWidth;

		public int DataWidth => dataWidth;

		public int TotalWidth => totalWidth;

		public int HexWidth => hexWidth;

		public BinaryView()
		{
			CalculatePar();
		}

		public void SetPar(int offsetWidth, int dataWidth)
		{
			this.offsetWidth = offsetWidth;
			this.dataWidth = dataWidth;
			CalculatePar();
		}

		public BinaryView(int offsetWidth, int dataWidth)
		{
			SetPar(offsetWidth, dataWidth);
		}

		protected void CalculatePar()
		{
			totalWidth = offsetWidth + 2 + dataWidth * 3 + (dataWidth / 8 - 1) + 1 + dataWidth;
			hexWidth = totalWidth - dataWidth;
		}

		public string GenerateText(byte[] data)
		{
			return GetBinaryViewText(data, offsetWidth, dataWidth);
		}

		public void GetLocation(int byteOffset, ByteLocation loc)
		{
			int num = byteOffset - byteOffset / dataWidth * dataWidth;
			int num2 = byteOffset / dataWidth;
			int num3 = offsetWidth + 2 + num * 3;
			int hexColLen = 3;
			int hexOffset = num2 * totalWidth + num2 + num3;
			int num4 = hexWidth + num;
			int chOffset = num2 * totalWidth + num2 + num4;
			int chColLen = 1;
			loc.hexOffset = hexOffset;
			loc.hexColLen = hexColLen;
			loc.line = num2;
			loc.chOffset = chOffset;
			loc.chColLen = chColLen;
		}

		public static string GetBinaryViewText(byte[] data, int offsetWidth, int dataWidth)
		{
			string text = "";
			string format = "{0:X" + offsetWidth + "}  ";
			int num = 0;
			int num2 = 0;
			int num3 = offsetWidth + 2 + dataWidth * 3 + (dataWidth / 8 - 1) + 1 + dataWidth;
			int num4 = num3 - dataWidth;
			string text2 = "";
			string text3 = "";
			StringBuilder stringBuilder = new StringBuilder();
			string format2 = "{0,-" + num3 + "}\r\n";
			num2 = 0;
			while (num2 < data.Length)
			{
				text3 = string.Format(format, num++ * dataWidth);
				int num5 = num2;
				for (int i = 0; i < dataWidth; i++)
				{
					text3 += $"{data[num2++]:X2} ";
					if (num2 >= data.Length)
					{
						break;
					}
					if ((i + 1) % 8 == 0 && i != 0 && i + 1 < dataWidth)
					{
						text3 += " ";
					}
				}
				text3 += " ";
				int num6 = num2;
				text3 = text3.PadRight(num4, ' ');
				for (int i = num5; i < num6; i++)
				{
					text3 = ((data[i] >= 32 && data[i] <= 128) ? (text3 + (char)data[i]) : (text3 + '.'));
				}
				stringBuilder.AppendFormat(format2, text3);
			}
			return stringBuilder.ToString();
		}
	}

}
