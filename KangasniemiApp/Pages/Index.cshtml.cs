using KangasniemiApp.Model;
using KangasniemiApp.Model.PxNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KangasniemiApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IRestResponse<Response> ApiResponse { get; set; }
        public ChartModel ChartData { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        private void CreateChartData()
        {
            ChartData = new ChartModel();
            ChartData.Title = ApiResponse.Data.Label;
            ChartData.TitleX = ApiResponse.Data.Id[2];
            ChartData.TitleY = "%";
            ChartData.Labels = ApiResponse.Data.Dimension["Vuosi"].Category["label"].Values.ToList();
            ChartData.Values = SplitList(ApiResponse.Data.Value, ApiResponse.Data.Value.Count/3).ToList();
            //ChartData.Values = ApiResponse.Data.Value;
        }

        public void OnGetAsync()
        {
            HaeDataAsync();
            CreateChartData();
        }

        public async void HaeDataAsync()
        {
            Request requestData = new Request()
            {
                Response = new RequestResponse()
                {
                    Format = "json-stat2"
                },
                Query = new List<QueryItem>()
                {
                    new QueryItem()
                    {
                        Code = "Kunta",
                        Selection = new QueryItemSelection()
                        {
                                Filter = "Item",
                                Values = new List<string>()
                                {
                                    "213"
                                }
                        }
                    },
                    new QueryItem()
                    {
                        Code = "Muuttuja",
                        Selection = new QueryItemSelection()
                        {
                                Filter = "Item",
                                Values = new List<string>()
                                {
                                    "01","02","03"
                                }
                        }
                    }
                }
            };

            var client = new RestClient("https://pxnet2.stat.fi/PXWeb/api/v1/fi/Explorer/Vaestolaskenta/vaestolaskenta.px");
            client.Timeout = -1;
            client.ThrowOnAnyError = true;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "rxid=c9b77cdd-6483-4eea-828d-e97b93a884bb");
            request.AddJsonBody(requestData);

            ApiResponse = client.Execute<Response>(request);
        }
    }
}
