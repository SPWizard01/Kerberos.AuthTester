using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipingShare.LCLib.Asn1Processor
{
	public class Asn1ClipboardData
	{
		private static string asn1FormatName = "Asn1NodeDataFormat";

		public static void Copy(Asn1Node node)
		{
			DataFormats.GetFormat(asn1FormatName);
			MemoryStream memoryStream = new MemoryStream();
			node.SaveData(memoryStream);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			memoryStream.Close();
			DataObject dataObject = new DataObject();
			dataObject.SetData(asn1FormatName, array);
			dataObject.SetData(DataFormats.Text, Asn1Util.FormatString(Asn1Util.ToHexString(array), 32, 2));
			Clipboard.SetDataObject(dataObject, copy: true);
		}

		public static Asn1Node Paste()
		{
			DataFormats.GetFormat(asn1FormatName);
			Asn1Node asn1Node = new Asn1Node();
			IDataObject dataObject = Clipboard.GetDataObject();
			byte[] array = (byte[])dataObject.GetData(asn1FormatName);
			if (array != null)
			{
				MemoryStream memoryStream = new MemoryStream(array);
				memoryStream.Position = 0L;
				asn1Node.LoadData(memoryStream);
			}
			else
			{
				string text = (string)dataObject.GetData(DataFormats.Text);
				new Asn1Node();
				if (Asn1Util.IsAsn1EncodedHexStr(text))
				{
					byte[] byteData = Asn1Util.HexStrToBytes(text);
					asn1Node.LoadData(byteData);
				}
			}
			return asn1Node;
		}

		public static bool IsDataReady()
		{
			bool result = false;
			try
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				byte[] array = (byte[])dataObject.GetData(asn1FormatName);
				if (array != null)
				{
					return true;
				}
				string dataStr = (string)dataObject.GetData(DataFormats.Text);
				if (Asn1Util.IsAsn1EncodedHexStr(dataStr))
				{
					return true;
				}
				return result;
			}
			catch
			{
				return false;
			}
		}
	}
}
