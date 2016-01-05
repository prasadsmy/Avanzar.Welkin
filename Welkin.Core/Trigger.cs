using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Avanzar.Welkin.Core
{
    public class Trigger
    {
        public static void TriggerMapper([QueueTrigger("queue")] string message)
        {

            switch (message)
            {
                case "Case":
                    break;
                case "Deed":
                    break;
            }
        }
    }
}
