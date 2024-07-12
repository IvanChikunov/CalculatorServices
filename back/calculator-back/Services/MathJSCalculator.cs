using calculator_back.Consts;
using calculator_back.Services.Interfaces;
using System.Web;

namespace calculator_back.Services
{
    public class MathJSCalculator : ICalculationService
    {
        public CalculationServicesEnum CalculationServiceType => CalculationServicesEnum.MathJs;
        private readonly string Url = "http://api.mathjs.org/v4/?expr=";
        public string Calculate(string expression)
        {
            using (var client = new HttpClient())
            {
                var param = HttpUtility.UrlEncode(expression);
                var result = client.GetAsync(Url + param).Result.Content.ReadAsStringAsync();
                return result.Result;
            }
        }
    }
}
