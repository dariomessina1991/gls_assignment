using Newtonsoft.Json.Linq;
using static gls_assignment.Controllers.HomeController;

namespace gls_assignment.Utils
{
    public class Utils
    {
        public static List<JObject> FilterPricesByIdAndDateRange(List<JObject> dataList, int targetId, DateTime startDate, DateTime endDate)
        {
            List<JObject> resultList = new List<JObject>();

            foreach (var item in dataList)
            {
                // Verifica se l'oggetto ha l'id corretto
                if (item["id"] != null && item["id"].Value<int>() == targetId)
                {
                    // Ottieni i prezzi
                    var prices = item["result"]["prices"] as JArray;

                    // Filtra i prezzi in base alle date
                    var filteredPrices = prices
                        .Where(p =>
                        {
                            DateTime priceDate = DateTime.Parse(p["dateISO8601"].ToString());
                            return priceDate >= startDate && priceDate <= endDate;
                        })
                        .ToList();

                    // Aggiungi i prezzi filtrati alla lista dei risultati
                    foreach (var price in filteredPrices)
                    {
                        resultList.Add((JObject)price);
                    }
                }
            }

            return resultList;
        }


        public static List<PriceData> FilterPricesByIdAndDateRange(List<PriceData> dataList, int id, DateTime startDate, DateTime endDate)
        {
            if (dataList == null || !dataList.Any())
            {
                return new List<PriceData>();
            }

            List<PriceData> filteredData = new List<PriceData>();

            foreach (var p in dataList)
            {
                if (DateTime.TryParse(p.DateISO8601, out DateTime parsedDate))
                {
                    Console.WriteLine($"Parsed Date: {parsedDate}, Start Date: {startDate}, End Date: {endDate}");

                    if (parsedDate >= startDate && parsedDate <= endDate)
                    {
                        filteredData.Add(p);
                        Console.WriteLine($"Date {parsedDate} is within range.");
                    }
                    else
                    {
                        Console.WriteLine($"Date {parsedDate} is outside the range.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to parse date: {p.DateISO8601}");
                }
            }

            return filteredData;
        }

    }
}
