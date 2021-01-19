using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using wxapichallenge.Entities;
using wxapichallenge.Models;

namespace wxapichallenge.Data
{
    public class ServiceContext : IServiceContext
    {
        private readonly IConfiguration _config;

        public ServiceContext(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        { 
            using (var httpClient = new HttpClient())
            {
                List<Product> productList = new List<Product>();
                using (var response = await httpClient.GetAsync(GetExternalEndPointWithTokenForProduct))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if(apiResponse != null)
                        productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                    else
                        throw new HttpRequestException("Unable to reach underlying service.");
                }
                
                return productList;
            }
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync()
        { 
            using (var httpClient = new HttpClient())
            {
                List<ShopperHistory> shopperHistoryList = new List<ShopperHistory>();
                using (var response = await httpClient.GetAsync(GetExternalEndPointWithTokenForShopperHistory))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if(apiResponse != null)
                        shopperHistoryList = JsonConvert.DeserializeObject<List<ShopperHistory>>(apiResponse);
                    else
                        throw new HttpRequestException("Unable to reach underlying service.");
                }

                return shopperHistoryList;
            }
        }

        public async Task<float> GetTrolleyTotalAsync(TrolleyItemsForPostDto trolleyItemsForPostDto)
        { 
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var stringContent = new StringContent(
                JsonConvert.SerializeObject(trolleyItemsForPostDto,serializerSettings),
                Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {   
                using (var response = await httpClient.PostAsync(GetExternalEndPointWithTokenForTrolleyTotal,
                                            stringContent))
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (result != null)
                        return float.Parse(result);
                    else
                        throw new HttpRequestException("Unable to reach underlying service.");

                }
            }
        }

        public string GetExternalEndPointWithTokenForProduct
        {
            get
            {
                return _config.GetValue<string>("ExternalServiceURI") + "/products?token=" + 
                                                        _config.GetValue<string>("UserToken");
            }
        }

        public string GetExternalEndPointWithTokenForShopperHistory
        {
            get
            {
                return _config.GetValue<string>("ExternalServiceURI") + "/shopperHistory?token=" + 
                                                        _config.GetValue<string>("UserToken");
            }
        }

        public string GetExternalEndPointWithTokenForTrolleyTotal
        {
            get
            {
                return _config.GetValue<string>("ExternalServiceURI") + "/trolleyCalculator?token=" + 
                                                        _config.GetValue<string>("UserToken");
            }
        }


    }
}