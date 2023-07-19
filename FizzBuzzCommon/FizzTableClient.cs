using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public class FizzTableClient : FizzBuzzTableClient<FizzTableEntity>, IFizzTableClient
    {
        public FizzTableClient(CloudTableClient tableClient)
            : base(tableClient, "fizztable")
        {
        }

        public void Upsert(int number, bool isFizz)
        {
            this.Upsert(new FizzTableEntity(number, isFizz));
        }

        public new FizzTableEntity Get(int number)
        {
            return base.Get(number);
        }
    }
}
