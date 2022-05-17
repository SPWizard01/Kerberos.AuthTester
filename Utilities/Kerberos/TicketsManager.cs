using Kerb.AuthTester.Models;
using Kerb.AuthTester.NativeWin32;
using Kerb.AuthTester.NativeWin32.Structures;
using System.Runtime.InteropServices;
using System.Text;

namespace Kerb.AuthTester.Utilities.Kerberos
{
    public class TicketsManager : IDisposable
    {
        private IntPtr _lsaHandle = IntPtr.Zero;

        private IntPtr _kerberosPackageId;


        public TicketsManager()
        {
            //try
            //{
            //    var app = new LSA_STRING("KerbAuthTester");
            //    var privLogonResult = NativeMethods.LsaRegisterLogonProcess(ref app, out _lsaHandle, out _);
            //    NativeMethods.LsaThrowIfError(privLogonResult, "TicketManager.ctor->LsaRegisterLogonProcess");
            //}
            //catch
            //{
            //    Console.WriteLine($"Unable to register LsaRegisterLogonProcess, are you running as administrator?");

            //}
            var logonResult = NativeMethods.LsaConnectUntrusted(out _lsaHandle);
            NativeMethods.LsaThrowIfError(logonResult, "TicketManager.ctor->LsaConnectUntrusted");
            var lsaPackage = new LsaPackage(LSA_PACKAGE_NAME.MICROSOFT_KERBEROS_NAME_A);
            var winStatusCodes = NativeMethods.LsaLookupAuthenticationPackage(_lsaHandle, ref lsaPackage.PLSA_STRING, out _kerberosPackageId);
            NativeMethods.LsaThrowIfError(winStatusCodes, "TicketManager.ctor->LsaLookupAuthenticationPackage");
        }


        private TicketCacheResponse<KERB_QUERY_TKT_CACHE_EX3_RESPONSE> GetExtendedTicketCache()
        {
            var ticketCacheRequest = new KERB_QUERY_TKT_CACHE_REQUEST
            {
                MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbQueryTicketCacheEx3Message,
                LogonId = 0
            };
            var sizeOfData = Marshal.SizeOf(ticketCacheRequest);
            var submitData = Marshal.AllocHGlobal(sizeOfData);
            Marshal.StructureToPtr(ticketCacheRequest, submitData, true);


            var winStatusCodes = NativeMethods.LsaCallAuthenticationPackage(_lsaHandle,
                                                    _kerberosPackageId,
                                                    submitData,
                                                    (uint)sizeOfData,
                                                    out IntPtr respPtr,
                                                    out _,
                                                    out _);
            Marshal.FreeHGlobal(submitData);
            if (winStatusCodes != 0)
            {
                throw new Exception(string.Concat("LsaCallAuthenticationPackage (LsaGetTickets) failed with NTSTATUS code: ", winStatusCodes, " (0x", winStatusCodes.ToString("x8"), ")"));
            }
            var cacheResp = Marshal.PtrToStructure<KERB_QUERY_TKT_CACHE_EX3_RESPONSE>(respPtr);
            return new TicketCacheResponse<KERB_QUERY_TKT_CACHE_EX3_RESPONSE> { Response = cacheResp, ResponsePointer = respPtr };
        }
        public List<ExtendedTreeViewTicket> GetExtendedTickets()
        {
            var retList = new List<ExtendedTreeViewTicket>();
            var a = GetExtendedTicketCache();
            var ticketCount = a.Response.CountOfTickets;
            var sizeOfInfo = Marshal.SizeOf(typeof(KERB_TICKET_CACHE_INFO_EX3));
            var fieldOffset = Marshal.OffsetOf<KERB_QUERY_TKT_CACHE_EX3_RESPONSE>(nameof(KERB_QUERY_TKT_CACHE_EX3_RESPONSE.Tickets));
            var startAddress = a.ResponsePointer.ToInt64() + fieldOffset.ToInt64();
            for (var i = 0; i < ticketCount; i++)
            {
                var ptrAddr = startAddress + i * sizeOfInfo;
                var cacheInfo = Marshal.PtrToStructure<KERB_TICKET_CACHE_INFO_EX3>(new IntPtr(ptrAddr));
                var ticket = new ExtendedTreeViewTicket();
                ticket.StartTime = Helper.GetDateTimeFromFILETIME(cacheInfo.StartTime);
                ticket.EndTime = Helper.GetDateTimeFromFILETIME(cacheInfo.EndTime);
                ticket.RenewTime = Helper.GetDateTimeFromFILETIME(cacheInfo.RenewTime);
                ticket.EncryptionType = (KERB_ENC_TYPE)cacheInfo.EncryptionType;
                ticket.SessionKeyType = (KERB_ENC_TYPE)cacheInfo.SessionKeyType;
                ticket.TicketFlags = GetFlags((uint)cacheInfo.TicketFlags);
                ticket.CacheFlags = (KERB_CACHE_FLAGS)cacheInfo.CacheFlags;
                ticket.ServerName = cacheInfo.ServerName.ToString();
                ticket.ServerRealm = cacheInfo.ServerRealm.ToString();
                ticket.ClientName = cacheInfo.ClientName.ToString();
                ticket.ClientRealm = cacheInfo.ClientRealm.ToString();
                ticket.KdcCalled = cacheInfo.KdcCalled.ToString();
                ticket.BranchId = cacheInfo.BranchId;
                retList.Add(ticket);
            }

            return retList;
        }

