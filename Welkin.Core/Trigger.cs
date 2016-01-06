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
