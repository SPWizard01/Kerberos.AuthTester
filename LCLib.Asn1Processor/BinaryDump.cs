namespace LCLib.Asn1Processor
{
	public class BinaryDump
	{
		private byte[] data;

		private int offsetWidth = 3;

		private int dataWidth = 16;

		public byte[] Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		public int OffsetWidth
		{
			get
			{
				return offsetWidth;
			}
			set
			{
				offsetWidth = value;
			}
		}

		public int DataWidth
		{
			get
			{
				return dataWidth;
			}
			set
			{
				dataWidth = value;
			}
		}

		public static string Dump(byte[] data, int offsetWidth, int dataWidth)
		{
			string result = "";
			int num = 0;
			for (num = 0; num < data.Length; num++)
			{
			}
			return result;
		}
	}
}