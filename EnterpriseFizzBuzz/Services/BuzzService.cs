using EnterpriseFizzBuzz.Services;
using FizzBuzzCommon;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading;

namespace EnterpriseBuzzBuzz.Services
{
    public class BuzzService : IBuzzService
    {
        private readonly IBuzzTableClient tableClient;
        private readonly CloudQueueClient queueClient;

        public BuzzService(IBuzzTableClient tableClient, CloudQueueClient queueClient)
        {
            this.tableClient = tableClient;
            this.queueClient = queueClient;
        }

        public bool? FetchCachedBuzzMetadata(int number)
        {
            return this.tableClient.Get(number)?.IsBuzz;
        }

        public bool CalculateBuzz(int number)
        {
            queueClient.GetQueueReference("buzzqueue").AddMessage(new CloudQueueMessage(number.ToString()));

            bool? isBuzz;

            do
            {
                isBuzz = this.FetchCachedBuzzMetadata(number);
                Thread.Sleep(500);
            } while (!isBuzz.HasValue);

            return isBuzz.Value;
        }
    }
}