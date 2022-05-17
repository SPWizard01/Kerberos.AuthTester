using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipingShare.LCLib.Asn1Processor
{
	//https://github.com/caesay/Asn1Editor/tree/master/LCLib/Asn1Processor
	public class VersionInfo
	{
		private static string versionStr = "V2008.09.29 - 1.0.20";

		private static string copyrightStr = "Copyright © 2003,2004,2005,2007,2008 Liping Dai. All rights reserved.";

		private static string contactInfo = "LipingShare@yahoo.com";

		private static string updateUrl = "http://www.lipingshare.com/Asn1Editor";

		private static string author = "Liping Dai";

		private static string releaseDate = "September 29, 2008";

		public static string VersionStr => versionStr;

		public static string CopyrightStr => copyrightStr;

		public static string ContactInfo => contactInfo;

		public static string UpdateUrl => updateUrl;

		public static string Author => author;

		public static string ReleaseDate => releaseDate;
	}

}