        private TicketCacheResponse<KERB_QUERY_TKT_CACHE_RESPONSE> GetTicketCache()
        {
            KERB_QUERY_TKT_CACHE_REQUEST ticketCacheRequest = default;
            ticketCacheRequest.MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbQueryTicketCacheMessage;
            ticketCacheRequest.LogonId = 0;
            var sizeOfData = Marshal.SizeOf(typeof(KERB_QUERY_TKT_CACHE_REQUEST));
            var submitData = Marshal.AllocHGlobal(sizeOfData);
            Marshal.StructureToPtr(ticketCacheRequest, submitData, true);


            var winStatusCodes = NativeMethods.LsaCallAuthenticationPackage(_lsaHandle,
                                                    _kerberosPackageId,
                                                    submitData,
                                                    (uint)sizeOfData,
                                                    out IntPtr respPtr,
                                                    out _,
                                                    out _);
            Marshal.FreeHGlobal(submitData);
            if (winStatusCodes != 0)
            {
                throw new Exception(string.Concat("LsaCallAuthenticationPackage (LsaGetTickets) failed with NTSTATUS code: ", winStatusCodes, " (0x", winStatusCodes.ToString("x8"), ")"));
            }
            var cacheResp = Marshal.PtrToStructure<KERB_QUERY_TKT_CACHE_RESPONSE>(respPtr);
            return new TicketCacheResponse<KERB_QUERY_TKT_CACHE_RESPONSE> { Response = cacheResp, ResponsePointer = respPtr };
        }

        public List<TreeViewTicket> GetTickets()
        {

            List<TreeViewTicket> list = new List<TreeViewTicket>();
            var ticketCacheResp = GetTicketCache();

            var sizeOfInfo = Marshal.SizeOf(typeof(KERB_TICKET_CACHE_INFO));
            //4 bytes for message type + 4 bytes for count of tickets prop
            //var arrayOffset = Marshal.SizeOf((int)ticketCacheResp.Response.MessageType) + 
            //                  Marshal.SizeOf(ticketCacheResp.Response.CountOfTickets);
            var fieldOffset = Marshal.OffsetOf<KERB_QUERY_TKT_CACHE_RESPONSE>(nameof(KERB_QUERY_TKT_CACHE_RESPONSE.Tickets));
            var startAddress = ticketCacheResp.ResponsePointer.ToInt64() + fieldOffset.ToInt64();
            var ticketCount = ticketCacheResp.Response.CountOfTickets;
            for (int i = 0; i < ticketCount; i++)
            {
                var ptrAddr = startAddress + i * sizeOfInfo;
                var cacheInfo = Marshal.PtrToStructure<KERB_TICKET_CACHE_INFO>(new IntPtr(ptrAddr));
                TreeViewTicket ticket = new TreeViewTicket();
                ticket.StartTime = Helper.GetDateTimeFromFILETIME(cacheInfo.StartTime);
                ticket.EndTime = Helper.GetDateTimeFromFILETIME(cacheInfo.EndTime);
                ticket.RenewTime = Helper.GetDateTimeFromFILETIME(cacheInfo.RenewTime);
                ticket.EncryptionType = (KERB_ENC_TYPE)cacheInfo.EncryptionType;
                ticket.TicketFlags = GetFlags(cacheInfo.TicketFlags);
                ticket.ServerName = cacheInfo.ServerName.ToString();
                ticket.ServerRealm = cacheInfo.RealmName.ToString();
                list.Add(ticket);
            }
            if (ticketCacheResp.ResponsePointer != IntPtr.Zero)
            {
                NativeMethods.LsaFreeReturnBuffer(ticketCacheResp.ResponsePointer);
            }
            return list;
        }

        public KERB_TICKET_FLAGS GetFlags(uint ticketFlags)
        {
            KERB_TICKET_FLAGS retFlags = 0;
            var parsedFlags = (KERB_TICKET_FLAGS)ticketFlags;
            var flagValues = Enum.GetValues(typeof(KERB_TICKET_FLAGS)).Cast<KERB_TICKET_FLAGS>();
            foreach (var flag in flagValues)
            {
                if (parsedFlags.HasFlag(flag))
                {
                    retFlags |= flag;
                }
            }
            return retFlags;
        }

