using calculator_back.Consts;

namespace calculator_back.Services.Interfaces
{
    public interface ICalculationService
    {
        public CalculationServicesEnum CalculationServiceType { get; }
        public string Calculate(string expression);
    }
}
