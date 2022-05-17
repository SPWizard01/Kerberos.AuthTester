using Kerb.AuthTester.NativeWin32.Structures;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Kerb.AuthTester.NativeWin32
{
    public static class NativeMethods
    {
        private const string SECUR32 = "secur32.dll";
        private const string ADVAPI32 = "advapi32.dll";

        [DllImport(SECUR32)]
        public static extern int LsaConnectUntrusted(out IntPtr LsaHandle);

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/nf-ntsecapi-lsaregisterlogonprocess
        /// </summary>
        /// <param name="LogonProcessName">app name, useful for admins</param>
        /// <param name="LsaHandle">ptr to handle</param>
        /// <param name="SecurityMode">Not used</param>
        /// <returns>0 if success</returns>
        [DllImport(SECUR32)]
        public static extern int LsaRegisterLogonProcess(ref LSA_STRING LogonProcessName, out IntPtr LsaHandle, out ulong SecurityMode);

        [DllImport(SECUR32)]
        public static extern int LsaDeregisterLogonProcess(IntPtr LsaHandle);

        [DllImport(SECUR32)]
        public static extern int LsaLookupAuthenticationPackage(IntPtr LsaHandle, ref LSA_STRING PackageName, out IntPtr AuthenticationPackage);

        [DllImport(SECUR32)]
        public static extern int LsaFreeReturnBuffer(IntPtr buffer);

        [DllImport(SECUR32)]
        public static extern int LsaCallAuthenticationPackage(IntPtr LsaHandle, IntPtr AuthenticationPackage, IntPtr ProtocolSubmitBuffer, uint SubmitBufferLength, out IntPtr ProtocolReturnBuffer, out uint ReturnBufferLength, out uint ProtocolStatus);


        [DllImport(ADVAPI32)]
        public static extern int LsaNtStatusToWinError(int Status);

        public static void LsaThrowIfError(int result, [CallerMemberName] string caller = "Unknown")
        {
            if (result != 0)
            {

                Console.WriteLine($"Native call from ({caller}) failed with NTSTATUS code: {result} (0x{result:x8})");
                result = LsaNtStatusToWinError(result);

                throw new Win32Exception(result);
            }
        }
    }
}
