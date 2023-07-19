using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCommon
{
    public class BuzzTableEntity : TableEntity
    {
        public BuzzTableEntity()
            : base()
        {
        }

        public BuzzTableEntity(int number, bool isBuzz)
            : base(number.ToString(), number.ToString())
        {
            this.IsBuzz = isBuzz;
        }

        public bool IsBuzz { get; set; }

        public override string ToString()
        {
            return $"BuzzTableEntity({this.RowKey}, {this.IsBuzz})";
        }
    }
}
