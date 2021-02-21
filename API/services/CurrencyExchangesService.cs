using API.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.services
{
    public class CurrencyExchangesService
    {
        private readonly String BASE_URI = "https://free.currconv.com";
        private readonly String API_VERSION = "v7";
        private readonly String API_KEY = "fd6e325df569d87cfb37";

        
        public async Task<decimal> FetchCurrencyRateAsync(string currencyCode)
        {          
            decimal value = 1.0m;
          
            try
            {

                HttpClient client = new HttpClient();

                var url = $"{BASE_URI}/api/{API_VERSION}/convert?apiKey={API_KEY}&q={currencyCode}&compact=y";

                // Get response as string
                var response = await client.GetStringAsync(url);
               
                var jsonData = JObject.Parse(response);
               
                var val = Convert.ToString(jsonData[currencyCode]["val"]);
              
                value = Convert.ToDecimal(val);

                JObject json = JObject.Parse(response);
       

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return value;
        }

    }
}

