using Autofac;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public class FizzBuzzModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString));

            builder.Register(c =>
            {
                // Create the table client.
                CloudTableClient tableClient = c.Resolve<CloudStorageAccount>().CreateCloudTableClient();

                return tableClient;
            })
            .SingleInstance();

            builder.Register(c =>
            {
                // Create the queue client.
                CloudQueueClient queueClient = c.Resolve<CloudStorageAccount>().CreateCloudQueueClient();

                return queueClient;
            })
            .SingleInstance();

            builder
                .RegisterType<FizzTableClient>()
                .AsImplementedInterfaces();

            builder
                .RegisterType<BuzzTableClient>()
                .AsImplementedInterfaces();
        }

    }
}
