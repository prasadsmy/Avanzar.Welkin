using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading;
using System.Configuration;
using System.Globalization;

namespace Avanzar.Welkin.Core.Authentication
{
    public class AzureADAuthenticator : IAuthenticate
    {
        public string GetApplicationAccountToken(string resourceUrl)
        {
            AuthenticationResult result = null;

            string authority = string.Format("https://login.microsoftonline.com/{0}/oauth2/token/", ConfigurationManager.AppSettings["TenantId"]);

            var context = new AuthenticationContext(authority);

            ClientCredential credential = new ClientCredential(ConfigurationManager.AppSettings["ClientId"], 
                ConfigurationManager.AppSettings["ClientSecret"]);

            var thread = new Thread(() =>
            {
                result = context.AcquireToken(resourceUrl, credential);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "AquireTokenThread";
            thread.Start();
            thread.Join();

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            string token = result.AccessToken;
            return token;
        }
    }
}
