using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnterpriseFizzBuzz.Services
{
    public interface IFizzService
    {
        bool? FetchCachedFizzMetadata(int number);

        bool CalculateFizz(int number);
    }
}