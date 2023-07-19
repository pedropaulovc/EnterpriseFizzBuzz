using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public class FizzTableEntity : TableEntity
    {
        public FizzTableEntity()
            : base()
        {
        }

        public FizzTableEntity(int number, bool isFizz)
            : base(number.ToString(), number.ToString())
        {
            this.IsFizz = isFizz;
        }

        public bool IsFizz { get; set; }

        public override string ToString()
        {
            return $"FizzTableEntity({this.RowKey}, {this.IsFizz})";
        }
    }
}
