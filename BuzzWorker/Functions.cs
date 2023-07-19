using FizzBuzzCommon;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzWorker
{
    public class Functions
    {
        private readonly IBuzzTableClient tableClient;

        public Functions(IBuzzTableClient tableClient)
        {
            this.tableClient = tableClient;
        }

        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public void ProcessQueueMessage([QueueTrigger("buzzqueue")] string message, TextWriter log)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(message);
            }
            catch
            {
                log.WriteLine($"Can't parse {message} as a number");
            }

            this.tableClient.Upsert(number, (number % 5) == 0);

            log.WriteLine($"Inserted IBuzz for {number}");
        }
    }
}
