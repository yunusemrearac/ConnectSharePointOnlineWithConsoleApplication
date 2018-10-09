using Microsoft.SharePoint.Client;
using System;
using System.Configuration;

namespace ConnectSharePointOnlineWithConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClientContext clientContext = new ClientContext(ConfigurationManager.AppSettings["siteUrl"].ToString());

                clientContext.AuthenticationMode = ClientAuthenticationMode.Default;

                string password = ConfigurationManager.AppSettings["userPassword"].ToString();
                System.Security.SecureString passwordChar = new System.Security.SecureString();
                foreach (char ch in password)
                    passwordChar.AppendChar(ch);

                clientContext.Credentials = new SharePointOnlineCredentials(ConfigurationManager.AppSettings["userEmail"].ToString(), passwordChar);

                Web web = clientContext.Web;
                clientContext.Load(web);
                clientContext.ExecuteQuery();

                Console.WriteLine("Connect to " + web.Url);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect error to site. Error : " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
