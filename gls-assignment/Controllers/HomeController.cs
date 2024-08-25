using gls_assignment.Models;
using static gls_assignment.Utils.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using static gls_assignment.Controllers.HomeController;
using gls_assignment.Services;

namespace gls_assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbService _dbService;


        public HomeController(ILogger<HomeController> logger, IDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Indextest()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public class JsonRpcResponse
        {
            [JsonProperty("jsonrpc")]
            public string JsonRpc { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("result")]
            public ResultData Result { get; set; }
        }

        public class ResultData
        {
            [JsonProperty("prices")]
            public List<PriceData> Prices { get; set; }
        }

        public class PriceData
        {
            [JsonProperty("dateISO8601")]
            public string DateISO8601 { get; set; }

            [JsonProperty("price")]
            public double Price { get; set; }
        }

        public class JsonRpcRequest
        {
            [JsonProperty("jsonrpc")]
            public string JsonRpc { get; set; }


            [JsonProperty("parameters")]
            public int Parameters { get; set; }

            [JsonProperty("startdate")]
            public DateTime Startdate { get; set; }

            [JsonProperty("enddate")]
            public DateTime Enddate { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }
        }

    [HttpPost]
        public IActionResult JsonRpc([FromBody] JsonRpcRequest request)
        {
            // Estrai i parametri dalla richiesta JSON-RPC
            string jsonrpc = request.JsonRpc;
            DateTime startDate = request.Startdate;
            DateTime endDate = request.Enddate; // Nuovo parametro endDate
            int id = request.Parameters;

            // Leggi il contenuto del file JSON
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "dataset", "dataset.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);

            // Deserialize JSON data
            List<JsonRpcResponse> responses = JsonConvert.DeserializeObject<List<JsonRpcResponse>>(jsonData);
            List<JsonRpcResponse> responsesFiltrate = responses.Where(r => r.Id == id).ToList();

            // Estrarre i dati delle singole risposte
            List<PriceData> dataListTypized2 = new List<PriceData>();

            foreach (var response2 in responsesFiltrate)
            {
                if (response2.Result != null && response2.Result.Prices != null)
                {
                    dataListTypized2.AddRange(response2.Result.Prices);
                }
            }

            // Filtra i dati in base all'intervallo di date
            var resultTypized = Utils.Utils.FilterPricesByIdAndDateRange(dataListTypized2, id, startDate, endDate);

            var response = new
            {
                jsonrpc = "2.0",
                result = resultTypized,
                id = id
            };

            return Json(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
