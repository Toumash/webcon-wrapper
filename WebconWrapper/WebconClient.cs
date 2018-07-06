using System.ServiceModel;
using WebconProxy;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using System;

namespace WebconWrapper
{
    public class WebconClient
    {
        private BPSWebservice _client;

        internal WebconClient(BPSWebservice client)
        {
            _client = client;
        }

        internal async Task<NewElement> NewWorkflowAsync(int wfId, int formId)
        {
            var newElementParams = new GetNewElementParams()
            {
                WorkFlowId = wfId,
                DocTypeId = formId
            };
            return await _client.GetNewElementAsync(newElementParams);
        }

        public static WebconClient WithCachedCredentials(string url)
        {
            BPSWebserviceClient connection = CreateConnection(url);

            var credentials = connection.ClientCredentials.Windows;
            credentials.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            credentials.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            return new WebconClient(connection);
        }

        public static WebconClient WithPassword(string url, string username, string password)
        {
            BPSWebserviceClient connection = CreateConnection(url);

            var clientCredentials = connection.ClientCredentials;
            clientCredentials.UserName.UserName = username;
            clientCredentials.UserName.Password = password;
            clientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            var credential = connection.ClientCredentials.Windows.ClientCredential;
            credential.UserName = username;
            credential.Password = password;

            return new WebconClient(connection);
        }

        private static BPSWebserviceClient CreateConnection(string url)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            var endpoint = new EndpointAddress(url);
            var connection = new BPSWebserviceClient(binding, endpoint);
            return connection;
        }
    }
}
