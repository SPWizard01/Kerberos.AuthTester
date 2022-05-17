using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Ntlm
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AvType
    {
        MsvAvEOL,
        MsvAvNbComputerName,
        MsvAvNbDomainName,
        MsvAvDnsComputerName,
        MsvAvDnsDomainName,
        MsvAvDnsTreeName,
        MsvAvFlags,
        MsvAvTimestamp,
        MsAvRestrictions,
        MsvAvTargetName,
        MsvChannelBindings
    }
}
