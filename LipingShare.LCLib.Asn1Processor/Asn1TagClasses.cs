using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipingShare.LCLib.Asn1Processor
{
	public class Asn1TagClasses
	{
		public const byte CLASS_MASK = 192;

		public const byte UNIVERSAL = 0;

		public const byte CONSTRUCTED = 32;

		public const byte APPLICATION = 64;

		public const byte CONTEXT_SPECIFIC = 128;

		public const byte PRIVATE = 192;
	}
}
