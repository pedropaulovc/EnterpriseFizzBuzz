using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public class BuzzTableClient : FizzBuzzTableClient<BuzzTableEntity>, IBuzzTableClient
    {
        public BuzzTableClient(CloudTableClient tableClient)
            : base(tableClient, "buzztable")
        {
        }

        public void Upsert(int number, bool isFizz)
        {
            this.Upsert(new BuzzTableEntity(number, isFizz));
        }

        public new BuzzTableEntity Get(int number)
        {
            return base.Get(number);
        }
    }
}
