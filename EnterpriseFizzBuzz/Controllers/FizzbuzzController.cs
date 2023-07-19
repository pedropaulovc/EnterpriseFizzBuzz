using EnterpriseFizzBuzz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnterpriseFizzBuzz.Controllers
{
    public class FizzbuzzController : ApiController
    {
        public IFizzService FizzService { get; set; }
        public IBuzzService BuzzService { get; set; }

        public FizzbuzzController()
        {
        }

        public FizzbuzzController(
            IFizzService fizzService,
            IBuzzService buzzService)
        {
            this.FizzService = fizzService;
            this.BuzzService = buzzService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            bool? isFizzResult = this.FizzService.FetchCachedFizzMetadata(id);
            bool? isBuzzResult = this.BuzzService.FetchCachedBuzzMetadata(id);

            bool isFizz = isFizzResult ?? this.FizzService.CalculateFizz(id);
            bool isBuzz = isBuzzResult ?? this.BuzzService.CalculateBuzz(id);

            if (isFizz && isBuzz)
            {
                return "FizzBuzz";
            }
            else if (isFizz)
            {
                return "Fizz";
            }
            else if (isBuzz)
            {
                return "Buzz";
            }

            return id.ToString();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
