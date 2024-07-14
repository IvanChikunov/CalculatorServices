using calculator_back.Consts;
using calculator_back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace calculator_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        ICalculatorsFactory _calculatorsFactory;
        public CalculationController(ICalculatorsFactory calculatorsFactory)
        {
            _calculatorsFactory = calculatorsFactory;
        }

        [HttpGet]
        public string CalculateExpression(string expression, CalculationServicesEnum type)
        {
            try
            {
                var service = _calculatorsFactory.GetServiceByType(type);
                var result = service.Calculate(expression);
                return result;
            }
            catch (Exception ex)
            {
                return $"Something went wrong: ${ex.Message}";
            }
        }
    }
}
