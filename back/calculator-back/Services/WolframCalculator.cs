using calculator_back.Consts;
using calculator_back.Services.Interfaces;
using System.Text.Json.Nodes;
using System.Web;

namespace calculator_back.Services
{
    public class WolframCalculator : ICalculationService
    {
        public CalculationServicesEnum CalculationServiceType => CalculationServicesEnum.WolframAlpha;

        private readonly string Url = "https://www.wolframalpha.com/n/v1/api/autocomplete/?i=";
        public string Calculate(string expression)
        {
            using (var client = new HttpClient())
            {
                var param = HttpUtility.UrlEncode(expression);
                var result = client.GetAsync(Url + param).Result.Content.ReadAsStringAsync();
                try
                {
                    var data = JsonObject.Parse(result.Result)?["instantMath"]?["exactResult"]?.ToString();
                    return data != null ? data : "Не найдено решение";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
