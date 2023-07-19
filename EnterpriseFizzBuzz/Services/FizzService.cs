using FizzBuzzCommon;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EnterpriseFizzBuzz.Services
{
    public class FizzService : IFizzService
    {
        private readonly IFizzTableClient tableClient;
        private readonly CloudQueueClient queueClient;

        public FizzService(IFizzTableClient tableClient, CloudQueueClient queueClient)
        {
            this.tableClient = tableClient;
            this.queueClient = queueClient;
        }

        public bool? FetchCachedFizzMetadata(int number)
        {
            return this.tableClient.Get(number)?.IsFizz;
        }

        public bool CalculateFizz(int number)
        {
            queueClient.GetQueueReference("fizzqueue").AddMessage(new CloudQueueMessage(number.ToString()));

            bool? isFizz = null;

            do
            {
                isFizz = this.FetchCachedFizzMetadata(number);
                Thread.Sleep(500);
            } while (!isFizz.HasValue);

            return isFizz.Value;
        }
    }
}