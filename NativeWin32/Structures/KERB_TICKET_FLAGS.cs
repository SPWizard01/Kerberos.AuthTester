namespace Kerb.AuthTester.NativeWin32.Structures
{
    //https://docs.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-kerb_ticket_cache_info
    [Flags]
    public enum KERB_TICKET_FLAGS : uint
    {
        /// <summary>
        /// The ticket-granting server can issue a new ticket-granting ticket with a different network address based on the presented ticket.
        /// </summary>
        forwardable = 0x40000000,
        /// <summary>
        /// The ticket has either been forwarded or was issued based on authentication that involved a forwarded ticket-granting ticket.
        /// </summary>
        forwarded = 0x20000000,
        /// <summary>
        /// The protocol employed for initial authentication required the use of hardware expected to be possessed solely by the named client. The hardware authentication method is selected by the KDC and the strength of the method is not indicated.
        /// </summary>
        hw_authent = 0x00100000,
        /// <summary>
        /// The ticket was issued by using the Authentication Service protocol instead of being based on a ticket-granting ticket.
        /// </summary>
        initial = 0x00400000,
        /// <summary>
        /// The ticket is not valid.
        /// </summary>
        invalid = 0x01000000,
        /// <summary>
        /// Indicates to the ticket-granting server that a postdated ticket can be issued based on this ticket-granting ticket.
        /// </summary>
        may_postdate = 0x04000000,
        /// <summary>
        /// The target of the ticket is trusted by the directory service for delegation.Thus, clients may delegate their credentials to the server, which lets the server act as the client when talking to other services.
        /// </summary>
        ok_as_delegate = 0x00040000,
        /// <summary>
        /// The ticket has been postdated.The end-service can check the ticket's authtime member to see when the original authentication occurred.
        /// </summary>
        postdated = 0x02000000,
        /// <summary>
        /// During initial authentication, the client was authenticated by the Key Distribution Center (KDC) before a ticket was issued. The strength of the preauthentication method is not indicated, but is acceptable to the KDC.
        /// </summary>
        pre_authent = 0x00200000,
        /// <summary>
        /// Indicates to the ticket-granting server that only nonticket-granting tickets can be issued based on this ticket but with a different network addresses.
        /// </summary>
        proxiable = 0x10000000,
        /// <summary>
        /// The ticket is a proxy.
        /// </summary>
        proxy = 0x08000000,
        /// <summary>
        /// The ticket is renewable.If this flag is set, the time limit for renewing the ticket is set in RenewTime.A renewable ticket can be used to obtain a replacement ticket that expires at a later date.
        /// </summary>
        renewable = 0x00800000,
        /// <summary>
        /// Reserved for future use. Do not set this flag.
        /// </summary>
        reserved = 0x80000000,
        /// <summary>
        /// Reserved for future use. Do not set this flag.
        /// </summary>
        reserved1 = 0x00000001

    }
}
