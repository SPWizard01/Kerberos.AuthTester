using Kerb.AuthTester.Authorization;
using Kerb.AuthTester.Authorization.Basic;
using Kerb.AuthTester.Authorization.Kerberos;
using Kerb.AuthTester.Authorization.Ntlm;
using Kerb.AuthTester.Models;
using System.Net;
using System.Security.Authentication;

namespace Kerb.AuthTester
{
    public class AuthTestRequest
    {

        public string Url { get; set; } = string.Empty;
        public string HttpResult { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string SPN { get; set; } = string.Empty;
        public AuthorizationType AuthorizationType { get; set; }
        public AuthorizationMessage? AuthorizationMessage { get; set; }
        protected ICredentials? RequestCredentials { private get; set; }
        protected IWebProxy? Proxy { private get; set; }
        public List<HeaderValue> RequestHeaders { get; set; } = new List<HeaderValue>();
        public List<HeaderValue> ResponseHeaders { get; set; } = new List<HeaderValue>();

        public AuthTestRequest(string url, ICredentials? requestCredentials, IWebProxy? proxy)
        {
            Url = url;
            RequestCredentials = requestCredentials;
            Proxy = proxy;
        }

        public async Task DoRequest()
        {
            RequestDate = DateTime.Now;
            HttpResponseMessage? response = null;
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.AllowAutoRedirect = false;
                httpHandler.SslProtocols = SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;

                httpHandler.Credentials = RequestCredentials; 

                httpHandler.Proxy = Proxy;
                httpHandler.UseProxy = Proxy != null;
                
                var httpClient = new HttpClient(httpHandler);
                response = await httpClient.GetAsync(Url);
            }
            catch (Exception ex2)
            {
                ErrorMessage = ex2.Message;
            }
            if (response != null)
            {
                ProcessResponse(response);
            }
        }

        private void ProcessResponse(HttpResponseMessage responseMessage)
        {
            SetHttpResult(responseMessage);
            SetHeaders(responseMessage);
            ParseAuthorizationHeader();
        }

        private void SetHeaders(HttpResponseMessage responseMessage)
        {
            var allKeys = responseMessage.RequestMessage?.Headers?.GetEnumerator();
            while (allKeys?.MoveNext() ?? false)
            {
                var currentKey = allKeys.Current;
                foreach (var item in currentKey.Value)
                {
                    RequestHeaders.Add(new HeaderValue { Header = currentKey.Key, Value = item });
                }
            }
            var responseKeys = responseMessage.Headers.GetEnumerator();
            while (responseKeys?.MoveNext() ?? false)
            {
                var respKey = responseKeys.Current;
                foreach (var item in respKey.Value)
                {
                    ResponseHeaders.Add(new HeaderValue { Header = respKey.Key, Value = item });
                }
            }
        }

        private void ParseAuthorizationHeader()
        {
            var authResp = RequestHeaders.FirstOrDefault(k => k.Header == "Authorization");

            if (authResp != null)
            {
                ParseAuthorizationHeaderValue(authResp.Value);
            }
            else
            {
                AuthorizationType = AuthorizationType.None;
            }
        }

        private void ParseAuthorizationHeaderValue(string? headerValue)
        {
            if (headerValue == null)
            {
                ErrorMessage = "Authorization header is empty";
                return;
            }
            try
            {
                AuthorizationMessage = AuthorizationMessageFactory.Build(headerValue);
                AuthorizationType = AuthorizationMessage.AuthorizationType;
                if (AuthorizationMessage is BasicAuthorizationMessage)
                {
                    UserName = ((BasicAuthorizationMessage)AuthorizationMessage).UserName;
                }
                else if (AuthorizationMessage is NtlmAuthorizeMessage)
                {
                    SetNtlmValues((NtlmAuthorizeMessage)AuthorizationMessage);
                }
                else if (AuthorizationMessage is KerberosAuthorizeMessage)
                {
                    SetKerberosValues((KerberosAuthorizeMessage)AuthorizationMessage);
                }
                else
                {
                    ErrorMessage = "Unexpected authorization header";
                }
            }
            catch (Exception)
            {
                ErrorMessage = "Unexpected authorization header";
            }
        }

        private void SetKerberosValues(KerberosAuthorizeMessage kerberosAuthorizeMessage)
        {
            try
            {
                if (kerberosAuthorizeMessage.NegotiationToken != null)
                {
                    var negTokenInit = kerberosAuthorizeMessage.NegotiationToken;
                    SPN = negTokenInit.MechToken.InnerContextToken.Ticket.ServiceName.ToString();
                    Domain = negTokenInit.MechToken.InnerContextToken.Ticket.Realm;
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetNtlmValues(NtlmAuthorizeMessage ntlmAuthorizeMessage)
        {
            UserName = ntlmAuthorizeMessage.UserName;
            Domain = ntlmAuthorizeMessage.DomainName;
        }

        private void SetHttpResult(HttpResponseMessage responseMessage)
        {
            HttpResult = $"{(int)responseMessage.StatusCode} {responseMessage.StatusCode}";
        }
    }
}
