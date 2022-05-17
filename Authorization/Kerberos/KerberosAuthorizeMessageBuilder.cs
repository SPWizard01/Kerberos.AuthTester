using LipingShare.LCLib.Asn1Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerb.AuthTester.Authorization.Kerberos
{
    public class KerberosAuthorizeMessageBuilder
    {
        public static void Build(KerberosAuthorizeMessage kerberosAuthorizeMessage, byte[] data)
        {
            Asn1Parser asn1Parser = new Asn1Parser();
            MemoryStream stream = new MemoryStream(data);
            asn1Parser.LoadData(stream);
            Asn1Node rootNode = asn1Parser.RootNode;
            BuildRoot(kerberosAuthorizeMessage, rootNode);
        }

        private static void BuildRoot(KerberosAuthorizeMessage msg, Asn1Node root)
        {
            if (root.ChildNodeCount == 2)
            {
                Asn1Node childNode = root.GetChildNode(0);
                if ((childNode.Tag & 0x1F) != 6)
                {
                    throw new Exception("OBJECT_IDENTIFIER expected. (path: " + childNode.Path + ")");
                }
                msg.MechType = new MechType(childNode.GetDataStr(pureHexMode: false));
                msg.NegotiationToken = new NegTokenInit();
                BuildNegotiateTokenInit(msg.NegotiationToken, root.GetChildNode(1).GetChildNode(0));
            }
            else if (root.ChildNodeCount == 1)
            {
                msg.NegotiationToken = new NegTokenInit();
                BuildNegotiateTokenInit(msg.NegotiationToken, root.GetChildNode(0));
            }
        }

        private static void BuildNegotiateTokenInit(NegTokenInit negToken, Asn1Node sequence)
        {
            for (int i = 0; i < sequence.ChildNodeCount; i++)
            {
                switch (GetContextNumber(sequence.GetChildNode(i)))
                {
                    case 0:
                        BuildMechTypes(negToken, sequence.GetChildNode(i));
                        break;
                    case 2:
                        negToken.MechToken = new InitialContextToken();
                        BuildMechToken(negToken.MechToken, sequence.GetChildNode(i));
                        break;
                }
            }
        }

        private static void BuildMechTypes(NegTokenInit negToken, Asn1Node asn1Node)
        {
            if (asn1Node.ChildNodeCount <= 0)
            {
                return;
            }
            Asn1Node childNode = asn1Node.GetChildNode(0);
            negToken.MechTypes = new List<MechType>();
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                if ((childNode.GetChildNode(i).Tag & 0x1F) == 6)
                {
                    negToken.MechTypes.Add(new MechType(childNode.GetChildNode(i).GetDataStr(pureHexMode: false)));
                }
            }
        }

        private static void BuildMechToken(InitialContextToken initialContextToken, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0).GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                if ((childNode.GetChildNode(i).Tag & 0xC0u) != 0)
                {
                    if ((childNode.GetChildNode(i).Tag & 0xC0) == 64)
                    {
                        initialContextToken.InnerContextToken = new KrbApReq();
                        BuildKrbApReq(initialContextToken.InnerContextToken, childNode.GetChildNode(i));
                    }
                }
                else if ((childNode.GetChildNode(i).Tag & 0x1F) == 6)
                {
                    initialContextToken.ThisMech = new MechType(childNode.GetChildNode(i).GetDataStr(pureHexMode: false));
                }
            }
        }

        private static void BuildKrbApReq(KrbApReq krbApReq, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                Asn1Node childNode2 = childNode.GetChildNode(i);
                switch (GetContextNumber(childNode2))
                {
                    case 0:
                        krbApReq.ProtocolVersionNumber = (int)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 1:
                        krbApReq.MessageType = (MessageType)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 2:
                        krbApReq.APOptions = (APOptions)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 3:
                        krbApReq.Ticket = new Ticket();
                        BuildTicket(krbApReq.Ticket, childNode2);
                        break;
                    case 4:
                        krbApReq.Authenticator = new EncryptedData();
                        BuildEncryptedData(krbApReq.Authenticator, childNode2);
                        break;
                }
            }
        }

        private static void BuildEncryptedData(EncryptedData encryptedData, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                Asn1Node childNode2 = childNode.GetChildNode(i);
                switch (GetContextNumber(childNode2))
                {
                    case 0:
                        encryptedData.EncryptionType = (EncryptionType)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 1:
                        encryptedData.KeyVersionNumber = (uint)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 2:
                        encryptedData.Cipher = new byte[childNode2.GetChildNode(0).DataLength];
                        Buffer.BlockCopy(childNode2.GetChildNode(0).Data, 0, encryptedData.Cipher, 0, encryptedData.Cipher.Length);
                        break;
                }
            }
        }

        private static void BuildTicket(Ticket ticket, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0).GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                Asn1Node childNode2 = childNode.GetChildNode(i);
                switch (GetContextNumber(childNode2))
                {
                    case 0:
                        ticket.TicketVersionNumber = (int)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 1:
                        ticket.Realm = childNode2.GetChildNode(0).GetDataStr(pureHexMode: false);
                        break;
                    case 2:
                        ticket.ServiceName = new PrincipalName();
                        BuildPrincipleName(ticket.ServiceName, childNode2);
                        break;
                    case 3:
                        ticket.EncPart = new EncryptedData();
                        BuildEncryptedData(ticket.EncPart, childNode2);
                        break;
                }
            }
        }

        private static void BuildPrincipleName(PrincipalName principalName, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                Asn1Node childNode2 = childNode.GetChildNode(i);
                var ctxNum = GetContextNumber(childNode2);
                switch (ctxNum)
                {
                    case 0:
                        principalName.NameType = (PrincipalNameType)Asn1Util.BytesToLong(childNode2.GetChildNode(0).Data);
                        break;
                    case 1:
                        principalName.NameString = new List<string>();
                        BuildPrincipleNameList(principalName.NameString, childNode2);
                        break;
                }
            }
        }

        private static void BuildPrincipleNameList(List<string> list, Asn1Node asn1Node)
        {
            Asn1Node childNode = asn1Node.GetChildNode(0);
            for (int i = 0; i < childNode.ChildNodeCount; i++)
            {
                list.Add(childNode.GetChildNode(i).GetDataStr(pureHexMode: false));
            }
        }

        private static int GetContextNumber(Asn1Node node)
        {
            if ((node.Tag & 0xC0) != 128)
            {
                throw new Exception("Node is not of class CONTEXT SPECIFIC. (Path: " + node.Path + ")");
            }
            return node.Tag & 0x1F;
        }
    }

}