        public void RemoveTicketFromCache(TreeViewTicket ticket)
        {
            //every char is 2 bytes because of 0 separator
            var srvByteLen = ticket.ServerName.Length * 2;
            var rlmByteLen = ticket.ServerRealm.Length * 2;
            //48 bytes
            var sizeOfRequest = Marshal.SizeOf(typeof(KERB_PURGE_TKT_CACHE_REQUEST));

            var sizeOfWholeReq = sizeOfRequest + srvByteLen + rlmByteLen;
            //the size of whole request will be 48 bytes(size of struct) + amount of bytes that take up servername and realmname
            var wholePtrReq = Marshal.AllocHGlobal(sizeOfWholeReq);
            //start of whole req. ptr + size of request itself, next bytes gonna be server name
            var srvNamePtr = new IntPtr(wholePtrReq.ToInt64() + sizeOfRequest);
            //start of whole req. ptr + size of request itself + server name bytes as they are allocated above
            //next bytes gonna be server name
            var rlmNamePtr = new IntPtr(wholePtrReq.ToInt64() + sizeOfRequest + srvByteLen);

            //initialize unicode string and copy contents of string into buffer where ptr is pointing
            var serverNameUni = new UNICODE_STRING(ticket.ServerName, srvNamePtr);
            var realmNameUni = new UNICODE_STRING(ticket.ServerRealm, rlmNamePtr);

            var purgeRequest = new KERB_PURGE_TKT_CACHE_REQUEST
            {
                MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbPurgeTicketCacheMessage,
                LogonId = 0,
                ServerName = serverNameUni,
                RealmName = realmNameUni
            };

            Marshal.StructureToPtr(purgeRequest, wholePtrReq, true);
            var result = NativeMethods.LsaCallAuthenticationPackage(_lsaHandle, _kerberosPackageId, wholePtrReq, (uint)sizeOfWholeReq, out _, out _, out uint status);
            Marshal.FreeHGlobal(wholePtrReq);
            NativeMethods.LsaThrowIfError(result);
        }

        public void PurgeAllTickets()
        {
            var purgeRequest = new KERB_PURGE_TKT_CACHE_EX_REQUEST
            {
                MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbPurgeTicketCacheExMessage,
                LogonId = 0,
                Flags = 1
            };
            var sizeOfReq = Marshal.SizeOf(purgeRequest);
            var purgeRequestPtr = Marshal.AllocHGlobal(sizeOfReq);
            Marshal.StructureToPtr(purgeRequest, purgeRequestPtr, true);
            var result = NativeMethods.LsaCallAuthenticationPackage(_lsaHandle, _kerberosPackageId, purgeRequestPtr, (uint)sizeOfReq, out _, out _, out _);
            Marshal.FreeHGlobal(purgeRequestPtr);
            NativeMethods.LsaThrowIfError(result);
        }

        public void PurgeTickets_OLD(TreeViewTicket ticket)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(ticket.ServerName + "\0");
            byte[] bytes2 = Encoding.Unicode.GetBytes(ticket.ServerRealm + "\0");
            var sizeOfRequest = Marshal.SizeOf(typeof(KERB_PURGE_TKT_CACHE_REQUEST_GG));
            int sizeOfWholeRequest = sizeOfRequest + bytes.Length + bytes2.Length;
            IntPtr intPtr = Marshal.AllocHGlobal(sizeOfWholeRequest);
            IntPtr intPtr2 = new IntPtr(intPtr.ToInt64() + sizeOfRequest);
            IntPtr intPtr3 = new IntPtr(intPtr.ToInt64() + sizeOfRequest + bytes.Length);
            Marshal.Copy(bytes, 0, intPtr2, bytes.Length);
            Marshal.Copy(bytes2, 0, intPtr3, bytes2.Length);
            UNICODE_STRING_GG serverName = default;
            serverName.Length = (ushort)(bytes.Length - 2);
            serverName.MaximumLength = (ushort)bytes.Length;
            serverName.Buffer = intPtr2;
            UNICODE_STRING_GG realmName = default;
            realmName.Length = (ushort)(bytes2.Length - 2);
            realmName.MaximumLength = (ushort)bytes2.Length;
            realmName.Buffer = intPtr3;
            KERB_PURGE_TKT_CACHE_REQUEST_GG purgeRequest = default;
            purgeRequest.MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbPurgeTicketCacheMessage;
            purgeRequest.ServerName = serverName;
            purgeRequest.RealmName = realmName;
            purgeRequest.LogonId = 0L;
            Marshal.StructureToPtr(purgeRequest, intPtr, fDeleteOld: false);
            IntPtr ProtocolReturnBuffer;
            uint ReturnBufferLength;
            uint ProtocolStatus;
            var result = NativeMethods.LsaCallAuthenticationPackage(_lsaHandle, _kerberosPackageId, intPtr, (uint)sizeOfWholeRequest, out ProtocolReturnBuffer, out ReturnBufferLength, out ProtocolStatus);
            Marshal.FreeHGlobal(intPtr);
            NativeMethods.LsaThrowIfError(result);
        }

        ~TicketsManager()
        {
            Dispose(disposing: false);
        }

        private void Dispose(bool disposing)
        {
            if (_lsaHandle != IntPtr.Zero)
            {
                NativeMethods.LsaDeregisterLogonProcess(_lsaHandle);
                _lsaHandle = IntPtr.Zero;
            }
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}
