using BlackCoinMultipool.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Service
{
    public class BlackCoinMultipoolService : IBlackCoinMultipoolService
    {
        private static readonly string _baseUrl = "http://www.clevermining.com/users/";

        public async Task<Statistics> GetStatistics(string bitcoinAddress)
        {
            string pageHtml = await GetPage(bitcoinAddress);

            Statistics stats = await ParsePage(pageHtml);

            return new Statistics() { Address = bitcoinAddress, HashRate = 900.6, AverageHashRate = 1632.5, TotalProfit = 0.00102301 };
        }

        private async Task<string> GetPage(string bitcoinAddress)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                var result = await httpClient.GetAsync(bitcoinAddress);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return await result.Content.ReadAsStringAsync();
                else
                    return string.Empty;
            }
        }

        private Task<Statistics> ParsePage(string pageHtml)
        {
            return Task.Run(() =>
            {



                return new Statistics();
            });
        }
    }
}
