using Kerb.AuthTester.NativeWin32.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Utilities
{
    public static class Helper
    {
        public static DateTime GetDateTimeFromFILETIME(ulong fileTime)
        {
            return GetDateTimeFromFILETIME((long)fileTime);
        }

        public static DateTime GetDateTimeFromFILETIME(long fileTime)
        {
            return DateTime.FromFileTime(fileTime);
        }

        public static string GetStringFromUNICODE_STRING(UNICODE_STRING unicodeString)
        {
            return unicodeString.ToString();
            //return Marshal.PtrToStringUni(unicodeString.Buffer, (int)unicodeString.Length / 2);
        }

        public static UNICODE_STRING GetUNICODE_STRINGFromString(string parseString)
        {
            var unicodeString = new UNICODE_STRING();
            var strBytes = Encoding.Unicode.GetBytes(parseString + char.MinValue);
            var ptrStr = Marshal.StringToHGlobalUni(parseString);
            //unicodeString.Buffer = ptrStr;
            unicodeString.Length = (ushort)(strBytes.Length - 2);
            unicodeString.MaximumLength = (ushort)strBytes.Length;
            return unicodeString;
        }

        public static string[] ReadExternalName(IntPtr ptr)
        {
            int nameCount = (ushort)Marshal.ReadInt16(ptr, 2);
            ptr = (IntPtr)((long)ptr + 4 + IntPtr.Size - 4);
            string[] names = new string[nameCount];
            for (int i = 0; i < nameCount; i++)
            {
                names[i] = ReadUnicodeString(ref ptr);
            }
            return names;
        }

        private static string ReadUnicodeString(ref IntPtr ptr)
        {
            UNICODE_STRING str = (UNICODE_STRING)Marshal.PtrToStructure(ptr, typeof(UNICODE_STRING));
            //ptr = (IntPtr)((long)ptr + Marshal.SizeOf(typeof(UNICODE_STRING)));
            //return Marshal.PtrToStringUni(str.Buffer, str.Length / 2);
            return str.ToString();
        }

        public static byte[] ReadBytes(IntPtr ptr, int length)
        {
            byte[] buf = new byte[length];
            Marshal.Copy(ptr, buf, 0, length);
            return buf;
        }
    }
}
