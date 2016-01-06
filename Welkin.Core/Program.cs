using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Configuration;

namespace Avanzar.Welkin.Core
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        private static IUnityContainer _container;
        static void Main()
        {
            Register();

            var config = new JobHostConfiguration
            {
                JobActivator = new Activator(_container)

            };

            var host = new JobHost(config);
            

            host.RunAndBlock();
        }

        public static void Register()
        {
            using (_container = new UnityContainer())
            {
                //Registering all Entities
            }
        }

        //For Testing
        public static void SendMessage(string msg)
        {

            var credentials = new StorageCredentials("welkinstoragedev", "Zk4FUJTCdm2ViP8xplmG/Zm1Vzop9g6u+1Ey86hl2wG5C5ZuIjZX1Eta1gjLscJDjRqglToXzHL+pWnzgxpCRg==");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);

            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("queue");
            //queue.DeleteIfExists();
            queue.Clear();

            CloudQueueMessage message = new CloudQueueMessage(msg);
            queue.AddMessage(message);

        }
    }

}
