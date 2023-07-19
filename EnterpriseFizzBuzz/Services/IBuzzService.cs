using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnterpriseFizzBuzz.Services
{
    public interface IBuzzService
    {
        bool? FetchCachedBuzzMetadata(int number);

        bool CalculateBuzz(int number);
    }
}